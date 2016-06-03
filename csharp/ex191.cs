/**
Exercise: #191 - Number of 1 Bits
Description: Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).
Example: The 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.
Source: https://leetcode.com/problems/number-of-1-bits/
*/

using System;

public class Solution {

    public static void Main(string[] args)
    {
        Solution sln = new Solution();
        uint n = uint.MaxValue;
        System.Console.WriteLine("{0} Hamming Weight: {1}", n, sln.HammingWeight(n));
        System.Console.WriteLine("Press any key to exit ...");
        System.Console.Read();
    }

    public int HammingWeight(uint n) {
        if (n == 0) return 0;

        int hammWt = 0;

        do {
            uint logOf2 = (uint)Math.Log(n, 2);
            if (logOf2 > 0) {
                // for each part of the number that is a power of 2, count a 1
                hammWt++;
                n -= (uint)Math.Pow(2, logOf2);
            }
        } while (n > 1);

        // if it is an odd number, it should have 1 left in num
        // add 1 for that one
        if (n == 1) hammWt++;

        return hammWt;
    }
}
