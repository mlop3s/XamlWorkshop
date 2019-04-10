using NUnit.Framework;
using XamlWorkshop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace XamlWorkshop.ViewModel.Tests
{
    [TestFixture()]
    public class MainViewModelTests
    {
        [Test()]
        public void WhateverTest()
        {
            var mockedView = Mock.Of<IMainView>();
            var vm = new MainViewModel(mockedView);
            bool fired = false;

            vm.PropertyChanged += (sender, evt) =>
            {
                if (evt.PropertyName == "Age")
                    fired = true;
            };

            vm.Age = 100;

            Assert.That(fired, Is.True);
        }

        [Test]
        public void ShouldRaiseErrorChanged()
        {
            var mockedView = Mock.Of<IMainView>();
            var vm = new MainViewModel(mockedView);
            bool fired = false;

            vm.ErrorsChanged += (sender, evt) =>
            {
                if (evt.PropertyName == "Age")
                {
                    fired = true;
                }
            };

            vm.Age = 200;

            Assert.That(fired, Is.True);
        }

        [Test]
        public void ShouldShowMessageIfAgeIsGreaterThanTen()
        {
            var mockedView = Mock.Of<IMainView>();
            var mockedService = new Mock<IMessageService>();
            var vm = new MainViewModel(mockedView);
            vm.Service = mockedService.Object;

            vm.Age = 11;

            vm.CancelCommand.Execute(null);
            

            mockedService.Verify(s => s.ShowWhatever(It.IsAny<string>()), Times.AtMostOnce);
        }

        [Test]
        [SetCulture("de-DE")]
        public void ShouldNotShowMessageIfAgeIsLessThanEleven()
        {
            var mockedView = Mock.Of<IMainView>();
            var mockedService = new Mock<IMessageService>();
            var vm = new MainViewModel(mockedView);
            vm.Service = mockedService.Object;

            vm.Age = 9;

            vm.CancelCommand.Execute(null);

            mockedService.Verify(s => s.ShowWhatever(It.IsAny<string>()), Times.Never);
        }
    }
}
