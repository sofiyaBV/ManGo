using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManGo.Presentation
{
    /// <summary>
    /// Логика взаимодействия для MySPUserControl.xaml
    /// </summary>
    public partial class MySPUserControl : UserControl
    {
        public MySPUserControl()
        {
            InitializeComponent();
        }

        private double previousWidth;

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width != previousWidth)
            {
                double newWidth;
                if (I_User.Visibility != Visibility.Collapsed)
                { newWidth  = e.NewSize.Width - 320; }
                else { newWidth  = e.NewSize.Width - 410; }

                tb_search.Width = newWidth;
                previousWidth = e.NewSize.Width;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.ContextMenu.IsOpen = true;
        }

        private void ManGo_Click(object sender, MouseButtonEventArgs e)
        {
            // Получаем родительское окно
            Window parentWindow = Window.GetWindow(this);

            // Проверяем, что родительское окно существует и является окном
            if (parentWindow is Window)
            {
                HomeWindow homePage = new HomeWindow();

                if (parentWindow.WindowState == WindowState.Maximized)
                {
                    homePage.WindowState = WindowState.Maximized;
                }
                else
                {
                    homePage.Width = parentWindow.Width;
                    homePage.Height = parentWindow.Height;
                    homePage.Left = parentWindow.Left;
                    homePage.Top = parentWindow.Top;
                }

                homePage.Show();

                // Закрываем родительское окно
                parentWindow.Close();
            }
        }
    }
}
