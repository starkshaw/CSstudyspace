using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Decryption {
	class Program {
		static void Main(string[] args) {
			string workingPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Byte[] msg = File.ReadAllBytes(string.Format("{0}//encoded.txt", workingPath));
			string[] monogram = File.ReadAllLines(string.Format("{0}//finnish_monograms.txt", workingPath));
			int[] buffer = new int[256];
			int amountOfChar = 0;
			for (int i = 0; i < msg.Length; i++) {
				buffer[msg[i]]++;
			}
			// Split
			string[,] separatedMonogram = new string[monogram.Length, 2];
			for (int i = 0; i < separatedMonogram.GetLength(0); i++) {
				string[] temp = monogram[i].Split(' ');
				separatedMonogram[i, 0] = temp[0];
				separatedMonogram[i, 1] = temp[1];
			}
			// Summarize
			for (int i = 0; i < buffer.Length; i++) {
				amountOfChar += buffer[i];
			}
			int variantOfChar = 0;
			Console.WriteLine("\nFREQUENCY DETAILS (ASCII ORDER)");
			Console.WriteLine("DEC\tHEX\tFREQ\tRATIO\tBIN");
			for (int i = 0; i < buffer.Length; i++) {
				if (buffer[i] != 0) {
					Console.WriteLine("{0}\t{1}\t{2}\t{3}%\t{4}\t", i, string.Format("0x{0:X}", i), /*Convert.ToChar(i),*/ buffer[i], Math.Round((double)buffer[i] / (double)amountOfChar * 100, 2), Convert.ToString(i, 2).PadLeft(8, '0'));
					variantOfChar++;
				}
			}
			int[] asciiOrderTable = new int[256];
			for (int i = 0; i < buffer.Length; i++) {
				asciiOrderTable[i] = buffer[i];
			}
			int[,] orderedTable = sortByFrequency(asciiOrderTable);
			Console.WriteLine("\nFREQUENCY DETAILS (FREQUENCY ORDER)");
			Console.WriteLine("DEC\tHEX\tFREQ\tRATIO\tBIN");
			for (int i = 0; i < orderedTable.GetLength(0); i++) {
				Console.WriteLine("{0}\t{1}\t{2}\t{3}%\t{4}\t", orderedTable[i, 0], string.Format("0x{0:X}", orderedTable[i, 0]), orderedTable[i, 1], Math.Round((double)orderedTable[i, 1] / (double)amountOfChar * 100, 2), Convert.ToString(orderedTable[i, 0], 2).PadLeft(8, '0'));
			}
			Console.WriteLine("\nTotal characters: {0}\n", amountOfChar);
			/*string[] invertedBinary = new string[amountOfChar];
			int count = 0;
			for (int i = 0; i < buffer.Length; i++) {
				string tmp;
				if (buffer[i] != 0) {
					tmp = Convert.ToString(i, 2);
					for (int j = 0; j < tmp.Length; j++) {
						StringBuilder strBdr = new StringBuilder(tmp);
						if (tmp[j] == '0') {
							strBdr[j] = '1';
							tmp = strBdr.ToString();
						} else if (tmp[j] == '1') {
							strBdr[j] = '0';
							tmp = strBdr.ToString();
						}
					}
					invertedBinary[count] = tmp;
					count++;
				}
			}
			for (int i = 0; i < invertedBinary.Length; i++) {
				Console.WriteLine("{0}\t{1}\t{2}", Convert.ToInt32(invertedBinary[i],2),invertedBinary[i], Convert.ToChar(Convert.ToInt32(invertedBinary[i],2)));
			}*/
			// Find space (assumed)
			/*
			Console.WriteLine("Space searching:");
			for (int i = 0; i < msg.Length; i++) {
				if (msg[i] == 140) {	// The ASCII Index of assumed space
					Console.WriteLine("{0}\t{1}\t", msg[i - 1], msg[i]);
				}
			}
			*/
			// Find keyword (assume)
			/*for (int i = 0; i < msg.Length; i++) {
				if (msg[i] == 178) {
					Console.WriteLine("{0}\t{1}\t\t", msg[i], msg[i + 1]);
				}
			}*/
			// Find keyword (assume _e)
			/*for (int i = 0; i < msg.Length; i++) {
				if (msg[i] == 167 && msg[i + 1] == 119 && msg[i + 3] == 167) {
					Console.WriteLine("{0}\t{1}\t{2}\t{3}", msg[i], msg[i + 1], msg[i + 2], msg[i + 3]);
				}
			}*/
		}
		/// <summary>
		/// Sort the raw ASCII count table by frequency.
		/// </summary>
		/// <param name="asciiCountTable">The original count table.</param>
		/// <returns>Sorted array consists by: Col 0 ASCII DEC, Col 1 Frequency</returns>
		public static int[,] sortByFrequency(int[] asciiCountTable) {
			// Count the row of output array
			int row = 0;
			for (int i = 0; i < asciiCountTable.Length; i++) {
				if (asciiCountTable[i] != 0) {
					row++;
				}
			}
			int[,] ans = new int[row, 2];	// Column 1 list the ASCII code, Column 2 list the amount
			// Summarize the existed characters
			int tmp = 0;	// Count row
			for (int i = 0; i < asciiCountTable.Length; i++) {
				if (asciiCountTable[i] != 0) {
					ans[tmp, 0] = i;
					ans[tmp, 1] = asciiCountTable[i];
					tmp++;
				}
			}
			// Sort
			for (int i = 0; i < ans.GetLength(0); i++) {
				int tmp_sort_0 = 0;	// Store the temporary value in column 1
				int tmp_sort_1 = 0;	// Store the temporary value in column 2
				for (int j = ans.GetLength(0) - 1; j > i; j--) {
					if (ans[j, 1] > ans[j - 1, 1]) {
						tmp_sort_0 = ans[j - 1, 0];
						tmp_sort_1 = ans[j - 1, 1];
						ans[j - 1, 0] = ans[j, 0];
						ans[j - 1, 1] = ans[j, 1];
						ans[j, 0] = tmp_sort_0;
						ans[j, 1] = tmp_sort_1;
					}
				}
			}
			// Test
			/*
			for (int i = 0; i < ans.GetLength(0); i++) {
				for (int j = 0; j < ans.GetLength(1); j++) {
					Console.Write("{0} ", ans[i, j]);
				}
				Console.WriteLine();
			}
			*/
			return ans;
		}
	}
}
