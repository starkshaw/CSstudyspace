using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindPrimeNumber {
	class CheckIndex {
		public static void Main(string[] args) {
			int n = 0;
			if (args.Length == 0) {
				Console.Write("The index of prime number: ");
				n = int.Parse(Console.ReadLine());
			} else {
				try {
					n = int.Parse(args[0]);
				} catch (FormatException) {
					Console.WriteLine("Argument: {0} must be an integer.", args[0]);
					Environment.Exit(1);
				}
			}
			long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;		//Time count
			int process = (int)(2 * n * Math.Log(n));
			Console.WriteLine("Searching...");
			Console.WriteLine("The prime number is {0}",getPrimeNumberWithIndex(generatePrimeNumTable(process),n));
			long elapsed = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - start;
			Console.WriteLine("The answer took {0} ms to compute.", elapsed);
		}

		/// <summary>
		/// Generate a prime number table less than the given parameter
		/// </summary>
		/// <param name="Maximum">The maximum number in the table</param>
		/// <returns>The boolean array with the statement of prime or not.</returns>
		public static Boolean[] generatePrimeNumTable(int Maximum) {
			// Declaration
			int n = Maximum + 1;
			Boolean[] table = new Boolean[n];
			// Initialize the array
			for (int i = 0; i <= table.Length - 1; i++) {
				table[i] = true;
			}
			// Generate prime number table
			for (int i = 2; i < table.Length; i++) {
				for (int j = 2; ; j++) {
					int mul = i * j;
					if (mul > table.Length) {
						break;
					}
					if (mul < table.Length) {
						table[mul] = false;
					}
				}
			}
			return table;
		}

		/// <summary>
		/// Obtain the prime number according to its index.
		/// </summary>
		/// <param name="originalPNTable">Original (unsorted) boolean prime number table.</param>
		/// <param name="index">The index.</param>
		/// <returns>The prime number.</returns>
		public static int getPrimeNumberWithIndex(Boolean[] originalPNTable, int index) {
			int primeNum = 0, count = 0;
			if (index > 2) {
				for (int i = 2; i <= originalPNTable.Length - 1; i++) {
					if (originalPNTable[i] == true) {
						count++;
						if (count == index) {
							primeNum = i;
							break;
						}
					}
				}
				return primeNum;
			} else if (index == 1) {
				return 2;
			} else if (index == 2) {
				return 3;
			} else {
				return 0;
			}
		}
	}
}
