using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1 {
	class Program {
		private static Random ran = new Random();
		static void Main(string[] args) {
			// Initialize
			string currentPath = Directory.GetCurrentDirectory();
			if (File.Exists(string.Format(@"{0}\\output.txt", currentPath))) {
				File.Delete(string.Format(@"{0}\\output.txt", currentPath));
			}
			int draw = 10000;
			Console.Write("How many times you want to draw the lottery (Default: 10000):");
			string read = Console.ReadLine();
			if (read.Length != 0) {
				draw = int.Parse(read);
			}
			try {
				int[,] lottery = new int[draw, 6];
				string[] sequences = new string[draw];
				int occurrence = 0;
				Boolean[] result = new Boolean[draw];
				for (int i = 0; i < result.GetLength(0); i++) {
					result[i] = false;
				}
				// Generate the lottery
				Console.Write("\n[{0:d/M/yyyy HH:mm:ss.fff}]  ", DateTime.Now);
				Console.WriteLine("Generate and sort random numbers...");
				for (int i = 0; i < lottery.GetLength(0); i++) {
					// Generate the reference array
					int[] reference = new int[46];	// Ignore the 0 element.
					for (int j = 0; j < reference.GetLength(0); j++) {
						reference[j] = j;
					}
					int length = 0;
					while (length != lottery.GetLength(1)) {
						int pointer = generate();
						if (reference[pointer] != 0) {
							reference[pointer] = 0;
							lottery[i, length] = pointer;
							length++;
						}
					}
					// Ascending Sorting
					ascendingSort(lottery, i);
				}
				/*for (int i = 0; i < lottery.GetLength(0); i++) {
					Console.Write("#{0}\t", i);
					for (int j = 0; j < lottery.GetLength(1); j++) {
						Console.Write("{0} ", lottery[i, j]);
					}
					Console.WriteLine();
				}*/
				// Search consecutive pairs
				Console.Write("\n[{0:d/M/yyyy HH:mm:ss.fff}]  ", DateTime.Now);
				Console.WriteLine("Searching consecutive pairs...");
				for (int i = 0; i < lottery.GetLength(0); i++) {
					for (int j = 0; j < lottery.GetLength(1) - 1; j++) {
						if (lottery[i, j] == lottery[i, j + 1] - 1) {
							result[i] = true;
							break;
						}
					}
				}
				for (int i = 0; i < result.GetLength(0); i++) {
					if (result[i] == true) {
						occurrence++;
					}
					//Console.WriteLine(result[i].ToString());
				}
				for (int i = 0; i < sequences.GetLength(0); i++) {
					sequences[i] = string.Format("{0},{1},{2},{3},{4},{5}", lottery[i, 0], lottery[i, 1], lottery[i, 2], lottery[i, 3], lottery[i, 4], lottery[i, 5]);
				}
				/*foreach (string i in sequences) {
					Console.WriteLine(i);
				}*/
				// Save to file
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(string.Format(@"{0}\\output.txt", currentPath), true)) {
					file.WriteLine("===RESULTS IN {0} TIMES DRAW===", draw);
					for (int i = 0; i < result.GetLength(0); i++) {
						if (result[i] == false) {
							file.WriteLine("#{0}\tFALSE\t{1}", i, sequences[i]);
							//Console.WriteLine("#{0}\tFALSE\t{1}", i, sequences[i]);
						} else {
							file.WriteLine("#{0}\tTRUE\t{1}", i, sequences[i]);
							//Console.WriteLine("#{0}\tTRUE\t{1}", i, sequences[i]);
						}
					}
					file.WriteLine("==========RESULT END==========");
					Console.Write("\n[{0:d/M/yyyy HH:mm:ss.fff}]  ", DateTime.Now);
					Console.WriteLine("Mission accomplished.");
					Console.WriteLine("There are {0} consecutive pairs out of {1} draws. \nRatio: {2}%", occurrence, draw, (double)(occurrence) / (double)(draw) * 100);
					file.WriteLine("There are {0} consecutive pairs out of {1} draws. \nRatio: {2}%", occurrence, draw, (double)(occurrence) / (double)(draw) * 100);
					Console.Write("\n[{0:d/M/yyyy HH:mm:ss.fff}]  ", DateTime.Now);
					Console.WriteLine("The result text file is saved to {0}\\output.txt", currentPath);
				}
			} catch (OutOfMemoryException) {
				Console.WriteLine("\nThis program does not support this amount of draw. The possible reasons are:");
				Console.WriteLine("   1. A significant huge number.");
				Console.WriteLine("   2. Your current computer does not have enough RAM or you are under 32-bit environment.");
				Environment.Exit(1);
			}
		}

		public static int generate() {
			return ran.Next(1, 46);
		}

		public static void ascendingSort(int[,] lotteryArray, int rowNum) {
			int min;
			for (int i = 0; i < lotteryArray.GetLength(1); i++) {
				min = i;
				for (int j = i + 1; j < lotteryArray.GetLength(1); j++) {
					if (lotteryArray[rowNum, j] < lotteryArray[rowNum, min]) {
						min = j;
					}
				}
				swap(i, min, lotteryArray, rowNum);
			}
		}

		public static void swap(int first, int second, int[,] num, int rowNum) {
			int temp = num[rowNum, first];
			num[rowNum, first] = num[rowNum, second];
			num[rowNum, second] = temp;
		}
	}
}
