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
    public class EntryViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        private IComputerStorage _computerStorage;

        public EntryViewModel(IComputerStorage computerStorage,
                                IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _computerStorage = computerStorage;
        }


        private Computer comp;
        private MvxCommand addComputer;

        public Computer Comp => comp ?? (comp = new Computer());

        public MvxCommand AddComputer => addComputer ?? (addComputer = new MvxCommand(() =>
        {
            if(comp == null)
            {
                throw new Exception("Cannot add Null computer");
            }
            _computerStorage.AddComputer(comp);
            _navigationService.Navigate<ListViewModel>();
        }));
        
    }
}
