using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet_11_Changes.Unions;

internal class GenericUnionExample
{
    public static void PrintResult<T>(Result<T> result)
    {
        switch (result)
        {
            case Ok<T> ok:
                Console.WriteLine($"Success: {ok.Value}");
                break;
            case Error error:
                Console.WriteLine($"Error: {error.Message}");
                break;
        }
    }

    public static void Run()
    {
        Result<int> success = new Ok<int>(42);
        Result<int> failure = new Error("Something went wrong.");

        PrintResult(success);
        PrintResult(failure);
    }

    public sealed record class Ok<T>(T Value);
    public sealed record class Error(string Message);
    public union Result<T>(Ok<T>, Error);
}
