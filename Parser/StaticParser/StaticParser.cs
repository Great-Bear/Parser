using AngleSharp;

// Парсер не заточен под кокретный сайт, поэтому я вынес его в отдельный проект если нужно будет парсить и другие сайты
namespace StaticParser
{
    public static class StaticParser
    {

        private static IConfiguration _config;
        private static IBrowsingContext _context;

        static StaticParser()
        {
            _config = Configuration.Default.WithDefaultLoader();
            _context = BrowsingContext.New(_config);
        }

        public static AngleSharp.Dom.IDocument LoadPage(string link)
        {
            return _context.OpenAsync(link).Result;
        }
    }
}