using FluentAssertions;
using Managment.Core.Model;
using Managment.Core.Services;
using Managment.Core.ViewModels;
using Moq;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using NUnit.Framework;

namespace Managment.Test
{
    class EntryViewModelTests : MvxIoCSupportingTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        //5
        [Test]
        public void AddComputer_AddComputerAddsComputer()
        {
            bool result = false;
            var comp = new Mock<IComputerStorage>();
            var nav = new Mock<IMvxNavigationService>();
            comp.Setup(c => c.AddComputer(It.IsAny<Computer>())).Callback(() => result = true);
            //nav.Setup(n => n.Navigate<ListViewModel>(new Mock<IMvxViewModel<ListViewModel>>().Object, null, new Mock<IMvxBundle>().Object)).Callback(() => result = true);
            var viewModel = new EntryViewModel(comp.Object, nav.Object);
            viewModel.AddComputer.Execute(this);
            result.Should().BeTrue();
        }
    }
}
