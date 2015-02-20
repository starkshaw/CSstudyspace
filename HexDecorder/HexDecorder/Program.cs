using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexDecorder {
	class Program {
		static void Main(string[] args) {
			string str;
			Console.Write("\nEnter the UTF-16BE hexadecimal code, separate by space: ");
			str = Console.ReadLine();
			try {
				string[] hexStr = str.Split(' ');
				int[] decStr = new int[hexStr.Length];
				for (int i = 0; i < hexStr.Length; i++) {
					decStr[i] = Convert.ToInt32(hexStr[i], 16);
				}
				Console.WriteLine("\nThe result is: ");
				foreach (int i in decStr) {
					Console.Write(Convert.ToChar(i));
				}
				Console.WriteLine();
			} catch (System.ArgumentOutOfRangeException) {
				Console.WriteLine("\nInvalid code, abort.");
				Environment.Exit(1);
			} catch (System.OverflowException) {
				Console.WriteLine("\nOverflow value detected, abort.");
				Environment.Exit(1);
			}
		}
	}
}
