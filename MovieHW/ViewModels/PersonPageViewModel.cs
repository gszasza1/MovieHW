using MovieHW.Models;
using MovieHW.Services;
using MovieHW.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

namespace MovieHW.ViewModels
{
    public class PersonPageViewModel : ViewModelBase
    {

        //Megjelenítendő adatokat tartalmazó objekt-ek
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

        //Beérkezésre mi történjen
        public override async Task OnNavigatedToAsync(
           object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var personID = (int)parameter;

            //Ember adatainak lekérése, és listába való kötése
            //Visszadja emberhez tartozó filmek,sorozatok-at, és az ember pontos adatait
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

        //OnClick
        //Filmet részletező oldalra navigál
        public void NavigateToDetails(int movieID)
        {
            NavigationService.Navigate(typeof(MovieDetailPage), movieID);
        }

        public async Task SavePersonImageAsync()
        {
            var personImage = Actor.profile_path;
            string json = JsonConvert.SerializeObject(Actor);
            string filename = Actor.name + ".txt";
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string asd = sampleFile.Path;
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, json);

        }

    }
}
