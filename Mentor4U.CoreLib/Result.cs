using System;

namespace Mentor4U.CoreLib;

public class Result<T> where T : class
{
    public bool Success { get; }
    public Exception? Exception { get; }
    public T? Value { get; }

    private Result(bool success, Exception? exception, T? value) =>
        (Success, Exception, Value) = (success, exception, value);

    public Result(T value)
        : this(true, null, value)
    {
        //ignore
    }

    public Result(Exception exception)
        : this(false, exception, null)
    {
        //ignore
    }
}