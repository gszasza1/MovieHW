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
    public class PersonPageViewModel : ViewModelBase
    {
        private Actor _actor;
        public Actor Actor
        {
            get { return _actor; }
            set { Set(ref _actor, value); }
        }
        private PersonCredit _personCredit;
        public PersonCredit PersonCredit
        {
            get { return _personCredit; }
            set { Set(ref _personCredit, value); }
        }
        public ObservableCollection<PersonCreditCast> PersonCast { get; set; } =
            new ObservableCollection<PersonCreditCast>();
        public ObservableCollection<PersonCreditCrew> PersonCrew { get; set; } =
            new ObservableCollection<PersonCreditCrew>();

        public override async Task OnNavigatedToAsync(
           object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var personID = (int)parameter;

            var service = new PersonService();
            Actor = await service.GetPersonAsync(personID);
            PersonCredit = await service.GetPersonCredditAsync(personID);
            foreach (var item in PersonCredit.crew)
            {
                PersonCrew.Add(item);
            }
            foreach (var item in PersonCredit.cast)
            {
                PersonCast.Add(item);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToDetails(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }
    }
}
