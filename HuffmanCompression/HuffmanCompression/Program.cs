using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuffmanCompression {
	class Program {
		public static void Main(string[] args) {
			if (args.Length == 0) {
				// Initialize
				int[] ascii_CodeTable = new int[128];			// Count the occurrence of ASCII characters
				char[] ascii_Name = new char[128];				// Save the corresponding character to the ASCII name table, e.g. in 65th slot it store 'A'
				double[] ratio = new double[128];				// Store the ratio of one character to the whole string
				for (int i = 0; i < ascii_Name.Length; i++) {
					ascii_Name[i] = Convert.ToChar(i);
				}
				// Input
				Console.Write("\nEnter a string: ");
				string str = Console.ReadLine();
				try {
					byte[] ascii = Encoding.ASCII.GetBytes(str);	// Convert string into byte array which consists by the ASCII code of each character
					Console.WriteLine("\nThe ASCII code are: {0}", string.Join(", ", ascii));
					// Accumulate
					for (int i = 0; i < ascii.Length; i++) {
						ascii_CodeTable[ascii[i]]++;		// Get the ASCII value from the string above and store the amount
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
							if (i != 9) {
								Console.WriteLine("{0}\t{1}\t{2}\t{3}%", i, Convert.ToChar(ascii_Name[i]), ascii_CodeTable[i], Math.Round(ratio[i] * 100, 2));
							} else {		// Tab character exception handle
								Console.WriteLine("{0}\t\t{1}\t{2}%", i, ascii_CodeTable[i], Math.Round(ratio[i] * 100, 2));
							}
						}
					}
					// Print out the amount of character
					Console.WriteLine("\nN/A\tN/A\t{0}\tN/A", ascii.Length);
					// Non-ASCII characters Warning
					if (ascii_CodeTable[63] != 0) {
						Console.WriteLine("\nWARNING: Non-ASCII character will be converted to '?' (ASCII: 63).");
						Console.WriteLine("Use '-ascii' argument to check the supported ASCII code table.");
					}
					// ASCII Control or invisible characters Warning
					for (int i = 0; i < ascii_CodeTable.Length; i++) {
						if ((i <= 32 || i == 127) && (ascii_CodeTable[i] != 0)) {
							Console.WriteLine("\nWARNING: ASCII Control or invisible character(s) have been detected.");
							Console.WriteLine("Use '-ascii' argument to check descriptions of control character.");
							break;
						}
					}
				} catch (System.ArgumentNullException) {		// Exception Handle
					Console.WriteLine("\nInclude invalid character(s).");
					Environment.Exit(1);
				}
			} else if (args[0].Equals("-ascii", StringComparison.InvariantCultureIgnoreCase)) {	// Ignore Case in argument
				printAsciiTable();
				Environment.Exit(0);
			} else {	// Error argument handle
				Console.WriteLine("\nInvalid argument(s): {0}", string.Join(" ", args));
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
				if (i == 8) {
					Console.Write("{0}\t(BS)\tbackspace", i);
				} else if (i == 9) {
					Console.Write("{0}\t(TAB)\thorizontal tab", i);
				} else if (i == 10) {
					Console.Write("{0}\t(LF)\tline feed, new line", i);
				} else if (i == 13) {
					Console.Write("{0}\t(CR)\tcarriage return", i);
				} else {
					Console.Write("{0}\t{1}", i, ascii_Name[i]);
					if (i == 0) {
						Console.Write(" (NUL)\tnull");
					} else if (i == 1) {
						Console.Write(" (SOH)\tstark of heading");
					} else if (i == 2) {
						Console.Write(" (STX)\tstart of text");
					} else if (i == 3) {
						Console.Write(" (ETX)\tend of text");
					} else if (i == 4) {
						Console.Write(" (EOT)\tend of transmission");
					} else if (i == 5) {
						Console.Write(" (ENQ)\tenquiry");
					} else if (i == 6) {
						Console.Write(" (ACK)\tacknowledge");
					} else if (i == 7) {
						Console.Write(" (BEL)\tbell");
					} else if (i == 11) {
						Console.Write(" (VT)\tvertical tab");
					} else if (i == 12) {
						Console.Write(" (FF)\tNP form feed, new line");
					} else if (i == 14) {
						Console.Write(" (SO)\tshift out");
					} else if (i == 15) {
						Console.Write(" (SI)\tshift in");
					} else if (i == 16) {
						Console.Write(" (DLE)\tdata link escape");
					} else if (i == 17) {
						Console.Write(" (DC1)\tdevice control 1");
					} else if (i == 18) {
						Console.Write(" (DC2)\tdevice control 2");
					} else if (i == 19) {
						Console.Write(" (DC3)\tdevice control 3");
					} else if (i == 20) {
						Console.Write(" (DC4)\tdevice control 4");
					} else if (i == 21) {
						Console.Write(" (NAK)\tnegative acknowledge");
					} else if (i == 22) {
						Console.Write(" (SYN)\tsynchronous idle");
					} else if (i == 23) {
						Console.Write(" (ETB)\tend of trans, block");
					} else if (i == 24) {
						Console.Write(" (CAN)\tcancel");
					} else if (i == 25) {
						Console.Write(" (EM)\tend of medium");
					} else if (i == 26) {
						Console.Write(" (SUB)\tsubstitute");
					} else if (i == 27) {
						Console.Write(" (ESC)\tescape");
					} else if (i == 28) {
						Console.Write(" (FS)\tfile separator");
					} else if (i == 29) {
						Console.Write(" (GS)\tgroup separator");
					} else if (i == 30) {
						Console.Write(" (RS)\trecord separator");
					} else if (i == 31) {
						Console.Write(" (US)\tunit separator");
					} else if (i == 32) {
						Console.Write(" (SPACE)");
					} else if (i == 127)
						Console.Write(" (DEL)");
				}
				Console.WriteLine();
			}
		}
	}
}

