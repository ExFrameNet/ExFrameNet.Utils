using System.ComponentModel;

namespace ExFrameNet.Utils.Property;

public static partial class PropertyExtensions
{
    public static PropertyChangedContext<T, TProperty> Changed<T, TProperty>(this PropertyContext<T, TProperty> ctx)
        where T : class, INotifyPropertyChanged
    {
        var newCtx = new PropertyChangedContext<T, TProperty>(ctx);
        ctx.ClassInstance.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName != ctx.Name)
            {
                return;
            }

            foreach (var act in newCtx._changedActions)
            {
                act(ctx.ClassInstance, ctx.Value);
            }
        };
        return newCtx;
    }


    public static PropertyChangedContext<T, TProperty> Subscribe<T, TProperty>(this PropertyChangedContext<T, TProperty> ctx, Action<TProperty> callBack)
        where T : class, INotifyPropertyChanged
    {
        ctx._changedActions.Add((_, v) => callBack(v));
        return ctx;
    }

    public static PropertyChangedContext<T, TProperty> Subscribe<T, TProperty>(this PropertyChangedContext<T, TProperty> ctx, Action<T, TProperty> callBack)
        where T : class, INotifyPropertyChanged
    {
        ctx._changedActions.Add(callBack);
        return ctx;
    }
}
