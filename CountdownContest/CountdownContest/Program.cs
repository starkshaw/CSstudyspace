using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CountdownContest {
	class Program {
		static void Main(string[] args) {
			string workingPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);	// The location of executable file
			string userDic = "";	// If user defines a dictionary it could store the path here
		start:
			try {
				Console.Write("Reading dictionary... ");
				string[] dic;		// Store each line from dictionary file
				if (userDic.Length == 0) {
					dic = File.ReadAllLines(string.Format(@"{0}\dictionary.txt", workingPath));	// Read the dictionary
				} else {
					dic = File.ReadAllLines(string.Format(@"{0}", userDic));	// Read user defined dictionary
				}
				string userStr, lowerStr;	// userStr store the string user entered, lowerStr convert it into lower case
				int count = 0;				// Count the amount of result
				Console.WriteLine("Done.\n");
				Console.Write("Enter the random string: ");
				userStr = Console.ReadLine();			// Raw user data
				lowerStr = userStr.ToLower();			// Convert to lower case
				int[,] userFreq = getAsciiFreq(lowerStr);	// Generate user string ASCII frequency table
				Console.WriteLine("\nRESULTS:");
				for (int i = 0; i < dic.Length; i++) {
					int[,] tmp = getAsciiFreq(dic[i]);		// Generate the frequency table of current string in dictionary
					if (compareArrays(userFreq, tmp) == true) {	// Compare user table and current table, if true print out
						Console.WriteLine(dic[i]);
						count++;							// Update the count
					}
				}
				if (count == 0) {
					Console.WriteLine("\nNot found.");
				} else {
					Console.WriteLine("\n{0} result{1} found.", count, count == 1 ? "" : "s");	// Include plural handler
				}
				/*int[,] test1 = getAsciiFreq("saxophone");
				int[,] test2 = getAsciiFreq("enophxoassssss");
				for (int i = 0; i < test1.GetLength(0); i++) {
					for (int j = 0; j < test1.GetLength(1); j++) {
						Console.Write(test1[i, j] + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine();
				for (int i = 0; i < test2.GetLength(0); i++) {
					for (int j = 0; j < test2.GetLength(1); j++) {
						Console.Write(test2[i, j] + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine(compareArrays(test1, test2));*/
				/*foreach (string str in dic) {
					Console.WriteLine(str);
				}*/
			} catch (System.IO.FileNotFoundException) {					// File not found handler
				Console.WriteLine("\n\nCannot find dictionary:");
				if (userDic.Length == 0) {								// If user did not define a dictionary
					Console.WriteLine(@"{0}\dictionary.txt", workingPath);
				} else {												// If user dictionary cannot be found
					Console.WriteLine("{0}", userDic);
				}
				Console.Write("\nLocate your dictionary, or press ENTER to exit: ");	// Define user dictionary or exit
				userDic = Console.ReadLine();
				if (userDic.Length == 0) {
					Console.WriteLine("Abort.");
					Environment.Exit(-1);		// Exit
				} else {
					Console.WriteLine();
					goto start;					// back to start
				}
			} finally {

			}
		}

		/// <summary>
		/// Get the ASCII frequency table (ordered by the ASCII index ascending)
		/// </summary>
		/// <param name="str">The string wait to be examined</param>
		/// <returns>A int array consist ASCII index (Column 0) and frequency (Column 1)</returns>
		static int[,] getAsciiFreq(string str) {
			byte[] code = Encoding.ASCII.GetBytes(str);		// Get the ASCII code array of string
			int[] asciiFreq = new int[128];					// ASCII Frequency table
			int nonzero = 0;								// Non-zero frequency in ASCII Frequency table
			for (int i = 0; i < str.Length; i++) {			// Store the frequencies
				asciiFreq[code[i]]++;
			}
			for (int i = 0; i < asciiFreq.Length; i++) {	// Count the non-zero frequency
				if (asciiFreq[i] != 0) {
					nonzero++;
				}
			}
			int[,] result = new int[nonzero, 2];			// Initialize the output array
			int count = 0;									// Inner count
			for (int i = 0; i < asciiFreq.Length; i++) {
				if (asciiFreq[i] != 0) {
					result[count, 0] = i;					// Column 0: ASCII index
					result[count, 1] = asciiFreq[i];		// Column 1: Frequency
					count++;
				}
			}
			return result;
		}

		/// <summary>
		/// Compare 2 2D int arrays
		/// </summary>
		/// <param name="a">array a</param>
		/// <param name="b">array b</param>
		/// <returns>If they are exactly same return true, otherwise false.</returns>
		static bool compareArrays(int[,] a, int[,] b) {
			bool result = false;		// Default
			if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1)) {		// Examine if lengths are same
				for (int i = 0; i < a.GetLength(0); i++) {
					for (int j = 0; j < a.GetLength(1); j++) {
						if (a[i, j] == b[i, j]) {											// Examine each elements in arrays
							//Console.WriteLine("{0}\t{1}\tTRUE", a[i, j], b[i, j]);
							result = true;
						} else {
							//Console.WriteLine("{0}\t{1}\tFALSE", a[i, j], b[i, j]);
							result = false;
							goto false_detect;		// If find any inequal value direct jump to return false
						}
					}
				}
			} else {
				result = false;
			}
		false_detect:
			return result;
		}
	}
}
