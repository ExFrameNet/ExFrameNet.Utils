using ExFrameNet.Utils.Tests.Mocks;
using Xunit;
using FluentAssertions;
using ExFrame.Extensions.Property;

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
                    .OnChange()
                    .Subscribe(notifyClass.CalledWhenChanged);
            notifyClass.Name = "TestName";
            // Assert
            notifyClass.Changed.Should().Be(true);
        }
    }
}
