using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuffmanCompression;

namespace CompressionCalculator {
	public class Program {
		public static void Main(string[] args) {
			Tree test = new Tree("What the hell");
			test.printFreqTable();
		}
	}
}
