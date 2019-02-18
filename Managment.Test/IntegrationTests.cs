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
using System.IO;
using System.Text;

namespace Managment.Test
{
    class IntegrationTests : MvxIoCSupportingTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(path, "computers.json");
            File.Delete(filePath);
        }
        [TearDown]
        public void TearDown()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(path, "computers.json");
            File.Delete(filePath);
        }

        //7
        [Test]
        public void EntryAndListVM_CallsAddComputerAndGetComputer()
        {
            bool result1 = false;
            bool result2 = false;
            var comp = new Mock<IComputerStorage>();
            var nav = new Mock<IMvxNavigationService>();

            comp.Setup(c => c.AddComputer(It.IsAny<Computer>())).Callback(() => result1 = true);
            comp.Setup(c => c.getAllComputers()).Callback(() => result2 = true);

            var listViewModel = new ListViewModel(comp.Object, nav.Object);
            var entryViewModel = new EntryViewModel(comp.Object, nav.Object);

            entryViewModel.AddComputer.Execute(this);
            listViewModel.ClickCommand.Execute(this);

            if (result1)
                if (result2)
                    return;

            Assert.Fail();
        }

        //8
        [Test]
        public void EntryAndListVM_AddsComputerAndGetsComputers()
        {
            var comp = new ComputerStorage();
            var nav = new Mock<IMvxNavigationService>();
            
            var entryViewModel = new EntryViewModel(comp, nav.Object);
            var c = entryViewModel.Comp;
            entryViewModel.AddComputer.Execute(this);

            var listViewModel = new ListViewModel(comp, nav.Object);

            listViewModel.Comp.Should().NotBeEmpty();
        }

        //9
        [Test]
        public void EntryAndListVM_AddsComputerAndRDeletesFile()
        {
            var comp = new ComputerStorage();
            var nav = new Mock<IMvxNavigationService>();

            var entryViewModel = new EntryViewModel(comp, nav.Object);
            var c = entryViewModel.Comp;
            entryViewModel.AddComputer.Execute(this);

            var listViewModel = new ListViewModel(comp, nav.Object);

            listViewModel.Reset.Execute();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(path, "computers.json");
            if (!File.Exists(filePath))
            {
                return;

            }

            Assert.Fail();
        }       

        //10
        [Test]
        public void EntryAndListVM_AddsComputerAndResets()
        {
            var comp = new ComputerStorage();
            var nav = new Mock<IMvxNavigationService>();

            var entryViewModel = new EntryViewModel(comp, nav.Object);
            var c = entryViewModel.Comp;
            entryViewModel.AddComputer.Execute(this);

            var listViewModel = new ListViewModel(comp, nav.Object);

            listViewModel.Reset.Execute();
            listViewModel = new ListViewModel(comp, nav.Object);
            listViewModel.Comp.Should().NotBeEmpty();
        }



    }
}
