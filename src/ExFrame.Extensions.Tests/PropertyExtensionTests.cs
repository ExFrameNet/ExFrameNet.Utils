using ExFrame.Extensions.Tests.Mocks;
using Xunit;
using FluentAssertions;
using ExFrame.Extensions.Property;

namespace ExFrame.Extensions.Tests
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
