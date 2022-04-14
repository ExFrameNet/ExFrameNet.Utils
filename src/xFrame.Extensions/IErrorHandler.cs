using System;

namespace exFrame.Extensions
{
    public interface IErrorHandler
    {
        void HandleException(Exception ex);
    }
}