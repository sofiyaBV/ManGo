﻿using System.Windows;

namespace ManGo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
            Close();
        }
    }
}
