﻿using MovieHW.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieHW.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        //Onclickre a ViewModel milyen függvénye
        private void Movies_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movieHeader = (GetMovieFromList)e.ClickedItem;
            ViewModel.NavigateToDetailsMovies(movieHeader.id);

        }
        private void Series_ItemClick(object sender, ItemClickEventArgs e)
        {
            var seriesHeader = (GetSeriesFromList)e.ClickedItem;
            ViewModel.NavigateToDetailsSeries(seriesHeader.id);

        }
    }
}
