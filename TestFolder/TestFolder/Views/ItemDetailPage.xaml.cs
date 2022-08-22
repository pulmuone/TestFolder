using System.ComponentModel;
using TestFolder.ViewModels;
using Xamarin.Forms;

namespace TestFolder.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}