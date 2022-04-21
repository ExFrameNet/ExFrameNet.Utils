using ExFrameNet.Utils.Tests.Mocks;
using Xunit;
using FluentAssertions;
using ExFrameNet.Utils.Property;

namespace ExFrameNet.Utils.Tests
{
    public class PropertyExtensionChangedTest
    {

        [Fact]
        public void PropertyExtension_Changed_Subscribe_Executes_OnPropewrtyChanged()
        {
            //Arrange 
            var notifyClass = new ClassWithNotifyPropertyChanged();
            // Act
            var sut = notifyClass.Property(x => x.Name)
                    .Changed()
                    .Subscribe(notifyClass.CalledWhenChanged);
            notifyClass.Name = "TestName";
            // Assert
            notifyClass.Changed.Should().Be(true);
        }
    }
}
