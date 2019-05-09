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
using Windows.UI.Xaml.Controls;

namespace MovieHW.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        //Kiírandó listák
        public ObservableCollection<GetMovieFromList> MovieList { get; set; } =
           new ObservableCollection<GetMovieFromList>();
        public ObservableCollection<GetSeriesFromList> SeriesList { get; set; } =
           new ObservableCollection<GetSeriesFromList>();

        //Ha az oldalra érkezik
        public override async Task OnNavigatedToAsync(
         object parameter, NavigationMode mode, IDictionary<string, object> state)
        {

       
            //Movie és Serie szervíz elérése, adatok letöltéséhez
            //Top-okat adja mindkét kategóriában vissza
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


        //OnClick függvények

        //Film részletező oldalra navigál
        public void NavigateToDetailsMovies(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }

        //Sorozat részletező oldalra navigál
        public void NavigateToDetailsSeries(int movieID)
        {
            NavigationService.Navigate(typeof(SeriesDetailPage), movieID);
        }
        
        //Keresés oldalra navigál
        public void NavigateToSearch(string searchstring)
        {
            NavigationService.Navigate(typeof(SearchPage), searchstring);
        }
    }
}
