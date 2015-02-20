using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuffmanCompression {
	class Program {
		public static void Main(string[] args) {
			if (args.Length == 0) {
				// Initialize
				int[] ascii_CodeTable = new int[128];			// Count the occurrence of ASCII characters.
				char[] ascii_Name = new char[128];				// Save the corresponding character to the ASCII name table, e.g. in 65th slot it store 'A'.
				double[] ratio = new double[128];				// Store the ratio of one character to the whole string.
				for (int i = 0; i < ascii_Name.Length; i++) {
					ascii_Name[i] = Convert.ToChar(i);
				}
				// Input
				Console.Write("\nEnter a string: ");
				string str = Console.ReadLine();
				try {
					byte[] ascii = Encoding.ASCII.GetBytes(str);
					Console.WriteLine("\nThe ASCII code are: {0}", string.Join(", ", ascii));
					// Accumulate
					for (int i = 0; i < ascii.Length; i++) {
						ascii_CodeTable[ascii[i]]++;		// Get the ASCII value from the string above and store the amount.
					}
					// Obtain Ratio
					for (int i = 0; i < ratio.Length; i++) {
						ratio[i] = (double)(ascii_CodeTable[i]) / (double)(ascii.Length);
					}
					// Summarize
					Console.WriteLine("\nSUMMARIZE TABLE");
					Console.WriteLine("ASCII\tCHAR\tAMOUNT\tRATIO");
					for (int i = 0; i < ascii_CodeTable.Length; i++) {
						if (ascii_CodeTable[i] != 0) {
							Console.WriteLine("{0}\t{1}\t{2}\t{3}%", i, Convert.ToChar(ascii_Name[i]), ascii_CodeTable[i], Math.Round(ratio[i] * 100, 2));
						}
					}
					// Print out
					Console.WriteLine("\nN/A\tN/A\t{0}\tN/A", ascii.Length);
					if (ascii_CodeTable[63] != 0) {
						Console.WriteLine("\nWARNING: Non-ASCII characters will be convert to '?' (ASCII: 63).");
						Console.WriteLine("Use '-ascii' argument to check the supported ASCII code table.");
					}
				} catch (System.ArgumentNullException) {		// Exception Handle
					Console.WriteLine("\nInclude invalid character(s).");
					Environment.Exit(1);
				}
			} else if (args[0].Equals("-ascii", StringComparison.InvariantCultureIgnoreCase)) {	// Ignore Case in argument
				printAsciiTable();
			} else {	// Error argument handle
				Console.WriteLine("Invalid argument: {0}", string.Join(" ", args));
			}
		}

		/// <summary>
		/// Test the ASCII Table with its index and name.
		/// </summary>
		public static void printAsciiTable() {
			char[] ascii_Name = new char[128];
			for (int i = 0; i < ascii_Name.Length; i++) {
				ascii_Name[i] = Convert.ToChar(i);
			}
			// Testing the table
			Console.WriteLine("\nCODE\tCHAR");
			for (int i = 0; i < ascii_Name.Length; i++) {
				Console.WriteLine("{0}\t{1}", i, ascii_Name[i]);
			}
		}
	}
}
