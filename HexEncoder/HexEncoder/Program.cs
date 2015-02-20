using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEncoder {
	class Program {
		static void Main(string[] args) {
			string str;
			string separator = ", ";
			Console.Write("\nEnter the text need to be encoded: ");
			str = Console.ReadLine();
			char[] values = str.ToCharArray();
			string[] hex = new string[values.Length];
			for (int i = 0; i < values.Length; i++) {
				hex[i] = string.Format("{0:X}", Convert.ToInt32(values[i]));
			}
			str = "";
			Console.Write("\nEnter the separator (Default: \", \"): ");
			str = Console.ReadLine();
			if (str.Length != 0) {
				separator = str;
			}
			Console.WriteLine("\nThe target hexadecimal UTF-16 BE code is: ");
			Console.WriteLine(string.Join(separator, hex));
		}
	}
}
