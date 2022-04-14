using System;

namespace ExFrameNet.Utils
{
    public interface IErrorHandler
    {
        void HandleException(Exception ex);
    }
}