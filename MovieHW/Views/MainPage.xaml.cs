using System;
using MovieHW.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using MovieHW.Models;

namespace MovieHW.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        private void TopRated_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movieHeader = (GetMovieFromList)e.ClickedItem;
            ViewModel.NavigateToDetails(movieHeader.id);

        }
    }
}