using ManGo.Data.Api;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ManGo
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void LV_popular_manga_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void SP_top_manga_update_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private async void Home_Loaded(object sender, RoutedEventArgs e)
        {
            Image_Api_Client image_Api_Client = new Image_Api_Client();
            List<ImageSourse> result_popular_manga = await image_Api_Client.Loaded_TopManga();

            for (int i = 0; i < 20 && i < result_popular_manga.Count; i++)
            {
                LV_top_manga_update.Items.Add(result_popular_manga[i]);
            }
            for (int i = 20; i < 40 && i < result_popular_manga.Count; i++)
            {
                LV_hot_new_items.Items.Add(result_popular_manga[i]);
            }
            for (int i = 40; i < 60 && i < result_popular_manga.Count; i++)
            {
                LV_popular.Items.Add(result_popular_manga[i]);
            }
            for (int i = 60; i < 80 && i < result_popular_manga.Count; i++)
            {
                LV_recently_on_the_site.Items.Add(result_popular_manga[i]);
            }
        }


        //private double previousWidth;

        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    if (e.NewSize.Width != previousWidth)
        //    {
        //        double newWidth;
        //        if (I_User.Visibility != Visibility.Collapsed)
        //        { newWidth  = e.NewSize.Width - 320; }
        //        else { newWidth  = e.NewSize.Width - 410; }

        //        tb_search.Width = newWidth;
        //        previousWidth = e.NewSize.Width;

        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Button button = (Button)sender;
        //    button.ContextMenu.IsOpen = true;
        //}
    }
}
