using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Web.Http;

namespace Edinburgh.WindowsClient
{
    public class FlickrSearchHelper
    {
        public static async Task<List<FlickrImage>> SearchAsync(string tag)
        {
            var client = new HttpClient();

            const string apiKey = "8ebe03ac6480c2c43aeaf1183eec0eb9";
            const string baseUri = "https://api.flickr.com/services/rest/?method=flickr.photos.search&safe_search=1&per_page=25&content_type=1&media=photos&";

            var url = string.Format(
                    baseUri +
                    "api_key={0}&" +
                    "page={1}&" +
                    "tags={2}",
                    apiKey, 1, tag);

            var list = new List<FlickrImage>();

            using (var response = await client.GetAsync(new Uri(url, UriKind.Absolute)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var contentxml = await response.Content.ReadAsStringAsync();
                    var xml = XElement.Parse(contentxml);
                    list = (from p in xml.DescendantsAndSelf("photo") select new FlickrImage(p)).ToList();
                }
            }
            return list;
        }
    }
}