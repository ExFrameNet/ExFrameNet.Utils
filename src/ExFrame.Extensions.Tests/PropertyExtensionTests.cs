using ExFrame.Extensions.Tests.Mocks;
using Xunit;
using FluentAssertions;
using ExFrame.Extensions.Property;
using System;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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

        [Theory]
        [MemberData(nameof(Data))]
        public void PropertyExtension_Transform(Func<object, object> transformer, object data, object expected)
        {
            //Arrange
            var propClass = new ClassWithNotifyPropertyChanged();
            object result = 0;
            //Act
            var sut = propClass.Property(x => x.Data)
                    .Transform(transformer)
                    .OnChange()
                    .Subscribe(x => result = x);
            propClass.Data = data;
            //Assert
            result.Should().Be(expected);
        }


        public static IEnumerable<object[]> Data()
        {
            yield return new object[]
            {
                (Func<object,object>)(x => int.Parse((string)x)),
                "15",
                15
            };
            yield return new object[]
            {
                (Func<object, object>)(x => double.Parse((string)x, CultureInfo.GetCultureInfo("en-US"))),
                "3.1415",
                3.1415
            };
        }
    }
}