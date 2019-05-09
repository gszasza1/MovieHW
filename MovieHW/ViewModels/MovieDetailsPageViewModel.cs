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
    class MovieDetailsPageViewModel : ViewModelBase
    {

        //Megjelenítendő adatok objekt-jei
        private MovieDetails _movie;
        public MovieDetails Movie
        {
            get { return _movie; }
            set { Set(ref _movie, value); }
        }
        private MoviePeople _moviepeole;
        public MoviePeople MoviePeople
        {
            get { return _moviepeole; }
            set { Set(ref _moviepeole, value); }
        }
        public ObservableCollection<Crew> MovieCrew { get; set; } =
            new ObservableCollection<Crew>();
        public ObservableCollection<Cast> MovieCast { get; set; } =
            new ObservableCollection<Cast>();
        public ObservableCollection<GetMovieFromList> MovieList { get; set; } =
         new ObservableCollection<GetMovieFromList>();


        //Beérkezésre mi történik
        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var movieID = (int)parameter;

            //Film részletes adatainak letöltése, és listába kötése
            var service = new MovieService();
            Movie = await service.GetExactMovieAsync(movieID);
            var movieGroups = await service.GetRecommendationMoviesAsync(movieID);
            foreach (var item in movieGroups.results)
            {
                MovieList.Add(item);
            }
            
            //Filmhez tartozó emberek betöltése és listába kötése
            var personService = new PersonService();
            MoviePeople = await personService.GetMoviePeopleAsync(movieID);
            foreach (var item in MoviePeople.crew)
            {
                MovieCrew.Add(item);
            }
            foreach (var item in MoviePeople.cast)
            {
                MovieCast.Add(item);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //OnClick
        //Embert részletező oldalra navigál
        public void NavigateToDetailsPerson(int personID)
        {
            NavigationService.Navigate(typeof(PersonPage), personID);
        }
        //Filmet részletező oldalra navigál
        public void NavigateToDetailsMovie(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }
    }
}
