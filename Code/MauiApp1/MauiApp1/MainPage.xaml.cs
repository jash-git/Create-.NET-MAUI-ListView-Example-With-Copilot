using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1
{
    public class Item
    {
        public string Name { get; set; }
        public string Detail { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var items = new List<Item>
            {
                new Item { Name = "Item 1", Detail = "This is item 1" },
                new Item { Name = "Item 2", Detail = "This is item 2" },
                new Item { Name = "Item 3", Detail = "This is item 3" }
            };

            MyCollectionView.ItemsSource = items;
        }
    }

}
