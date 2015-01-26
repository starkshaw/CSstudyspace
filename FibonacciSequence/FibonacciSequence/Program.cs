using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci {
	class Program {
		static void Main(string[] args) {
			int n = 1;
			if (args.Length == 0) {
				Console.Write("Enter the index of Fibonacci number: ");
				n = int.Parse(Console.ReadLine());
				Console.WriteLine(fibGetIndex(n));
			}else if (args[0]=="-list") {
			try {
				printFibList(int.Parse(args[1]));
			} catch (FormatException) {
				Console.WriteLine("Argument: " + args[1] + " must be an integer.");
				Environment.Exit(1);
			}
		} else if (args[0]=="-index") {
			try {
				Console.WriteLine(fibGetIndex(int.Parse(args[1])));
			} catch (FormatException) {
				Console.WriteLine("Argument: " + args[1] + " must be an integer.");
				Environment.Exit(1);
			}
		} else {
			Console.WriteLine("\nDetermine the Fibonacci sequence.\n   FibonacciSequence ([-index|-list] indexNumber) | [-help]");
			Console.WriteLine("\n\t-index indexNumber     Print out the indexNumber-th Fibonacci number.");
			Console.WriteLine("\n\t-list indexNumber      Print out the whole list of Fibonacci numbers less than the content of indexNumber.");
			Console.WriteLine("\n\t-help                  Print out this help screen.\n");
		}
		}

		public static long fibGetIndex(int n) {
			if (n == 1) {
				return 1;
			} else if (n == 2) {
				return 1;
			} else {
				return fibGetIndex(n - 1) + fibGetIndex(n - 2);
			}
		}

		public static void printFibList(int n) {
			Console.ForegroundColor = ConsoleColor.Red;
			for (int i = 1; i <= n; i++) {
				if (i % 10 != 0) {
					Console.Write("{0} ",fibGetIndex(i));
				} else {
					Console.WriteLine(fibGetIndex(i));
				}
			}
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
