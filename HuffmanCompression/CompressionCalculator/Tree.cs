using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuffmanCompression {
	public class Tree {
		public Node root;										// First node of tree
		public int frequency = 0;
		private int[] ascii_CodeTable = new int[128];			// Count the occurrence of ASCII characters
		private double[] ratio = new double[128];						// Store the ratio of one character to the whole string
		private int[,] freqTable;
		// Constructor
		public Tree(string str) {
			try {
				byte[] ascii = Encoding.ASCII.GetBytes(str);	// Convert string into byte array which consists by the ASCII code of each character
				// Accumulate
				for (int i = 0; i < ascii.Length; i++) {
					ascii_CodeTable[ascii[i]]++;		// Get the ASCII value from the string above and store the amount
				}
				// Obtain Ratio
				for (int i = 0; i < ratio.Length; i++) {
					ratio[i] = (double)(ascii_CodeTable[i]) / (double)(ascii.Length);
				}
				// Sort existed characters
				freqTable = sortByFrequency(ascii_CodeTable);

			} catch (System.ArgumentNullException) {			// Exception Handle
				Console.WriteLine("\nInclude invalid character(s).");
				Environment.Exit(1);
			}
			//root = null;	// No nodes in tree yet
		}

		public int compareTo(Tree obj) {
			if (frequency - obj.frequency > 0) {
				return 1;
			} else if (frequency - obj.frequency > 0) {
				return -1;
			} else {
				return 0;
			}
		}

		string path = "error";	// This variable will track the path to the letter were looking for

		public string getCode(char letter) {
			path = Convert.ToString(letter).PadLeft(7, '0');
			return path;
		}

		public void printFreqTable() {
			for (int i = 0; i < freqTable.GetLength(0); i++) {
				for (int j = 0; j < freqTable.GetLength(1); j++) {
					Console.Write("{0}\t", freqTable[i, j]);
				}
				Console.WriteLine();
			}
		}
		/// <summary>
		/// Sort the raw ASCII count table by frequency.
		/// </summary>
		/// <param name="asciiCountTable">The original count table.</param>
		/// <returns>Sorted array consists by: Col 1 ASCII Code, Col 2 Amount</returns>
		private static int[,] sortByFrequency(int[] asciiCountTable) {
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
			return ans;
		}
	}
}
