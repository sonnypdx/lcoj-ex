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

public class ExprNode {
public uint ? LeftParen = null;
public uint ? RightParen = null;
public ExprNode ParentNode = null;
public ExprNode ChildNode = null;
public ExprNode NextNode = null;
public string Letters = null;
}

public class Solution {
public static void Main(string[] args) {
    string[] inputs = {
     "()())()",
     "()(()()"
    };
    IList < string > result = Solution.RemoveInvalidParentheses(s1);
    foreach(string s in result) {
     System.Console.WriteLine(s);
    }
    System.Console.WriteLine("Press any key to exit ...");
    System.Console.Read();
}

public ExprNode ParseString(string s) {
    //if (i == 0 && s[i] == ')') continue;

    int LeftParenCount = 0, RightParentCount = 0;
    ExprNode topNode = null;
    ParentNd prevNode = null;
    //ExprNode currNode = null;
    for (int i = 0; i < s.Length; i++) {
     // we always start a new node with open parentheses
     if (s[i] == '(') {
        ExprNode newNd = new ExprNode() {
         LeftParen = i
        };
        // if we do not have a previous node that means we are the topNode
        if (prevNode == null) {
         topNode = newNd;
        }
        // if the previous node already has a closing parentheses
        // then we are next to the prev node.
        else if (prevNode.RightParen.HasValue) {
         prevNode.NextNode = newNd;
        }
        // otherwise we are new child node
        else {
         prevNode.ChildNode = newNd;
        }
        prevNode = newNd;
     } 
     else if (s[i] == ')') {
        if (prevNode == null) {
         // since we do not want to analyze anything yet
         // and just build the expression tree
         ExprNode newNd = new ExprNode() {
            RightParen = i
         };
         prevNode = newNd;
        } else if (!prevNode.RightParen.HasValue) {
         prevNode.RightParen = i;
         prevNode = newNd;
        } else {
         ExprNode newNd = new ExprNode() {
            RightParen = i
         };
         prevNode = newNd;
        }
     }
    }    
}

public static IList < string > RemoveInvalidParentheses(string s) {
    IList < string > result = new List < string > ();
    char[] temp1 = new char[s.Length];
    // forward iteration, ()())()
    int op = 0, cp = 0, count = 0;
    for (int i = 0; i < s.Length; i++) {
     if (s[i] == '(') {
        // if we are balanced then increment op
        if (op == cp) {
         op++;
         temp1[count] = s[i];
         count++;
        }
     } else if (s[i] == ')') {
        // we must be op > cp
        if (op > cp) {
         op--;
         temp1[count] = s[i];
         count++;
        }
     } else {
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
    for (int i = s.Length - 1; i >= 0; i--) {
     if (s[i] == ')') {
        // if we are balanced then increment op
        if (cp == op) {
         cp++;
         temp2[s.Length - 1 - count] = s[i];
         count++;
        }
     } else if (s[i] == '(') {
        // we must be cp > op
        if (cp > op) {
         cp--;
         temp2[s.Length - 1 - count] = s[i];
         count++;
        }
     } else {
        temp2[s.Length - 1 - count] = s[i];
        count++;
     }
    }
    // store the result
    if (count > 0) result.Add(new string(temp2, s.Length - count, count));
        
    return result;
}
}