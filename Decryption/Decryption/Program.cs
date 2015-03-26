using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Decryption {
	class Program {
		static void Main(string[] args) {
			string workingPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Byte[] msg = File.ReadAllBytes(string.Format("{0}//encoded.txt", workingPath));
			int[] buffer = new int[256];
			int amountOfChar = 0;
			for (int i = 0; i < msg.Length; i++) {
				buffer[msg[i]]++;
			}
			/*for (int i = 0; i < buffer.Length; i++) {
				if (buffer[i] != 0) {
					amountOfChar++;
				}
			}*/
			// Find space (assumed)
			for (int i = 0; i < msg.Length; i++) {
				if (msg[i] == 140) {	// The ASCII Index of assumed space
					Console.WriteLine("{0}\t{1}\t", msg[i - 1], msg[i]);
				}
			}
			// Find keyword (assume de)
			/*for (int i = 0; i < msg.Length; i++) {
				if (msg[i] == 47 && msg[i + 2] == 167 && msg[i - 1] == 167) {
					Console.WriteLine("{0}\t{1}\t{2}\t{3}", msg[i - 1], msg[i], msg[i + 1], msg[i + 2]);
				}
			}*/
			// Find keyword (assume _e)
			for (int i = 0; i < msg.Length; i++) {
				if (msg[i] == 167 && msg[i + 1] == 119 && msg[i + 3] == 167) {
					Console.WriteLine("{0}\t{1}\t{2}\t{3}", msg[i], msg[i + 1], msg[i + 2], msg[i + 3]);
				}
			}
			// Summarize
			for (int i = 0; i < buffer.Length; i++) {
				amountOfChar += buffer[i];
			}
			Console.WriteLine("\nFREQUENCY DETAILS");
			Console.WriteLine("DEC\tHEX\tFREQ\tRATIO\tBIN");
			for (int i = 0; i < buffer.Length; i++) {
				if (buffer[i] != 0) {
					Console.WriteLine("{0}\t{1}\t{2}\t{3}%\t{4}\t", i, string.Format("0x{0:X}", i), /*Convert.ToChar(i),*/ buffer[i], Math.Round((double)buffer[i] / (double)amountOfChar * 100, 2), Convert.ToString(i, 2).PadLeft(8, '0'));
				}
			}
			Console.WriteLine("\nTotal characters: {0}\n", amountOfChar);
			/*string[] invertedBinary = new string[amountOfChar];
			int count = 0;
			for (int i = 0; i < buffer.Length; i++) {
				string tmp;
				if (buffer[i] != 0) {
					tmp = Convert.ToString(i, 2);
					for (int j = 0; j < tmp.Length; j++) {
						StringBuilder strBdr = new StringBuilder(tmp);
						if (tmp[j] == '0') {
							strBdr[j] = '1';
							tmp = strBdr.ToString();
						} else if (tmp[j] == '1') {
							strBdr[j] = '0';
							tmp = strBdr.ToString();
						}
					}
					invertedBinary[count] = tmp;
					count++;
				}
			}
			for (int i = 0; i < invertedBinary.Length; i++) {
				Console.WriteLine("{0}\t{1}\t{2}", Convert.ToInt32(invertedBinary[i],2),invertedBinary[i], Convert.ToChar(Convert.ToInt32(invertedBinary[i],2)));
			}*/
		}
	}
}
