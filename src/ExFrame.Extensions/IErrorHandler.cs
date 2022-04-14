using System;

namespace ExFrame.Extensions
{
    public interface IErrorHandler
    {
        void HandleException(Exception ex);
    }
}