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
        public ObservableCollection<GetSeriesFromList> SeriesList { get; set; } =
           new ObservableCollection<GetSeriesFromList>();


        public override async Task OnNavigatedToAsync(
         object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var movieservice = new MovieService();
            var movieGroups = await movieservice.GetTopratedMoviesAsync();
            foreach (var item in movieGroups.results)
            {
                MovieList.Add(item);
            }
            var seriesservice = new SeriesService();
            var seriesGroups = await seriesservice.GetTopSeriesAsync();
            foreach (var item in seriesGroups.results)
            {
                SeriesList.Add(item);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToDetailsMovies(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }
        public void NavigateToDetailsSeries(int movieID)
        {
            NavigationService.Navigate(typeof(SeriesDetailPage), movieID);
        }
        
        public void NavigateToSearch(string searchstring)
        {
            NavigationService.Navigate(typeof(SeriesDetailPage), searchstring);
        }
    }
}
