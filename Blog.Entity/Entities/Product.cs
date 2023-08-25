using Blog.Core.Entities;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Blog.Entity.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            Category = new List<Category>();
            Tags = new List<string>();
            StockQuantity = 0;
            IsFeatured = false;
            RelatedProducts = new List<string>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public List<Category> Category { get; set; }
        public List<string> Tags { get; set; }
        public int StockQuantity { get; set; }
        public bool IsFeatured { get; set; }

        public string Slug
        {
            get { return GenerateSlug(Name); }
        }

        public string MetaTitle
        {
            get { return GenerateMetaTitle(Name); }
        }

        public string MetaDescription
        {
            get { return GenerateMetaDescription(Description); }
        }

        public string CanonicalUrl { get; set; }
        public string OpenGraphImage { get; set; }
        public string TwitterCardImage { get; set; }

        public List<string> RelatedProducts { get; set; }

        public void AddRelatedProduct(string productId)
        {
            RelatedProducts.Add(productId);
        }

        private string GenerateSlug(string input)
        {
            input = input.ToLower().Trim();
            input = RemoveDiacritics(input);
            input = Regex.Replace(input, @"\s+", "-");
            input = Regex.Replace(input, @"[^a-z0-9\-_]", "");
            input = Regex.Replace(input, @"\-{2,}", "-");
            if (input.Length > 100)
            {
                input = input.Substring(0, 100);
            }
            input = input.TrimEnd('-');
            return input;
        }

        private string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private string GenerateMetaTitle(string input)
        {
            const int maxLength = 70;
            return input.Length <= maxLength ? input : input.Substring(0, maxLength);
        }

        private string GenerateMetaDescription(string input)
        {
            const int maxLength = 160;
            return input.Length <= maxLength ? input : input.Substring(0, maxLength);
        }
    }
}
