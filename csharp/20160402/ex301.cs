/**
Exercise: #301 - Remove Invalid Parentheses
Description: Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.
Note: The input string may contain letters other than the parentheses ( and ).
Examples:
"()())()" -> ["()()()", "(())()"]
"(a)())()" -> ["(a)()()", "(a())()"]
")(" -> [""]
Source: https://leetcode.com/problems/remove-invalid-parentheses/
*/

using System;
using System.Text;
using System.Collections.Generic;

public class Solution {
  public static void Main(string[] args)
  {
      string s1 = "()())()";
      IList<string> result = Solution.RemoveInvalidParentheses(s1);
      foreach (string s in result) {
        System.Console.WriteLine(s);
      }
      System.Console.WriteLine("Press any key to exit ...");
      System.Console.Read();
  }

  public static IList<string> RemoveInvalidParentheses(string s) {
      IList<string> result = new List<string>();
      char[] temp1 = new char[s.Length];
      // forward iteration, ()())()
      int op = 0, cp = 0, count = 0;
      for (int i=0; i < s.Length; i++) {
        if(s[i] == '(') {
          // if we are balanced then increment op
          if (op == cp) {
            op++;
            temp1[count] = s[i];
            count++;
          }
        }
        else if (s[i] == ')') {
          // we must be op > cp
          if (op > cp) {
            op--;
            temp1[count] = s[i];
            count++;
          }
        }
        else {
            temp1[count] = s[i];
          count++;
        }
      }
      // store the result
      if (count > 0) result.Add(new string(temp1, 0, count));

      // backward iteration
      op = 0;
      cp = 0;
      count = 0;
      char[] temp2 = new char[s.Length];
      for (int i=s.Length-1; i >= 0; i--) {
        if(s[i] == ')') {
          // if we are balanced then increment op
          if (cp == op) {
            cp++;
            temp2[s.Length-1-count] = s[i];
            count++;
          }
        }
        else if (s[i] == '(') {
          // we must be cp > op
          if (cp > op) {
            cp--;
            temp2[s.Length-1-count] = s[i];
            count++;
          }
        }
        else {
          temp2[s.Length-1-count] = s[i];
          count++;
        }
      }
      // store the result
      if (count > 0) result.Add(new string(temp2, s.Length-count, count));

      return result;
  }
}
