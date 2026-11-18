using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dotnet_11_Changes.Unions;

internal class CustomUnionExample
{
    public static void Print(Error error)
    {
        switch (error)
        {
            case string message:
                Console.WriteLine(message);
                break;
            case string[] messages:
                Console.WriteLine(string.Join(Environment.NewLine, messages));
                break;
        }
    }

    public static void Run()
    {
        Error singleError = new("A single error.");
        Error multipleErrors = new(["First error.", "Second error."]);

        Print(singleError);
        Print(multipleErrors);
    }

    //public union Error(string, string[]);

    [Union]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Error : IUnion
    {

        private readonly object _BackingField;

        public readonly object Value => _BackingField;

        public Error(string value)
        {
            this._BackingField = value.Trim();
        }
        
        public Error(string[] value)
        {
            this._BackingField = value;
        }
    }
}
