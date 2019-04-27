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
    public class EpisodeViewModel : ViewModelBase
    {
        private Episode _episode;
        public Episode Episode
        {
            get { return _episode; }
            set { Set(ref _episode, value); }
        }
        
        public ObservableCollection<SeriesCrew> EpisodeCrew { get; set; } =
            new ObservableCollection<SeriesCrew>();
        public ObservableCollection<GuestStar> GuestStar { get; set; } =
            new ObservableCollection<GuestStar>();

        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var listId = (List<int>)parameter;

            var service = new SeriesService();
            Episode = await service.GetEpisodeAsync(listId[0], listId[1], listId[2]);

            foreach (var item in Episode.crew)
            {
                EpisodeCrew.Add(item);
            }
            foreach (var item in Episode.guest_stars)
            {
                GuestStar.Add(item);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToCast(int personID)
        {
            NavigationService.Navigate(typeof(PersonPage), personID);
        }
        public void NavigateToGuesttar(int personID)
        {
            NavigationService.Navigate(typeof(PersonPage), personID);
        }
    
    }
}
