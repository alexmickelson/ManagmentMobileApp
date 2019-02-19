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

        //2
        [Test]
        public void ListViewModelConstructor_SortsOnSerialNumber()
        {
            var comp = new SqlStorageService();
            var nav = new Mock<IMvxNavigationService>();

            var c = new Computer();
            c.SerialNumber = "b";
            var a = comp.AddComputer(c).Result;

            c = new Computer();
            c.SerialNumber = "a";
            a = comp.AddComputer(c).Result;

            var viewModel = new ListViewModel(comp, nav.Object);

            var b = viewModel.Comp.ToArray()[0].SerialNumber.Should().Be("a");
        }

        //6
        [Test]
        public void AddComputer_AddComputerAddsComputer()
        {
            bool result = false;
            var comp = new Mock<IComputerStorage>();
            var nav = new Mock<IMvxNavigationService>();

            comp.Setup(c => c.getAllComputers()).ReturnsAsync(new List<Computer>());
            comp.Setup(c => c.Reset()).Callback(() => result = true);

            var viewModel = new ListViewModel(comp.Object, nav.Object);

            viewModel.Reset.Execute(this);
            result.Should().BeTrue();
        }

        //7
        [Test]
        public void Sort_SelectingOptionSorts()
        {
            var comp = new SqlStorageService();
            var z = comp.Reset().Result;
            var nav = new Mock<IMvxNavigationService>();

            var c = new Computer();
            c.SerialNumber = "b";
            c.Location = "a";
            var a = comp.AddComputer(c).Result;

            c = new Computer();
            c.SerialNumber = "a";
            c.Location = "b";
            a = comp.AddComputer(c).Result;

            var viewModel = new ListViewModel(comp, nav.Object);
            try
            {
                viewModel.SelectedOption = SortModel.Location;

            } catch(Exception e)
            {

            }

            var b = viewModel.Comp.ToArray()[0].Location.Should().Be("a");
        }
    }
}
