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
				string[] dic = File.ReadAllLines(string.Format(@"{0}\dictionary.txt", workingPath));
				string userStr;
				Console.WriteLine("Done.\n");
				Console.Write("Enter the random string: ");
				userStr = Console.ReadLine();
				/*foreach (string str in dic) {
					Console.WriteLine(str);
				}*/
			} catch (System.IO.FileNotFoundException) {
				Console.WriteLine("\n\nCannot find {0}\\dictionary.txt", workingPath);
				Console.WriteLine("Abort.");
				Environment.Exit(-1);
			} finally {
				
			}
		}
	}
}
