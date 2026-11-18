using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet_11_Changes.CollectionArguements;

internal class CollectionArguementExample
{
    public static HashSet<string> CreateHashSet() =>
        [with(StringComparer.OrdinalIgnoreCase), "apple", "banana", "APPLE"];
}
