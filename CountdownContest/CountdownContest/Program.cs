using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CountdownContest {
	class Program {
		static void Main(string[] args) {
			string workingPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			try {
				Console.Write("Reading dictionary... ");
				string[] dic = File.ReadAllLines(string.Format(@"{0}\dictionary.txt", workingPath));	// Read the dictionary
				string userStr, lowerStr;	// userStr store the string user entered, lowerStr convert it into lower case
				int count = 0;				// Count the amount of result
				Console.WriteLine("Done.\n");
				Console.Write("Enter the random string: ");
				userStr = Console.ReadLine();			// Raw data
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
					Console.WriteLine("\n{0} result{1} found.", count, count==1 ? "" : "s");	// Include plural handler
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
			} catch (System.IO.FileNotFoundException) {		// File not found handler
				Console.WriteLine("\n\nCannot find {0}\\dictionary.txt", workingPath);
				Console.WriteLine("Abort.");
				Environment.Exit(-1);
			} finally {

			}
		}

		/// <summary>
		/// Get the ASCII frequency table (ordered by the ASCII index ascending)
		/// </summary>
		/// <param name="str">The string wait to be examined</param>
		/// <returns>A int array consist ASCII index (Column 0) and frequency (Column 1)</returns>
		static int[,] getAsciiFreq(string str) {
			byte[] code = Encoding.ASCII.GetBytes(str);
			int[] asciiFreq = new int[128];
			int nonzero = 0;
			for (int i = 0; i < str.Length; i++) {
				asciiFreq[code[i]]++;
			}
			for (int i = 0; i < asciiFreq.Length; i++) {
				if (asciiFreq[i] != 0) {
					nonzero++;
				}
			}
			int[,] result = new int[nonzero, 2];
			int count = 0;
			for (int i = 0; i < asciiFreq.Length; i++) {
				if (asciiFreq[i] != 0) {
					result[count, 0] = i;
					result[count, 1] = asciiFreq[i];
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
			bool result = false;
			if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1)) {
				for (int i = 0; i < a.GetLength(0); i++) {
					for (int j = 0; j < a.GetLength(1); j++) {
						if (a[i, j] == b[i, j]) {
							//Console.WriteLine("{0}\t{1}\tTRUE", a[i, j], b[i, j]);
							result = true;
						} else {
							//Console.WriteLine("{0}\t{1}\tFALSE", a[i, j], b[i, j]);
							result = false;
							goto false_detect;
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
