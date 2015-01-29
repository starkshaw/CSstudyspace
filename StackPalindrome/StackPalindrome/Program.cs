using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackPalindrome {
	class Program {
		static void Main(string[] args) {
			Stack<char> obj = new Stack<char>();
			string input = string.Empty, output = string.Empty, StackOutput = string.Empty;
			Console.Write("Enter a sentence to check if it is palindrome: ");
			input = Console.ReadLine();
			for (int i = input.Length - 1; i >= 0; i--) {
				obj.Push(input[i]);		// Allocate a character in C# string type is similar to an array
			}
			// Reverse the input string and store to the output
			for (int i = input.Length - 1; i >= 0; i--) {
				output = output + input[i];
			}
			// Store the stack to a string
			for (int i = 0; i < input.Length; i++) {
				StackOutput = StackOutput + obj.Pop();
			}
			// Compare
			if (output == StackOutput) {
				Console.WriteLine("\"{0}\" is a palindrome.", input);
			} else {
				Console.WriteLine("\"{0}\" is not a palindrome.", input);
			}
		}
	}
}
