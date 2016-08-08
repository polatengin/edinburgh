using System.Xml.Linq;

namespace Edinburgh.WindowsClient
{
    public class FlickrImage
    {
        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public FlickrImage(XElement element)
        {
            ImageUrl = string.Format("http://farm{0}.static.flickr.com/{1}/{2}_{3}_m.jpg", element.Attribute("farm").Value, element.Attribute("server").Value, element.Attribute("id").Value, element.Attribute("secret").Value);

            Title = element.Attribute("title").Value;
        }
    }
}