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
			int[] lottery = new int[6];
			int draw = 10000;
			int occurrence = 0;
			Boolean[] result = new Boolean[draw];
			for (int i = 0; i < result.GetLength(0); i++) {
				result[i] = false;
			}
			//generate(lottery);
			//ascendingSort(lottery);
			/*foreach (var i in lottery) {
				Console.WriteLine(i);
			}*/
			//
			for (int i = 0; i < draw; i++) {
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
			}
			Console.WriteLine("There are {0} consecutive pairs out of {1} draws. \nRatio: {2}%", occurrence, draw, (double)(occurrence) / (double)(draw) * 100);
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@currentPath + "\\output.txt", true)) {
				file.WriteLine("There are {0} consecutive pairs out of {1} draws. \nRatio: {2}", occurrence, draw, (double)(occurrence) / (double)(draw) * 100);
			}
		}

		public static void generate(int[] lotteryArray) {
			for (int i = 0; i < lotteryArray.GetLength(0); i++) {
				lotteryArray[i] = ran.Next(1, 46);
			}
		}

		public static void ascendingSort(int[] lotteryArray) {
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

		public static void swap(int first, int second, int[] num) {
			int temp = num[first];
			num[first] = num[second];
			num[second] = temp;
		}
	}
}
