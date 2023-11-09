using System.Windows;
using System.Windows.Controls;
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
