using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edclid1 {
	class Program {
		static void Main(string[] args) {
			// Define variables
			int a, b, result, s;

			// Read in values for the two numbers (a and b)
			Console.Write("Enter first number:");
			a = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter second number:");
			b = Convert.ToInt32(Console.ReadLine());
			// Start a do{}while()loop
			do {
				// Test if a is bigger than b
				if (a > b) {
					// Do this if a is bigger than b
					s = a - b; // s is assigned the value of a minus b
					a = s; // set a to the value of s the reduced value
				} else {
					// otherwise do this if b is bigger than a
					s = b - a; // s is assigned the value of b minus a
					b = s; // set b to the value of s the reduced value
				}
				// repeat while both a and b are not zero
			} while ((a != 0) && (b != 0));
			// Done
			// if a is zero
			if (a == 0) {
				// Set result equal to b
				result = b;
			} else {
				// otherwise set result equal to a
				result = a;
			}
			// the variable result now holds the value of the hcf
			// print the value in result to the screen
			Console.WriteLine("The HCF is " + result);
			// Wait for a keypress before closing the program
			Console.ReadKey();

		}
	}
}
