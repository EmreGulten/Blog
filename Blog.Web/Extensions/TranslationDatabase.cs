namespace Blog.Web.Extensions
{
    public class TranslationDatabase
    {
        private static Dictionary<string, Dictionary<string, string>> Translations = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "en", new Dictionary<string, string>
                {
                    { "orders", "Home" },
                    { "list", "Blog" }
                }
            },
            {
                "buca-dis-cephe-mantolama", new Dictionary<string, string>
                {
                    { "controller", "Home" },
                    { "action", "Blog" },
                    { "data", "buca-dis-cephe-mantolama" }
                }
            },
            {
                "dis-cephe-boyama", new Dictionary<string, string>
                {
                    { "controller", "Home" },
                    { "action", "Blog" },
                    { "data", "buca-dis-cephe-mantolama" }
                }
            },
        };
        public async Task<bool> Resolve(//string lang, 
            string value)
        {
            var normalizedValue = value.ToLowerInvariant();
            if (Translations.ContainsKey(normalizedValue))
            {
                return true;
            }

            return false;
        }
    }
}
