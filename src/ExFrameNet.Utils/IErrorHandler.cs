namespace ExFrameNet.Utils;

/// <summary>
/// Interface for errorhandling used by several async actions
/// </summary>
public interface IErrorHandler
{

    /// <summary>
    /// Called when an error occurred
    /// </summary>
    /// <param name="ex">The exception that is occured</param>
    void HandleException(Exception ex);
}
