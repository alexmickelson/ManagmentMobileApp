using Managment.Core.Services;
using Managment.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Core
{
    public class app : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            Mvx.IoCProvider.RegisterType<IComputerStorage, SqlStorageService>();

            RegisterAppStart<ListViewModel>();
        }
    }
}
