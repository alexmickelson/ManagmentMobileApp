using FluentAssertions;
using Managment.Core.Model;
using Managment.Core.Services;
using MvvmCross.Tests;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Managment.Test
{
    class ComputerStorageTests : MvxIoCSupportingTest
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

        //1
        [Test]
        public void AddComputer_AddingComuter_AddsOneComputer()
        {
            var comp = new ComputerStorage();
            var count = comp.getAllComputers().Count;
            comp.AddComputer(new Computer());

            count.Should().Be(comp.getAllComputers().Count - 1);
        }

        //2
        [Test]
        public void ComputerStorage_ReadsNullFile_ThrowsException()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(path, "computers.json");
            File.WriteAllText(filePath, "not a json");

            try
            {
                new ComputerStorage();
                Assert.Fail();
            }
            catch (JsonReaderException)
            {
                return;
            }
            
        }

        //3
        [Test]
        public void AddComputer_AddNullComputer_ThrowsException()
        {
            var comp = new ComputerStorage();
            try
            {
                comp.AddComputer(null);
                Assert.Fail();
            } catch (Exception)
            {
                return;
            }

        }

        //4
        [Test]
        public void Reset_DeletesFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(path, "computers.json");
            File.WriteAllText(filePath, "");
            var comp = new ComputerStorage();
            comp.Reset();

            if (!File.Exists(filePath))
            {
                return;

            }
            Assert.Fail();
        }
    }
}
