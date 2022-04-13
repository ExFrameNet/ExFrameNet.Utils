using System;
using xFrame.Extensions.Tests.Mocks;
using xFrame.Extensions.Property;
using Xunit;
using FluentAssertions;

namespace xFrame.Extensions.Tests
{
    public class PropertyExtensionTests
    {
        [Fact]
        public void PropertyExtension_Create()
        {
            //Arrange 
            var propClass = new ClassWithproperties();
            //Act 
            var sut = propClass.Property(x => x.StringProperty);
            //Assert
            sut.Name.Should().Be(nameof(propClass.StringProperty));
            sut.ClassInstance.Should().BeSameAs(propClass);
            sut.Value.Should().Be(propClass.StringProperty);
        }
    }
}
