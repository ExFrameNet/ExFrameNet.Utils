using System;
using System.Collections.Generic;
using System.Text;
using xFrame.Extensions.Tests.Mocks;
using xFrame.Extensions.Property;
using Xunit;
using FluentAssertions;

namespace xFrame.Extensions.Tests
{
    public class PropertyExtensionChangedTest
    {

        [Fact]
        public void PropertyExtension_Changed_Subscribe_Executes_OnPropewrtyChanged()
        {
            Action<string> act = x => x.Should().Be("");
            //Arrange 
            var notifyClass = new ClassWithNotifyPropertyChanged();
            // Act
            var sut = notifyClass.Property(x => x.Name)
                    .Changed()
                    .Subscribe(act);


            act.Should().
            // Assert
        }
    }
}
