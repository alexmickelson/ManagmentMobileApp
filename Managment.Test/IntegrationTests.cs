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
using System.Linq;

namespace Managment.Test
{
    class IntegrationTests : MvxIoCSupportingTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }
        

        //8
        [Test]
        public void EntryAndListVM_AddsComputerAndGetsComputers()
        {
            var comp = new SqlStorageService();
            var nav = new Mock<IMvxNavigationService>();
            
            var entryViewModel = new EntryViewModel(comp, nav.Object);
            var c = entryViewModel.Comp;
            entryViewModel.AddComputer.Execute(this);

            var listViewModel = new ListViewModel(comp, nav.Object);

            listViewModel.Comp.Should().NotBeEmpty();
        }

        //9
        [Test]
        public void EntryAndListVM_AddsComputerAndDeletesComputers()
        {
            var comp = new SqlStorageService();
            var nav = new Mock<IMvxNavigationService>();

            var entryViewModel = new EntryViewModel(comp, nav.Object);
            var c = entryViewModel.Comp;
            entryViewModel.AddComputer.Execute(this);

            var listViewModel = new ListViewModel(comp, nav.Object);

            listViewModel.Reset.Execute();
            
            if (!comp.getAllComputers().Result.Any())
            {
                return;
            }

            Assert.Fail();
        }

        //10
        [Test]
        public void EntryAndListVM_AddsComputerAndResets()
        {
            var comp = new SqlStorageService();
            var nav = new Mock<IMvxNavigationService>();

            var entryViewModel = new EntryViewModel(comp, nav.Object);
            var c = entryViewModel.Comp;
            entryViewModel.AddComputer.Execute(this);

            var listViewModel = new ListViewModel(comp, nav.Object);

            listViewModel.Reset.Execute();
            listViewModel = new ListViewModel(comp, nav.Object);

            listViewModel.Comp.Should().BeEmpty();
        }
        //10
        [Test]
        public void CanMakeListViewModel()
        {
            var comp = new SqlStorageService();
            var nav = new Mock<IMvxNavigationService>();

            var listViewModel = new ListViewModel(comp, nav.Object);
            var c = listViewModel.Comp;
            var cs = comp.getAllComputers().Result;
        }
        
    }
}
