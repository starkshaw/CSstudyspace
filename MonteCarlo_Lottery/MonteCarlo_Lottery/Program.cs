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
			if (File.Exists(@currentPath + "\\output.txt")) {
				File.Delete(@currentPath + "\\output.txt");
			}
			//int[] lottery = new int[6];
			int draw = 10000;
			Console.Write("How many times you want to draw the lottery? (Default: 10000):");
			string read = Console.ReadLine();
			if (read.Length != 0) {
				draw = int.Parse(read);
			}
			int[,] lottery = new int[draw, 6];
			string[] sequences = new string[draw];
			int occurrence = 0;
			Boolean[] result = new Boolean[draw];
			for (int i = 0; i < result.GetLength(0); i++) {
				result[i] = false;
			}
			// Generate the lottery
			Console.WriteLine("Generating random numbers...");
			for (int i = 0; i < lottery.GetLength(0); i++) {
				for (int j = 0; j < lottery.GetLength(1); j++) {
					lottery[i, j] = generate();
				}
				// Ascending Sorting
				ascendingSort(lottery, i);
				//progressBar(i, draw - 1);
			}
			// Cancel the duplicates
			Console.WriteLine("Cancelling the duplicates...");
			for (int i = 0; i < lottery.GetLength(0); i++) {
				for (int j = 0; j < lottery.GetLength(1) - 1; j++) {
					while (lottery[i, j] == lottery[i, j + 1]) {
						lottery[i, j + 1] = generate();
					}
				}
			}
			/*for (int i = 0; i < lottery.GetLength(0); i++) {
				for (int j = 0; j < lottery.GetLength(1); j++) {
					Console.Write("{0} ", lottery[i, j]);
				}
				Console.WriteLine();
			}*/
			// Ascending Sorting
			Console.WriteLine("Sorting...");
			for (int i = 0; i < lottery.GetLength(0); i++) {
				ascendingSort(lottery, i);
			}
			// Search consecutive pairs
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
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(string.Format(@"{0}\\output.txt", currentPath), true)) {
				file.WriteLine("===RESULTS IN {0} TIMES DRAW===",draw);
				for (int i = 0; i < result.GetLength(0); i++) {
					if (result[i] == false) {
						file.WriteLine("#{0}\tFALSE\t{1}", i, sequences[i]);
						//Console.WriteLine("#{0}\tFALSE\t{1}", i, sequences[i]);
					} else {
						file.WriteLine("#{0}\tTRUE\t{1}", i, sequences[i]);
						//Console.WriteLine("#{0}\tTRUE\t{1}", i, sequences[i]);
					}
				}
				Console.WriteLine("Mission accomplished.");
				Console.WriteLine("There are {0} consecutive pairs out of {1} draws. \nRatio: {2}%", occurrence, draw, (double)(occurrence) / (double)(draw) * 100);
				//using (System.IO.StreamWriter file = new System.IO.StreamWriter(string.Format(@"{0}\\output.txt", currentPath))) {
				file.WriteLine("There are {0} consecutive pairs out of {1} draws. \nRatio: {2}%", occurrence, draw, (double)(occurrence) / (double)(draw) * 100);
			}
			//generate(lottery);
			//ascendingSort(lottery);
			/*foreach (var i in lottery) {
				Console.WriteLine(i);
			}*/
			//
			/*for (int i = 0; i < draw; i++) {
				progressBar(i, draw - 1);
				generate(lottery);
				ascendingSort(lottery);
				for (int j = 0; j < lottery.GetLength(0) - 1; j++) {
					if ((lottery[j] == lottery[j + 1] - 1)) {
						result[i] = true;
						occurrence++;
						break;
					}
				}
				// Write to file
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(@currentPath + "\\output.txt", true)) {
					if (result[i] == false) {
						file.WriteLine("#{0}\tFALSE\t{1}", i, string.Join(",", lottery));
					} else {
						file.WriteLine("#{0}\tTRUE\t{1}", i, string.Join(",", lottery));
					}
				}
			}*/
		}

		/*public static void generate(int[] lotteryArray) {
			for (int i = 0; i < lotteryArray.GetLength(0); i++) {
				lotteryArray[i] = ran.Next(1, 46);
			}
		}*/

		public static int generate() {
			return ran.Next(1, 46);
		}

		/*public static void ascendingSort(int[] lotteryArray) {
			int min;
			for (int i = 0; i < lotteryArray.GetLength(0); i++) {
				min = i;
				for (int j = i + 1; j < lotteryArray.GetLength(0); j++) {
					if (lotteryArray[j] < lotteryArray[min]) {
						min = j;
					}
				}
				swap(i, min, lotteryArray);
			}
		}*/

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

		public static void progressBar(int current, int total) {
			int width = 60;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\r[");
			int i = 0;
			while (i <= (int)((double)(current) / (double)(total) * width)) {
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("*");
				i++;
			}
			while (i <= width) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(" ");
				i++;
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("]\t {0}%", Math.Round((double)(current) / (double)(total) * 100, 2));// [" + current + "/" + total + "]");
			if (current == total) {
				Console.WriteLine();
			}
		}

		/*public static void swap(int first, int second, int[] num) {
			int temp = num[first];
			num[first] = num[second];
			num[second] = temp;
		}*/

		public static void swap(int first, int second, int[,] num, int rowNum) {
			int temp = num[rowNum, first];
			num[rowNum, first] = num[rowNum, second];
			num[rowNum, second] = temp;
		}
	}
}
