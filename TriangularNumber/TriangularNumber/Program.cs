using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangularNumber {
	class Program {
		static void Main(string[] args) {
			int n;
			if (args.Length == 0) {
				Console.Write("Enter the n-th term of triangular number: ");
				n = int.Parse(Console.ReadLine());
				Console.WriteLine(recurTriNum(n));			// Choose the function
				// listTriNum(n);
			} else if (args[0] == ("-list")) {
				try {
					listTriNum(int.Parse(args[1]));
				} catch (FormatException) {
					Console.WriteLine("Argument: " + args[1] + " must be an integer.");
					Environment.Exit(1);
				}
			} else if (args[0] == ("-index")) {
				try {
					n = int.Parse(args[1]);
					Console.WriteLine(recurTriNum(n));
				} catch (FormatException) {
					Console.WriteLine("Argument: " + args[1] + " must be an integer.");
					Environment.Exit(1);
				}
			} else {// if (args[0]==("-help")) {
				Console.WriteLine("\nFind the triangular number.\n   TriangularNumber ([-index|-list] indexNumber) | [-help]");
				Console.WriteLine("\n   -index indexNumber     Print out the indexNumber-th triangular number.");
				Console.WriteLine("\n   -list indexNumber      Print out the whole list of triangular numbers less than the content of indexNumber.");
				Console.WriteLine("\n   -help                  Print out this help screen.\n");
			}
		}

		public static int recurTriNum(int input) {
			if (input == 1) {
				return 1;
			} else if (input > 1) {
				return input + recurTriNum(input - 1);
			} else {
				return 0;	// If the index is less than 1 it will give 0.
			}
		}

		public static void listTriNum(int input) {
			for (int i = 1; i <= input; i++) {
				Console.Write(recurTriNum(i) + " ");
				if (i % 10 == 0) {
					Console.WriteLine();
				}
			}
			Console.WriteLine();
		}
	}
}
