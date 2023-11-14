using ManGo.Data.Api;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        private void SP_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var stackPanel = sender as WrapPanel;
            if (stackPanel != null)
            {
                ImageSource imageSource = ((Image)stackPanel.Children[0]).Source;
                string text1 = ((TextBlock)stackPanel.Children[1]).Text;
                string text2 = ((TextBlock)stackPanel.Children[2]).Text;

                ToolTip toolTip = new ToolTip();
                toolTip.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435334"));

                toolTip.Placement = PlacementMode.Right;

                // Создаем StackPanel для содержимого ToolTip
                StackPanel toolTipContentStackPanel = new StackPanel();
                toolTipContentStackPanel.MaxWidth = 300; // Максимальная ширина ToolTip
                toolTipContentStackPanel.Orientation = Orientation.Horizontal;

                // Добавляем изображение
                toolTipContentStackPanel.Children.Add(new Image { Source = imageSource, Width = 50, Height = 80 });

                // Добавляем текст справа от изображения
                StackPanel textStackPanel = new StackPanel();
                textStackPanel.Margin = new Thickness(5, 0, 0, 0); // Отступ слева
                textStackPanel.VerticalAlignment = VerticalAlignment.Center;

                TextBlock textBlock1 = new TextBlock { Text = text1, TextWrapping = TextWrapping.Wrap, MaxWidth = 130 };
                TextBlock textBlock2 = new TextBlock { Text = text2, TextWrapping = TextWrapping.Wrap };

                textStackPanel.Children.Add(textBlock1);
                textStackPanel.Children.Add(textBlock2);

                toolTipContentStackPanel.Children.Add(textStackPanel);

                // Устанавливаем StackPanel в качестве содержимого ToolTip
                toolTip.Content = toolTipContentStackPanel;
                // Устанавливаем ToolTip для StackPanel
                stackPanel.ToolTip = toolTip;
            }
        
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
