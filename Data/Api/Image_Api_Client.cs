using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManGo.Data.Api
{
    class Image_Api_Client
    {
        static string baseUrl = "https://mangapoisk.me/";//Ссылка на сайт
        HtmlDocument doc = new HtmlDocument();//дока

        public Image_Api_Client() { }
        /// <summary>
        /// Асинхронно загружает HTML-страницу по заданному базовому URL.
        /// </summary>
        /// <param name="baseUrl">Базовый URL для загрузки.</param>
        /// <returns>Строка, представляющая HTML-содержимое страницы.</returns>
        /// <exception cref="Exception"></exception>
        async Task<string> DownloadHtmlAsync(string baseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception("Ошибка при загрузке HTML-страницы.");
                }
            }
        }
        /// <summary>
        /// Метод для загрузки данных изображений,названия,ссылки с веб-страницы и формирования списка объектов ImageSourse.
        /// Для загрузки категорий : обновления топ манги, Горячие новинки, Популярное, Недавно на сайте
        /// </summary>
        /// <returns>Список объектов ImageSourse, представляющих изображения с веб-страницы.</returns>
        public async Task<List<ImageSourse>> Loaded_TopManga()
        {
            string html = await DownloadHtmlAsync(baseUrl);
            doc.LoadHtml(html);
            List<ImageSourse> imagesData = new List<ImageSourse>();

            IEnumerable<HtmlNode> cardNodes = doc.DocumentNode.SelectNodes(".//div[@class='card shadow mb-4 w-36 snap-start']");
            if (cardNodes != null)
            {

                foreach (var cardNode in cardNodes)
                {
                    HtmlNode linkNode = cardNode.SelectSingleNode(".//a[@class='text-surface-900-50-token']");

                    if (linkNode != null)
                    {
                        string href = linkNode.GetAttributeValue("href", "");
                        string text = linkNode.InnerText;

                        string hrefValue = cardNode.SelectSingleNode(".//a")?.GetAttributeValue("href", "");
                        string title = cardNode.SelectSingleNode(".//a")?.GetAttributeValue("title", "");
                        string imageUrl = cardNode.SelectSingleNode(".//img[@class='rounded-container-token preload']")?.GetAttributeValue("src", "");

                        if (!string.IsNullOrWhiteSpace(imageUrl) && !string.IsNullOrWhiteSpace(hrefValue))
                        {
                            Uri fullUri;
                            if (Uri.TryCreate(new Uri(baseUrl), imageUrl, out fullUri))
                            {
                                imagesData.Add(new ImageSourse
                                {
                                    ImageURL = fullUri.AbsoluteUri,
                                    Text = title,
                                    Href = hrefValue,
                                    Hrefchapter = href,
                                    Chapert = text
                                });
                            }
                        }
                    }
                }
            }

            return imagesData;
        }
        /// <summary>
        /// Асинхронный метод для загрузки данных изображения для раздела "Manga Day" с веб-страницы.
        /// </summary>
        /// <returns>Объект ImageSourse, представляющий изображение и связанные с ним данные.</returns>
        public async Task<ImageSourse> Loaded_MangaDay()
        {
            string html = await DownloadHtmlAsync(baseUrl);
            doc.LoadHtml(html);
            ImageSourse imageSourse = new ImageSourse();
            IEnumerable<HtmlNode> cardNodes = doc.DocumentNode.SelectNodes(".//div[@class='card shadow-lg mb-4 mx-auto max-w-sm']");
            if (cardNodes != null)
            {
                foreach (var cardNode in cardNodes)
                {
                    string hrefValue = cardNode.SelectSingleNode(".//a")?.GetAttributeValue("href", "");
                    string title = cardNode.SelectSingleNode(".//a")?.GetAttributeValue("title", "");
                    string imageUrl = cardNode.SelectSingleNode(".//img[@class='rounded-container-token preload w-full']")?.GetAttributeValue("src", "");
                    if (!string.IsNullOrWhiteSpace(imageUrl) && !string.IsNullOrWhiteSpace(hrefValue))
                    {
                        Uri fullUri;
                        if (Uri.TryCreate(new Uri(baseUrl), imageUrl, out fullUri))
                        {
                          //  imageSourse = new ImageSourse( fullUri.AbsoluteUri,title,hrefValue);
                        }
                    }
                }
            }
            return imageSourse;
        }
    }
}
