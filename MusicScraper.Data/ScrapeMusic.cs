using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MusicScraper.Data
{
    public static class ScrapeMusic
    {
        public static List<MusicCd> Srape()
        {
            using var client = new HttpClient();
            string url = "https://mostlymusic.com/collections/featured-music";
            string html = client.GetStringAsync(url).Result;
            return ParseMusicHtml(html);
        }

        private static List<MusicCd> ParseMusicHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var musicCdDivs = document.QuerySelectorAll(".product-wrap");

            var musicCds = new List<MusicCd>();
            foreach (var div in musicCdDivs)
            {
                var musicCd = new MusicCd();

                var imageDiv = div.QuerySelector(".image-element__wrap");
                var imgTag = imageDiv.QuerySelector("img");
                var title = imgTag.Attributes["alt"].Value;
                if (title != null)
                {
                    musicCd.Title = title;
                }

                var image = imageDiv.QuerySelector("img").Attributes["src"].Value;
                if (image != null)
                {
                    musicCd.ImageLink = image;
                }

                var newBanner = div.QuerySelector(".new_banner.thumbnail_banner");
                if (newBanner != null)
                {
                    musicCd.IsNew = true;
                }

                var productLink = div.QuerySelector(".hidden-product-link").Attributes["href"].Value;
                productLink = "https://mostlymusic.com/" + productLink;
                if (productLink != null)
                {
                    musicCd.ProductLink = productLink;
                }

                musicCds.Add(musicCd);
            }
            return musicCds;
        }
    }
}

