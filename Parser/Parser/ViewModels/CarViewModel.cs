using Parser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AngleSharp.Dom;
using AngleSharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Parser.Model.Models;
using Parser.Model.Models.Configuration;
using Parser.Model.Models.BaseClasses;
using StaticParser;
using System.Data;
using Microsoft.Data.SqlClient;
using Parser.Model.Models.Classes;
using Parser.Model.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Parser.ViewModels
{
    public enum FieldCar
    {
        Code,
        Name,
        DateCreation,
    }
    public enum FieldConfig
    {
        Code,
        Engine,
        DateCreation,
        SpecificationItems
    }


    internal class CarViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CarPresent> Cars { get; set; } = new ObservableCollection<CarPresent>();
        public CarCatContext _context = new CarCatContext();
        public CatCarParser CatCarParserObj { get; set; }
        private string _message = "Загрузка";

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public CarViewModel()
        {
            CatCarParserObj = new CatCarParser(_context);
            LoadCars();
        }

        private async void LoadCars()
        {
            var cars = CatCarParserObj.ParseCar("https://www.catcar.info/toyota/?l=bWFya2V0PT1ldXJvfHxzdD09MjB8fHN0cz09eyIxMCI6Ilx1MDQyMFx1MDQ0Ylx1MDQzZFx1MDQzZVx1MDQzYSIsIjIwIjoiXHUwNDE1XHUwNDEyXHUwNDIwXHUwNDFlXHUwNDFmXHUwNDEwIn0%3D");
            await _context.AddRangeAsync(cars);
            await _context.SaveChangesAsync();

            foreach (var item in cars)
            {
               await CatCarParserObj.ParseConfiguration(item.LinkToConfig, item);
            }

            Message = "";

            var list = _context.CarPresents.ToList();

            foreach (var item in list)
            {
                Cars.Add(item);
            }
        }

        public virtual event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            App.Current?.Dispatcher.Invoke(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }

    }
}
