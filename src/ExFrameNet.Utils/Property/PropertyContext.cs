using ExFrameNet.Utils.System;
using System;
using System.Linq.Expressions;

namespace ExFrameNet.Utils.Property
{

    public class PropertyContext
    {
        public string Name { get; protected set; }
        public object ClassInstance { get;}
        public object Value => PropertyReader(ClassInstance);
        internal Func<object, object> PropertyReader { get; }

        internal PropertyContext(string name, object classInstance, Func<object,object> propertyreader)
        {
            Name = name;
            ClassInstance = classInstance;
            PropertyReader = propertyreader;
        }

        internal PropertyContext(PropertyContext old)
            : this(old.Name, old.ClassInstance, old.PropertyReader)
        {

        }
    }

    public class PropertyContext<T, TProperty> : PropertyContext
        where T : class
    {

        public new T ClassInstance { get; }
        public new TProperty Value => PropertyReader(ClassInstance);
        internal new Func<T, TProperty> PropertyReader { get; }

        internal PropertyContext(T classInstance, Expression<Func<T, TProperty>> propertySelector)
            : this(classInstance, propertySelector.GetPropertyName(), propertySelector.Compile())
        {
        }

        internal PropertyContext(T classInstance, string propertyName, Func<T, TProperty> propertyReader)
            :base(propertyName, classInstance, v => propertyReader((T)v))
        {
            ClassInstance = classInstance;
            PropertyReader = propertyReader;
        }

        public PropertyContext(PropertyContext<T, TProperty> property)
            : base(property)
        {
            Name = property.Name;
            ClassInstance = property.ClassInstance;
            PropertyReader = property.PropertyReader;
        }
    }
}