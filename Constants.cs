namespace PDFAnalyzer
{
    public static class Constants
    {
        public readonly static string[] INDICATORS_ONE = { "/OpenAction", "Subtype/Link/Rect", "/Action", "/AA", "/JavaScript", "/JS", "/Launch", "/SubmitForm" };
        public readonly static string[] INDICATORS_TWO = { "/GoTo", "/Encrypt", "/Names" };
        public readonly static string[] INDICATORS_THREE = { "/URI" };     
    }
}
