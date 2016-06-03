/**
Exercise: #338 - Counting Bits
Description: Given a non negative integer number *num*.  For every numbers *i* in the range 0 *≤ i ≤ num* calculate the number of 1's in their binary representation and return them as an array.
Example: For num = 5, it should return [0, 1, 1, 2, 1, 2].
Source: https://leetcode.com/problems/counting-bits/
*/

public class Solution {
    public int[] CountBits(int num) {
        if (num < 0) return null;
        
        int[] result = new int[num+1];
        result[0] = 0; // 0 will be zero 1's
        
        // use the helper function all others
        for (int i = 1; i <= num; i++)
        {
            result[i] = _countBitsNumber(i);
        }
        
        return result;
    }
    
    // counts the no. of 1's in a given number
    public int _countBitsNumber(int num) {
        int count1s = 0;
        
        do {
            int logOf2 = (int)Math.Log(num, 2);
            if (logOf2 > 0) {
                // for each part of the number that is a power of 2
                // count 1
                count1s++;
                num -= (int)Math.Pow(2, logOf2);
            }
        } while (num > 1);
        
        // if it is an odd number, it should have 1 left in num
        // add 1 for that one
        if (num == 1) count1s++;
        
        return count1s;
    }
}


