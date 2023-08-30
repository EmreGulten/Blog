using Blog.Core.Entities;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace Blog.Entity.Entities
{
    public class Article : EntityBase
    {

        public Article()
        {
            Tags = new List<Tag>();
            Comments = new List<Comment>();
            Keywords = new List<Keyword>();
            AlternateUrls = new List<AlternateUrl>();
            RelatedPosts = new List<RelatedPost>();
            IsPublished = false;
            IsFeatured = false;
            MetaRobots = "index, follow";
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public int TagId { get; set; }
        public List<Tag> Tags { get; set; }
        public int Views { get; set; }

        public string Slug { get; set; }

        public Guid? CommentId { get; set; }
        public List<Comment> Comments { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }

        public string SlugGet
        {
            get { return GenerateSlug(Slug); }
        }

        public string MetaTitle
        {
            get { return GenerateMetaTitle(Title); }
        }

        public string MetaDescription
        {
            get { return GenerateMetaDescription(Content); }
        }

        public List<Keyword> Keywords { get; set; }
        public string? CanonicalUrl { get; set; }
        public string? MetaRobots { get; set; }
        public string? OpenGraphImage { get; set; }
        public string? TwitterCardImage { get; set; }

        public List<AlternateUrl> AlternateUrls { get; set; }
        public List<RelatedPost> RelatedPosts { get; set; }

       
        public void IncreaseViews()
        {
            Views++;
        }

        public void AddComment(string commenter, string text)
        {
            Comments.Add(new Comment { UserName = commenter, CommentText = text, CommentDate = DateTime.Now });
        }

        public void AddAlternateUrl(AlternateUrl url)
        {
            AlternateUrls.Add(url);
        }

        public void AddRelatedPost(RelatedPost url)
        {
            RelatedPosts.Add(url);
        }

        public void AddKeyword(Keyword keyword)
        {
            Keywords.Add(keyword);
        }

        private string GenerateSlug(string input)
        {
            // Küçük harfe çevirme ve gereksiz boşlukları kaldırma
            input = input.ToLower().Trim();

            // Unicode karakterleri Latin harflerine dönüştürme
            input = RemoveDiacritics(input);

            // Boşlukları tire ile değiştirme
            input = Regex.Replace(input, @"\s+", "-");

            // Sadece harf, rakam, tire ve alt çizgi karakterlerini kabul etme
            input = Regex.Replace(input, @"[^a-z0-9\-_]", "");

            // Ardışık tireleri temizleme
            input = Regex.Replace(input, @"\-{2,}", "-");

            // Max 100 karaktere sınırlama
            if (input.Length > 100)
            {
                input = input.Substring(0, 100);
            }

            // Eğer son karakter tire ise kaldırma
            input = input.TrimEnd('-');

            return input;
        }

        // Unicode karakterleri Latin harflerine dönüştürme işlemi için yardımcı metod
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

    public class Tag : IEntityBase
    {
        public int Id { get; set; }
        public string Tags { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }

    public class Keyword : IEntityBase
    {
        public int Id { get; set; }
        public string Keywords { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }

    public class AlternateUrl : IEntityBase
    {
        public int Id { get; set; }
        public string AlternateUrls { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }

    public class RelatedPost : IEntityBase
    {
        public int Id { get; set; }
        public string RelatedPosts { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }


}

