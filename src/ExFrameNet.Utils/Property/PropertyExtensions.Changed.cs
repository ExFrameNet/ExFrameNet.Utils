using ExFrameNet.Utils.Property;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExFrame.Extensions.Property
{
    public static partial class PropertyExtensions
    {
        public static PropertyChangedContext<T, TProperty> Changed<T, TProperty>(this PropertyContext<T, TProperty> ctx)
            where T : class, INotifyPropertyChanged
        {
            var newCtx =  new PropertyChangedContext<T, TProperty>(ctx);
            ctx.ClassInstance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != ctx.Name)
                    return;

                foreach (var act in newCtx.ChangedActions)
                {
                    act(ctx.ClassInstance, ctx.Value);
                }
            };
            return newCtx;
        }
        

        public static PropertyChangedContext<T, TProperty> Subscribe<T, TProperty>(this PropertyChangedContext<T, TProperty> ctx, Action<TProperty> callBack)
            where T : class, INotifyPropertyChanged
        {
            ctx.ChangedActions.Add((_, v) => callBack(v));
            return ctx;
        }

        public static PropertyChangedContext<T, TProperty> Subscribe<T, TProperty>(this PropertyChangedContext<T, TProperty> ctx, Action<T,TProperty> callBack)
            where T : class, INotifyPropertyChanged
        {
            ctx.ChangedActions.Add(callBack);
            return ctx;
        }
    }
}
