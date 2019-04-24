using MovieHW.Models;
using MovieHW.Services;
using MovieHW.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace MovieHW.ViewModels
{
    public class PersonPageViewModel : ViewModelBase
    {
        private Actor _actor;
        public Actor Actor
        {
            get { return _actor; }
            set { Set(ref _actor, value); }
        }

        public override async Task OnNavigatedToAsync(
           object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var personID = (int)parameter;

            var service = new PersonService();
            Actor = await service.GetPersonAsync(personID);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToDetails(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }
    }
}
