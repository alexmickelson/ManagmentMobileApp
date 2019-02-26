using Managment.Core.Model;
using Managment.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Core.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        private IComputerStorage _computerStorage;
        private ObservableCollection<Computer> computers;
        private MvxCommand clickCommand;
        private MvxCommand reset;

        public ListViewModel(IComputerStorage computerStorage,
                                IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _computerStorage = computerStorage;
            AsyncConstructor();

            
            //var comp = new Computer();
            //comp.IPAddress = "1";
            //comp.Location = "1";
            //_computerStorage.AddComputer(comp);

            //comp = new Computer();
            //comp.IPAddress = "2";
            //comp.Location = "2";
            //_computerStorage.AddComputer(comp);

        }

        public async Task AsyncConstructor()
        {
            computers = await _computerStorage.getAllComputers();
            //computers = new List<Computer>();
            RaisePropertyChanged(nameof(Computers));

            selectedOption = SortModel.SerialNumber;
            Sort();
        }


        public ObservableCollection<Computer> Computers { get => computers; }

        public MvxCommand ClickCommand => clickCommand ?? (clickCommand = new MvxCommand(() =>
        {
            _navigationService.Navigate<EntryViewModel>();
        }));

        public MvxCommand Reset => reset ?? (reset = new MvxCommand(() =>
        {
            _computerStorage.Reset();
            _navigationService.Navigate<ListViewModel>();
        }));

        public IEnumerable<SortModel> SortOptions
        {
            get {
                return Enum.GetValues(typeof(SortModel)).Cast<SortModel>();
            }
        }

        private SortModel selectedOption;
        public SortModel SelectedOption {
            get
            {
                return selectedOption;
            }
            set
            {
                selectedOption = value;
                Sort();
                RaisePropertyChanged(() => computers);
            }
        }
        
        public void Sort ()
        {
            switch (SelectedOption)
            {
                case SortModel.SerialNumber:
                    computers = new ObservableCollection<Computer>(computers.OrderBy(x => x.SerialNumber).ToList());
                    break;

                case SortModel.MAC:
                    computers = new ObservableCollection<Computer>(computers.OrderBy(x => x.MAC).ToList());
                    break;

                case SortModel.IPAddress:
                    computers = new ObservableCollection<Computer>(computers.OrderBy(x => x.IPAddress).ToList());
                    break;

                case SortModel.Location:
                    computers = new ObservableCollection<Computer>(computers.OrderBy(x => x.Location).ToList());
                    break;

            }

            RaisePropertyChanged(() => Computers);
        }

        private MvxCommand<Computer> update;
        public  MvxCommand<Computer> Update => update ?? (update = new MvxCommand<Computer>(onUpdate));

        void onUpdate(Computer c)
        {

            _navigationService.Navigate(typeof(UpdateViewModel), c);
        }

    }
}
