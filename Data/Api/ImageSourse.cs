namespace ManGo.Data.Api
{
    class ImageSourse
    {
        public string? ImageURL { get; set; }
        public string? Text { get; set; }
        public string? Href { get; set; }
        public string? Hrefchapter {  get; set; }
        public string? Chapert {  get; set; }
        public ImageSourse() { }
        public ImageSourse(string? imageURL, string? text, string? href, string? hrefchapter , string? chapert)
        {
            ImageURL=imageURL;
            Text=text;
            Href=href;
            Hrefchapter = hrefchapter;
            Chapert=chapert;
        }
    }
}
