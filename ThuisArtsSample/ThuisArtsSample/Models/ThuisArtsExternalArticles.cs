namespace ThuisArtsSample
{
    public class ThuisArtsExternalArticles
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }

        public ThuisArtsExternalRelated Related { get; set; }
    }
}