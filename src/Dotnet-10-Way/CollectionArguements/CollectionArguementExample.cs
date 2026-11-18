using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet_10_Way.CollectionArguements;

internal class CollectionArguementExample
{
    public static HashSet<string> CreateHashSet()
    {
        var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "apple",
            "banana",
            "APPLE"
        };
        return set;
    }
}
