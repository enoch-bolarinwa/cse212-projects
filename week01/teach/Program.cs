using System;
using System.Collections.Generic;


{
    // This function returns an array of doubles that are multiples of a given number.
    static double[] MultiplesOf(int start, int count)
    {
        // Step 1: Create an array of size 'count'
        double[] multiples = new double[count];

        // Step 2: Loop from 0 to count - 1
        for (int i = 0; i < count; i++)
        {
            // Step 3: For each position i, calculate start * (i + 1)
            // Step 4: Store the result in the array
            multiples[i] = start * (i + 1);
        }

        // Step 5: Return the filled array
        return multiples;
    }

    // testing Part 1
    
    {
        double[] result = MultiplesOf(6, 5); // Expected: {6, 12, 18, 24, 30}
        Console.WriteLine("MultiplesOf(6,5): " + string.Join(", ", result));
    }
}

    // function rotates list to the right by a given amount.
    static List<int> RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find the split point. This is data.Count - amount
        int splitPoint = data.Count - amount;

        // Step 2: Create a new list to hold the result
        List<int> rotated = new List<int>();

        // Step 3: Add the right part (from splitPoint to end) to the new list
        for (int i = splitPoint; i < data.Count; i++)
        {
            rotated.Add(data[i]);
        }

        // Step 4: Add the left part (from 0 to splitPoint - 1) to the new list
        for (int i = 0; i < splitPoint; i++)
        {
            rotated.Add(data[i]);
        }

        // Step 5: Return the rotated list
        return rotated;
    }

    // testing Part 2
    
    {
        List<int> data = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
        List<int> rotated = RotateListRight(data, 4); // Expected: {4, 5, 6, 7, 8, 9, 1, 2, 3}
        Console.WriteLine("RotateListRight by 5: " + string.Join(", ", rotated));

        rotated = RotateListRight(data, 4); // Expected: {6, 7, 8, 9, 1, 2, 3, 4, 5}
        Console.WriteLine("RotateListRight by 3: " + string.Join(", ", rotated));
    }

    
    {
        
    }


