/*
Given a string s containing three types of brackets {}, () and []. 
Determine whether the Expression are balanced or not. An expression is balanced if 
each opening bracket has a corresponding closing bracket of the same type, the pairs 
are properly ordered and no bracket closes before its matching opening bracket. 
Balanced: "[()()]{}" → every opening bracket is closed in the correct order. 
Not balanced: "([{]})" → the ']' closes before the matching '{' is closed, breaking the 
nesting rule. Example: Input: s = "[{()}]" Output: true Explanation: All the brackets 
are well-formed. Input: s = "([{]})" Output: false Explanation: The expression is not 
balanced because there is a closing ']' before the closing '}'.

*/
using System;
using System.Collections.Generic;

class Program
{
    static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in s)
        {
            // Opening brackets

            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            // closing bracket
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                // No opening bracket available
                char top = stack.Pop();

                // check matching pair
                if ((ch == ')' && top != '(') ||
                   (ch == '}' && top != '{') ||
                   (ch == ']' && top != '['))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
    static void Main()
    {
        string s = "[{()}]";
        bool result = IsBalanced(s);
        Console.WriteLine(result);

    }
}