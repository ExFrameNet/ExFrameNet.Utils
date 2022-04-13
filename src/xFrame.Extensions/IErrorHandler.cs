using System;

namespace xFrame.Extensions
{
    public interface IErrorHandler
    {
        void HandleException(Exception ex)
    }
}