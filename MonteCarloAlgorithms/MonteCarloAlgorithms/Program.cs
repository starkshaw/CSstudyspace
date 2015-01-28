using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonteCarloAlgorithms {
	class Program {
		static void Main(string[] args) {
			Dice[] obj = new Dice[5];
			int[] result = new int[30];
			for (int i = 0; i < result.GetLength(0); i++) {
				result[i] = 0;
			}
			for (int i = 0; i <= 4; i++) {
				obj[i] = new Dice();
			}
			for (int i = 0; i < 1000000; i++) {
				int sum = 0;
				for (int j = 0; j < obj.GetLength(0); j++) {
					obj[j].roll();
					//Console.WriteLine("Value\t{0}",obj[j].Point);
					sum = sum + obj[j].Point;
				}
				//Console.WriteLine("Sum\t{0}",sum);
				result[sum - 1] += 1;
			}
			for (int i = 0; i < result.GetLength(0); i++) {
				Console.WriteLine("{0}\t{1}", i + 1, result[i]);
			}
		}
	}
}
