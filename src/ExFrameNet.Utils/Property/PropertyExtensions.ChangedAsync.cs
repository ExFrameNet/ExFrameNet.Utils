using System.ComponentModel;

namespace ExFrameNet.Utils.Property;

public static partial class PropertyExtensions
{
    public static AsyncPropertyChangedContext<T, TProperty> OnChangeAsync<T, TProperty>(this PropertyContext<T, TProperty> ctx)
        where T : class, INotifyPropertyChanged
    {
        var newCtx = new AsyncPropertyChangedContext<T, TProperty>(ctx);
        ctx.ClassInstance.PropertyChanged += async (s, e) =>
        {
            if (e.PropertyName != ctx.Name)
            {
                return;
            }

            var tasks = newCtx._changedActions.Select(a => a(ctx.ClassInstance, ctx.Value));
            await Task.WhenAll(tasks);
        };
        return newCtx;
    }

    public static AsyncPropertyChangedContext<T, TProperty> SubscribeAsync<T, TProperty>(this AsyncPropertyChangedContext<T, TProperty> ctx, Func<TProperty, Task> callback)
        where T : class, INotifyPropertyChanged
    {
        ctx._changedActions.Add((_, v) => callback(v));
        return ctx;
    }


    public static AsyncPropertyChangedContext<T, TProperty> SubscribeAsync<T, TProperty>(this AsyncPropertyChangedContext<T, TProperty> ctx, Func<T, TProperty, Task> callback)
        where T : class, INotifyPropertyChanged
    {
        ctx._changedActions.Add(callback);
        return ctx;
    }
}
