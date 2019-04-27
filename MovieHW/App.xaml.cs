﻿using System;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Template10.Mvvm;
using Template10.Common;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace MovieHW
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();
          

           
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // TODO: add your long-running task here
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}
