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
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace MovieHW.ViewModels
{
    public class SeriesDetailspageViewModel : ViewModelBase
    {
        //Megjelenítendő adatok 
        private SeriesDetails _series;
        public SeriesDetails Series
        {
            get { return _series; }
            set { Set(ref _series, value); }
        }

        int seriesID;

        public ObservableCollection<GetSeriesFromList>SeriesList { get; set; } =
         new ObservableCollection<GetSeriesFromList>();

        public ObservableCollection<Season> SeasonList { get; set; } =
         new ObservableCollection<Season>();

        //Beérkezésre mi történjen
        public override async Task OnNavigatedToAsync(
         object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            seriesID = (int)parameter;

            //Sorozat adatainak lekérése
            var seriesService = new SeriesService();
            Series = await seriesService.GetEcaxtSeriesAsync(seriesID);
            var SeriesGroups = await seriesService.GetRecommendedSeriesAsync(seriesID);
            foreach (var item in SeriesGroups.results)
            {
                SeriesList.Add(item);
            }
            foreach (var item in Series.seasons)
            {
                SeasonList.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //OnClick
        //Sorozat oldalra navigál
        public void NavigateToDetailsSeries(int serieID)
        {
            
            NavigationService.Navigate(typeof(SeriesDetailPage), serieID);
        }

        //Sorozat évadaihoz navigál
        public void NavigateToDetailsEpisode(int seasonID)
        {
            List<int> idList = new List<int>();
            idList.Add(seriesID);
            idList.Add(seasonID);
            NavigationService.Navigate(typeof(SeasonPage), idList);
        }
    }
}
