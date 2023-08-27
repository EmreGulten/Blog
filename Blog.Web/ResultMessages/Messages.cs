namespace Blog.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla geri alınmıştır.";
            }
        }
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla geri alınmıştır.";
            }
        }

        public static class Product
        {
            public static string Add(string productName)
            {
                return $"{productName} isimli ürün başarıyla eklenmiştir.";
            }
            public static string Update(string productName)
            {
                return $"{productName} isimli ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string productName)
            {
                return $"{productName} isimli ürün başarıyla silinmiştir.";
            }
            public static string UndoDelete(string productName)
            {
                return $"{productName} isimli ürün başarıyla geri alınmıştır.";
            }
        }

        public static class Comment
        {
            public static string Add(string userName)
            {
                return $"{userName} isimli kullanıcının yorumu başarıyla eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} isimli kullanıcının yorumu başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} isimli kullanıcının yorumu başarıyla silinmiştir.";
            }
            public static string UndoDelete(string userName)
            {
                return $"{userName} isimli kullanıcının yorumu başarıyla geri alınmıştır.";
            }
        }

        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla silinmiştir.";
            }
        }

        public static class Mail
        {
            public static string Send(string mail)
            {
                return $"{mail} email  başarıyla gönderilmiştir.";
            }
           
        }
    }
}
