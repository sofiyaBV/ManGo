using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                tb_search.Width =  e.NewSize.Width - 320; ;
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
