using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindPrimeNumber {
	class CheckList {
		public static int count = 0, n = 0;
		static void Main(string[] args) {
			if (args.Length == 0) {
				Console.Write("How many number this array covered: ");
				n = int.Parse(Console.ReadLine()) + 1;
			} else {
				try {
					n = int.Parse(args[0]) + 1;
				} catch (FormatException) {
					Console.WriteLine("Argument: {0} must be an integer.", args[0]);
					Environment.Exit(1);
				}
			}
			long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			Boolean[] num = new Boolean[n];
			for (int i = 0; i <= num.Length - 1; i++) {
				num[i] = true;
			}
			for (int i = 2; i <= num.Length - 1; i++) {
				for (int j = 2; ; j++) {
					int mul = i * j;
					if (mul > num.Length) {
						break;
					} if (mul < num.Length) {
						num[mul] = false;
					}
				}
			}
			for (int i = 2; i <= num.Length - 1; i++) {
				if (num[i] == true) {
					count++;
					Console.Write("{0} ", i);
					if (count % 10 == 0) {
						Console.WriteLine();
					}
				}
			}
			finalCount();
			long elapsed = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - start;
			Console.WriteLine("The answer took {0} ms to compute.", elapsed);
		}
		public static void finalCount() {
			Console.Write("\n\nThere ");
			if (count == 1) {
				Console.WriteLine("is 1 prime number, which is 2.");
			} else if (count > 1) {
				Console.WriteLine("are {0} prime numbers from 2 to {1}.", count, n - 1);
			}
		}
	}
}
