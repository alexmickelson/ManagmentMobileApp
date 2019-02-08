using Managment.Core.Model;
using Managment.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Core.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        private IComputerStorage _computerStorage;
        private List<Computer> computers;
        private MvxCommand clickCommand;
        private MvxCommand reset;

        public ListViewModel(IComputerStorage computerStorage,
                                IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _computerStorage = computerStorage;
            computers = _computerStorage.getAllComputers();
            
            //var comp = new Computer();
            //comp.IPAddress = "1";
            //comp.Location = "1";
            //_computerStorage.AddComputer(comp);

            //comp = new Computer();
            //comp.IPAddress = "2";
            //comp.Location = "2";
            //_computerStorage.AddComputer(comp);

        }

        public List<Computer> Comp { get => computers; }

        public MvxCommand ClickCommand => clickCommand ?? (clickCommand = new MvxCommand(() =>
        {
            _navigationService.Navigate<EntryViewModel>();
        }));

        public MvxCommand Reset => reset ?? (reset = new MvxCommand(() =>
        {
            _computerStorage.Reset();
            _navigationService.Navigate<ListViewModel>();
        }));


    }
}
