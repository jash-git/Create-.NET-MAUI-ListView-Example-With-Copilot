using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using static Microsoft.Maui.Controls.VisualStateManager;

namespace MauiApp1
{
    public class Item
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> m_Items;
        public int m_intListCount = 0;
        public MainPage()
        {
            InitializeComponent();

            m_Items = new ObservableCollection<Item>
            {
                new Item { id =0, Name = "Item 0", Detail = "This is item 0" },
                new Item { id =1, Name = "Item 1", Detail = "This is item 1" },
                new Item { id =2, Name = "Item 2", Detail = "This is item 2" }
            };
            m_intListCount = 3;

            MyCollectionView.ItemsSource = m_Items;
        }

        public int m_intSelectedIndex = -1;
        private void MyCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault();
            m_intSelectedIndex = -1;
            if (selectedItem != null)
            {
                for (int i = 0; i < m_Items.Count; i++)
                {
                    
                    Item ItemBuf = (Item)selectedItem;//(MyCollectionView.SelectedItem);
                    if (m_Items[i].id == ItemBuf.id)
                    {
                        m_intSelectedIndex = i;
                        break;
                    }
                }
            }

        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Item ItemBuf = new Item { id = m_intListCount, Name = $"Item {m_intListCount}", Detail = $"This is item {m_intListCount}" };
            m_intListCount++;

            m_Items.Add(ItemBuf);
            MyCollectionView.SelectedItem=ItemBuf;
        }

        private void Del_Clicked(object sender, EventArgs e)
        {
            m_Items.RemoveAt(m_intSelectedIndex);
            MyCollectionView.SelectedItem = m_Items[0];
            MyCollectionView.ScrollTo(0);
        }

        private void Insert_Clicked(object sender, EventArgs e)
        {
            Item ItemBuf = new Item { id = m_intListCount, Name = $"Item {m_intListCount}", Detail = $"This is item {m_intListCount}" };
            m_intListCount++;

            m_Items.Insert(m_intSelectedIndex+1, ItemBuf);
            MyCollectionView.ScrollTo(m_intSelectedIndex + 1);
        }
    }

}
