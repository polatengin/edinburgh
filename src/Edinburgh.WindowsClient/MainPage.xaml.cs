using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Edinburgh.WindowsClient
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        ObservableCollection<FlickrImage> FlickrImageList = new ObservableCollection<FlickrImage>();

        private async void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pivotItem = e.AddedItems.FirstOrDefault() as PivotItem;

            var tag = pivotItem.Tag.ToString();

            var results = await FlickrSearchHelper.SearchAsync(tag);

            FlickrImageList.Clear();
            foreach (var item in results)
            {
                FlickrImageList.Add(item);
            }
        }
    }
}
