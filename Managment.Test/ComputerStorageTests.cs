using FluentAssertions;
using Managment.Core.Model;
using Managment.Core.Services;
using MvvmCross.Tests;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Test
{
    class ComputerStorageTests : MvxIoCSupportingTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //var filePath = Path.Combine(path, "computers.db3");
            ////File.Delete(filePath);
        }
        [TearDown]
        public void TearDown()
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //var filePath = Path.Combine(path, "computers.db3");
            //File.Delete(filePath);
        }

        //1
        [Test]
        public void AddComputer_AddingComuter_AddsOneComputer()
        {
            var comp = new SqlStorageService();
            var count = comp.getAllComputers().Result.Count;
            var res = comp.AddComputer(new Computer()).Result;

            count.Should().Be(comp.getAllComputers().Result.Count - 1);
        }
        

        //3
        [Test]
        public void AddComputer_AddNullComputer_ThrowsException()
        {
            var comp = new SqlStorageService();
            try
            {
                var a = comp.AddComputer(null).Result;
                Assert.Fail();
            } catch (Exception)
            {
                comp = null;
                return;
            }

        }

        //4
        [Test]
        public async Task Reset_DeletesComputers()
        {
            var comp = new SqlStorageService();
            await comp.AddComputer(new Computer());
            await  comp.Reset();

            if (!comp.getAllComputers().Result.Any())
            {
                return;

            }
            Assert.Fail();

        }

        //16
        [Test]
        public async Task AddComputer_AddsIndexAutomatically()
        {
            var comp = new SqlStorageService();
            await comp.Reset();
            await comp.AddComputer(new Computer());

            var c = await comp.getAllComputers();
            c[0].Id.Should().NotBe(null);

        }
    }
}
