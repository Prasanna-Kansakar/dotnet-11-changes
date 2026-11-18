using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet_11_Changes.LabeledLoops;

internal class LabeledLoopExample
{
    public static void Run()
    {
        int[][] batches =
        [
            [1, 2],
            [3, -1],
            [4, 5]
        ];

        allBatches: foreach (int[] batch in batches)
        {
            foreach (int value in batch)
            {
                if (value < 0)
                {
                    Console.WriteLine($"Validation failed for {value}.");
                    break allBatches;
                }

                Console.WriteLine($"Processed {value}.");
            }
        }
    }
}
