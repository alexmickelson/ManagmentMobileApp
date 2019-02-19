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
using System.Threading.Tasks;

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
        public async Task ListViewModelConstructor_SortsOnSerialNumber()
        {
            var comp = new SqlStorageService();
            await comp.Reset();
            var nav = new Mock<IMvxNavigationService>();

            var c = new Computer();
            c.SerialNumber = "b";
            var a = await comp.AddComputer(c);

            c = new Computer();
            c.SerialNumber = "a";
            a = await comp.AddComputer(c);

            var viewModel = new ListViewModel(comp, nav.Object);
            await viewModel.AsyncConstructor();

            var b = viewModel.Computers.ToArray()[0];
            b.SerialNumber.Should().Be("a");
            await comp.Reset();
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

            var b = viewModel.Computers.ToArray()[0].Location.Should().Be("a");
        }
    }
}
