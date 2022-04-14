using ExFrameNet.Utils.Tests.Mocks;
using Xunit;
using FluentAssertions;
using ExFrame.Extensions.Property;

namespace ExFrameNet.Utils.Tests
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

        [Fact]
        public void PropertyExtension_Transform()
        {
            //Arrange
            var propClass = new ClassWithproperties()
            {
                StringProperty = "15"
            };

            //Act
            var sut = propClass.Property(x => x.StringProperty)
                .Transform(x => int.Parse(x));
            //Assert
            sut.Value.Should().Be(15);
            sut.Value.Should().BeOfType(typeof(int));
        }
    }
}