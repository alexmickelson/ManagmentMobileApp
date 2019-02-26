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
    public class UpdateViewModel : MvxViewModel<Computer>
    {
        private IMvxNavigationService _navigationService;
        private IComputerStorage _computerStorage;

        public UpdateViewModel(IComputerStorage computerStorage,
                                IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _computerStorage = computerStorage;
        }

        
        private Computer comp;
        public Computer Comp => comp ?? (comp = new Computer());

        private MvxCommand updateComputer;
        public MvxCommand UpdateComputer => updateComputer ?? (updateComputer = new MvxCommand(() =>
        {
            if (comp == null)
            {
                throw new Exception("Cannot add Null computer");
            }
            _computerStorage.UpdateComputer(comp);
            _navigationService.Navigate<ListViewModel>();
        }));

        public override void Prepare(Computer parameter)
        {
            comp = parameter;
        }
    }
}
