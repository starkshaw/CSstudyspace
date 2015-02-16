using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StickProblem;
using System.IO;

namespace StickProblemAdvanced {
	class Program {
		static void Main(string[] args) {
			// Initialize
			string currentPath = Directory.GetCurrentDirectory();
			if (File.Exists(string.Format(@"{0}\\output_advanced.txt", currentPath))) {
				File.Delete(string.Format(@"{0}\\output_advanced.txt", currentPath));
			}
			StickProblem.Stick stick = new StickProblem.Stick();
			for (int i = 0; i < 10; i++) {
				int[] test = stick.separate(7);
				Console.WriteLine(string.Join(",", test));
			}
		}
	}
}
