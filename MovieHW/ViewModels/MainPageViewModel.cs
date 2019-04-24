using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using MovieHW.Models;
using MovieHW.Services;
using MovieHW.Views;

namespace MovieHW.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<GetMovieFromList> MovieList { get; set; } =
           new ObservableCollection<GetMovieFromList>();


        public override async Task OnNavigatedToAsync(
         object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new MovieService();
            var movieGroups = await service.GetTopratedMoviesAsync();
            foreach (var item in movieGroups.results)
            {
                MovieList.Add(item);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToDetails(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }

    }
}
