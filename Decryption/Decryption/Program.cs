using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Decryption {
	class Program {
		static void Main(string[] args) {
			string workingPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			Byte[] msg = File.ReadAllBytes(string.Format("{0}\\encoded.txt", workingPath));
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
			for (int i = 0; i < buffer.Length; i++) {
				amountOfChar += buffer[i];
			}
			for (int i = 0; i < buffer.Length; i++) {
				if (buffer[i] != 0) {
					Console.WriteLine("{0}\t{1}\t{2}\t{3}%\t{4}\t", i, string.Format("0x{0:X}", i), /*Convert.ToChar(i),*/ buffer[i], Math.Round((double)buffer[i]/(double)amountOfChar*100,2),Convert.ToString(i, 2).PadLeft(8,'0'));
				}
			}
			Console.WriteLine("{0}\n", amountOfChar);
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
