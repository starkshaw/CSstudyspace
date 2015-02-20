using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuffmanCompression {
	class Program {
		static void Main(string[] args) {
			Console.Write("Enter a string: ");
			string str = Console.ReadLine();
			Console.WriteLine("The ASCII code are: {0}",string.Join(", ", Encoding.ASCII.GetBytes(str)));
		}
	}
}
