using MovieHW.Models;
using MovieHW.Services;
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

        public ObservableCollection<Episode> EpisodeList { get; set; } =
        new ObservableCollection<Episode>();

        public override async Task OnNavigatedToAsync(
         object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var seriesIDs = (List<int>)parameter;

            var seriesService = new SeriesService();
            Season = await seriesService.GetSeriesSeasonAsync(seriesIDs[0], seriesIDs[1]);
            foreach (var item in Season.episodes)
            {
                EpisodeList.Add(item);
            }
            
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

    }
}
