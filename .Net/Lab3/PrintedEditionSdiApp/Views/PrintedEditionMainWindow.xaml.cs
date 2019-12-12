﻿using System.Windows;
using PrintedEditionSdiApp.ViewModels;

namespace PrintedEditionSdiApp.Views
{
    public partial class PrintedEditionMainWindow : Window
    {
        public PrintedEditionMainWindow()
        {
            InitializeComponent();
            DataContext = PrintedEditionViewModel.GetInstance();
        }
    }
}