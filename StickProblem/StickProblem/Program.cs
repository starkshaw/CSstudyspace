using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StickProblem {
	class Program {
		static void Main(string[] args) {
			// Initialize
			string currentPath = Directory.GetCurrentDirectory();
			if (File.Exists(string.Format(@"{0}\\output.txt", currentPath))) {
				File.Delete(string.Format(@"{0}\\output.txt", currentPath));
			}
			Stick simulation;
			string read;
			int amount = 1000000;
			int occurrence = 0;
			Console.Write("The circumferrence of triangle (Default: 100): ");
			read = Console.ReadLine();
			if (read.Length == 0) {
				simulation = new Stick();
			} else {
				simulation = new Stick(int.Parse(read));
			}
			Console.Write("The amount of simulations (Default: {0}): ", amount);
			read = Console.ReadLine();
			if (read.Length != 0) {
				amount = int.Parse(read);
			}
			try {
				// Generate the broken sticks
				Console.WriteLine("Generating stick simulations...");
				int[,] draw = new int[amount, 3];
				Boolean[] result = new Boolean[amount];
				for (int i = 0; i < result.Length; i++) {
					result[i] = false;
				}
				for (int i = 0; i < draw.GetLength(0); i++) {
					int[] tmp = simulation.separate();
					for (int j = 0; j < draw.GetLength(1); j++) {
						draw[i, j] = tmp[j];
					}
				}
				Console.WriteLine("Examining the possibility of build triangle...");
				for (int i = 0; i < draw.GetLength(0); i++) {
					//Console.WriteLine("EXAMINING...");
					if (draw[i, 0] + draw[i, 1] > draw[i, 2]) {
						//Console.WriteLine("TRUE {0}, {1}, {2}", draw[i, 0], draw[i, 1], draw[i, 2]);
						result[i] = true;
						occurrence++;
					} else {
						//Console.WriteLine("FALSE {0}, {1}, {2}", draw[i, 0], draw[i, 1], draw[i, 2]);
						result[i] = false;
					}
				}
				Console.WriteLine("There are {0} sticks can be built to triangle out of {1} sticks.", occurrence, amount);
				Console.WriteLine("Ratio: {0}%", (double)(occurrence) / (double)(amount) * 100);
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(string.Format(@"{0}\\output.txt", currentPath), true)) {
					file.WriteLine("====RESULTS IN {0} STICKS====", amount);
					for (int i = 0; i < result.GetLength(0); i++) {
						if (result[i] == false) {
							file.WriteLine("#{0}\tFALSE\t{1}, {2}, {3}", i, draw[i, 0], draw[i, 1], draw[i, 2]);
							//Console.WriteLine("#{0}\tFALSE\t{1}", i, sequences[i]);
						} else {
							file.WriteLine("#{0}\tTRUE\t{1}, {2}, {3}", i, draw[i, 0], draw[i, 1], draw[i, 2]);
							//Console.WriteLine("#{0}\tTRUE\t{1}", i, sequences[i]);
						}
					}
					file.WriteLine("==========RESULT END==========");
					file.WriteLine("There are {0} sticks can be built to triangle out of {1} sticks.", occurrence, amount);
					file.WriteLine("Ratio: {0}%", (double)(occurrence) / (double)(amount) * 100);
				}
				// Test
				/*for (int i = 0; i < draw.GetLength(0); i++) {
					for (int j = 0; j < draw.GetLength(1); j++) {
						Console.Write("{0} ", draw[i, j]);
					}
					Console.WriteLine();
				}
				Console.WriteLine(simulation.Circumferrence);*/
			} catch (OutOfMemoryException) {			// Exception handle
				Console.WriteLine("Out of memory!");
				Environment.Exit(1);
			}
		}
	}
}
