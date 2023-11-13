using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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
                            string hrefValue = cardNode.SelectSingleNode(".//a")?.GetAttributeValue("href", "");
                            string title = cardNode.SelectSingleNode(".//a")?.GetAttributeValue("title", "");

                              string imageUrl = cardNode.SelectSingleNode(".//img[@class='rounded-container-token preload']")?.GetAttributeValue("src", "");

                            if (!string.IsNullOrWhiteSpace(imageUrl) && !string.IsNullOrWhiteSpace(hrefValue))
                            {

                                Uri fullUri;
                                if (Uri.TryCreate(new Uri(baseUrl), imageUrl, out fullUri))
                                {
                                    string decodedTitle = WebUtility.HtmlDecode(title);
                                    imagesData.Add(new ImageSourse
                                    {
                                        ImageURL = fullUri.AbsoluteUri,
                                        Text = decodedTitle,
                                        Href = hrefValue
                                    });
                                }
                            }
                        }
                    }
                
            return imagesData;
        }


    }
}
