﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            var flag = true;

            foreach (var para in input)
            {
                switch (para)
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(para);
                        break;
                    case '}':
                        if (!stack.Any())
                        {
                            flag = false;
                        }
                        else if (stack.Pop() != '{')
                        {
                            flag = false;
                        }
                        break;
                    case ')':
                        if (!stack.Any())
                        {
                            flag = false;
                        }
                        else if (stack.Pop() != '(')
                        {
                            flag = false;
                        }
                        break;
                    case ']':
                        if (!stack.Any())
                        {
                            flag = false;
                        }
                        else if (stack.Pop() != '[')
                        {
                            flag = false;
                        }
                        break;
                }
                if (!flag)
                {
                    break;
                }
              
            }
            Console.WriteLine(flag ? "YES" : "NO");
        }
    }
}