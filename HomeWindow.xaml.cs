using ManGo.Data.Api;
using System.Collections.Generic;
using System.Windows;

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
        private double previousWidth;

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

            ImageSourse imageSourse = await image_Api_Client.Loaded_MangaDay();
            if (result_popular_manga != null)
            {
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
            if(imageSourse != null)
            {
                SP_mangs_dey.DataContext = imageSourse;
            }
        }
    }
}
