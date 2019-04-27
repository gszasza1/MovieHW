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
    public class SeasonpageViewModel: ViewModelBase
    {

        private SeriesSeasons _season;
        public SeriesSeasons Season
        {
            get { return _season; }
            set { Set(ref _season, value); }
        }
        List<int> seriesID;

        public ObservableCollection<Episode> EpisodeList { get; set; } =
        new ObservableCollection<Episode>();

        public override async Task OnNavigatedToAsync(
         object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
             seriesID = (List<int>)parameter;

            var seriesService = new SeriesService();
            Season = await seriesService.GetSeriesSeasonAsync(seriesID[0], seriesID[1]);
            foreach (var item in Season.episodes)
            {
                EpisodeList.Add(item);
            }
            
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToEpisode(int episodeID)
        {
            seriesID.Add(episodeID);
            NavigationService.Navigate(typeof(EpisodePage), seriesID);
        }
    }
}
