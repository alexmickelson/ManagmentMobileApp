using FluentAssertions;
using Managment.Core.Model;
using Managment.Core.Services;
using Managment.Core.ViewModels;
using Moq;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Test
{
    class ListViewModelTests : MvxIoCSupportingTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        //6
        [Test]
        public void AddComputer_AddComputerAddsComputer()
        {
            bool result = false;
            var comp = new Mock<IComputerStorage>();
            var nav = new Mock<IMvxNavigationService>();
            comp.Setup(c => c.Reset()).Callback(() => result = true);
            //nav.Setup(n => n.Navigate<ListViewModel>(new Mock<IMvxViewModel<ListViewModel>>().Object, null, new Mock<IMvxBundle>().Object)).Callback(() => result = true);
            var viewModel = new ListViewModel(comp.Object, nav.Object);
            viewModel.Reset.Execute(this);
            result.Should().BeTrue();
        }
    }
}
