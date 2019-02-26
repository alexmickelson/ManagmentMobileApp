using FluentAssertions;
using Managment.Core.Model;
using Managment.Core.Services;
using Managment.Core.ViewModels;
using Moq;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Managment.Test
{
    class UpdateViewModelTests : MvxIoCSupportingTest
    {
        private Mock<IMvxNavigationService> navigate;
        private Mock<IComputerStorage> storage;

        [SetUp]
        public void Setup()
        {
            base.Setup();
            navigate = new Mock<IMvxNavigationService>();
            storage = new Mock<IComputerStorage>();
        }

        [TearDown]
        public void Teardown()
        {

        }

        //12
        [Test]
        public void UpdateComputer_UpdatesComputer_callsUpdateOnStorate()
        {
            bool works = false;
            storage.Setup(s => s.UpdateComputer(It.IsAny<Computer>())).Callback(() => works = true);

            var updateVM = new UpdateViewModel(storage.Object, navigate.Object);
            var c = updateVM.Comp;

            updateVM.UpdateComputer.Execute(this);

            works.Should().BeTrue();
        }

        //13
        [Test]
        public void UpdateComputer_UpdatesComputer_ThrowsErrorWhenUpdateingNullComputer()
        {

            var updateVM = new UpdateViewModel(storage.Object, navigate.Object);

            try
            {
                updateVM.UpdateComputer.Execute();
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }

        //14
        [Test]
        public void UpdateComputer_NavigatesFromPage_CallsNavigateOnUpdate()
        {
            bool works = false;
            navigate.Setup(s => s.Navigate<ListViewModel>(null, It.IsAny<CancellationToken>())).Callback(() => works = true);

            var updateVM = new UpdateViewModel(storage.Object, navigate.Object);
            var c = updateVM.Comp;

            updateVM.UpdateComputer.Execute(this);

            works.Should().BeTrue();
        }
    }

}
