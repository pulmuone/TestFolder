using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestFolder.Models;
using TestFolder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestFolder.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}