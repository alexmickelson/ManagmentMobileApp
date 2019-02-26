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
using System.Collections.ObjectModel;
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

            var b = viewModel.Computers[0];
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

            comp.Setup(c => c.getAllComputers()).ReturnsAsync(new ObservableCollection<Computer>());
            comp.Setup(c => c.Reset()).Callback(() => result = true);

            var viewModel = new ListViewModel(comp.Object, nav.Object);

            viewModel.Reset.Execute(this);
            result.Should().BeTrue();
        }

        //7
        [Test]
        public async Task Sort_SelectingOptionSorts_Location()
        {
            var comp = new SqlStorageService();
            await comp.Reset();

            var c = new Computer();
            c.SerialNumber = "b";
            c.Location = "a";
            await comp.AddComputer(c);

            c = new Computer();
            c.SerialNumber = "a";
            c.Location = "b";
            await comp.AddComputer(c);

            var nav = new Mock<IMvxNavigationService>();
            var viewModel = new ListViewModel(comp, nav.Object);

            System.Threading.Thread.Sleep(100);
            try
            {
                viewModel.SelectedOption = SortModel.Location;

            } catch(Exception e)
            {

            }

            var b = viewModel.Computers[0].Location.Should().Be("a");
        }

        //15
        [Test]
        public async Task Sort_SelectingOptionSorts_IPAddress()
        {
            var comp = new SqlStorageService();
            await comp.Reset();
            var nav = new Mock<IMvxNavigationService>();

            var c = new Computer();
            c.IPAddress = "b";
            await comp.AddComputer(c);

            c = new Computer();
            c.IPAddress = "a";
            await comp.AddComputer(c);

            var viewModel = new ListViewModel(comp, nav.Object);
            try
            {
                viewModel.SelectedOption = SortModel.IPAddress;

            }
            catch (Exception e)
            {

            }

            var b = viewModel.Computers[0].IPAddress.Should().Be("a");
        }
        
    }
}
