namespace ManGo.Data.Api
{
    class ImageSourse
    {
        public string? ImageURL { get; set; }
        public string? Text { get; set; }
        public string? Href { get; set; }
        public ImageSourse() { }
        public ImageSourse(string? imageURL, string? text, string? href)
        {
            ImageURL=imageURL;
            Text=text;
            Href=href;
        }
    }
}
