using MovieHW.Models;
using MovieHW.Services;
using MovieHW.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace MovieHW.ViewModels
{
    public class SearchPageViewModel:ViewModelBase
    {
        //Megjelenítendő adatokat tartalmazó objekt-ek
        public ObservableCollection<GetMovieFromList> MovieList { get; set; } =
          new ObservableCollection<GetMovieFromList>();
        public ObservableCollection<GetSeriesFromList> SeriesList { get; set; } =
           new ObservableCollection<GetSeriesFromList>();


        //Beérkezésre mi történjen
        public override async Task OnNavigatedToAsync(
        object parameter, NavigationMode mode, IDictionary<string, object> state)
        {

            var searchquery = (string)parameter;

            //Filmek és sorozatok keresése string alapján
            var movieservice = new MovieService();
            var seriesService = new SeriesService();
            var movieGroups = await movieservice.SearchMovieAsync(searchquery);
            foreach (var item in movieGroups.results)
            {
                MovieList.Add(item);
            }
            var seriesGroups = await seriesService.SearchSeriesAsync(searchquery);
            foreach (var item in seriesGroups.results)
            {
                SeriesList.Add(item);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //OnClick
        //Filmet részletező oldalra navigál
        public void NavigateToDetailsMovies(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }

        //Sorozatot részletező oldalra navigál
        public void NavigateToDetailsSeries(int movieID)
        {
            NavigationService.Navigate(typeof(SeriesDetailPage), movieID);
        }


    }
}
