using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicKeyDecrypt {
	class Program {
		static void Main(string[] args) {
			//Console.WriteLine(modPow(7, 31, 11));
			//Console.WriteLine(modMult(7, 88, 9));

			// Initialize
			long[] publicKey = new long[3];
			Console.WriteLine("\nEnter the public key consists by 3 integers, use comma separate only.\n");
			Console.Write("Public Key: ");
			try {
				string[] input = Console.ReadLine().Split(',');
				for (int i = 0; i < input.Length; i++) {
					publicKey[i] = long.Parse(input[i]);
				}
			} catch (System.IndexOutOfRangeException) {		// Exception handlers
				Console.WriteLine("\nERROR: Overloaded carries.");
				Console.WriteLine("The public key shall only contains 3 integers.");
			} catch (System.FormatException) {
				Console.WriteLine("\nERROR: Wrong data type.");
				Console.WriteLine("The public key shall only contains 3 integers.");
			} catch (System.NullReferenceException) {
				Console.WriteLine("\nAbort.");
				Environment.Exit(0);
			} finally {
				Environment.Exit(0);
			}
		}

		/// <summary>
		/// Find the modulus from this form:
		/// number ^ power mod modulus
		/// </summary>
		/// <param name="number">The base number</param>
		/// <param name="power">The power of base number</param>
		/// <param name="modulus">The number which number^power will be modulus to</param>
		/// <returns>The modulus</returns>
		public static long modPow(long number, long power, long modulus) {
			//raises a number to a power with the given modulus
			//when raising a number to a power, the number quickly becomes too large to
			//handle
			//you need to multiply numbers in such a way that the result is consistently
			//modulo-ed to keep it in the range
			//however you want the algorithm to work quickly - having a multiplication
			//loop would result in an O(n) algorithm!
			//the trick is to use recursion - keep breaking the problem down into smaller
			//pieces and use the modMult method to join them back together
			if (power == 0)
				return 1;
			else if (power % 2 == 0) {
				long halfpower = modPow(number, power / 2, modulus);
				return modMult(halfpower, halfpower, modulus);
			} else {
				long halfpower = modPow(number, power / 2, modulus);
				long firstbit = modMult(halfpower, halfpower, modulus);
				return modMult(firstbit, number, modulus);
			}
		}

		/// <summary>
		/// Find the modulus from this form:
		/// first * second mod modulus
		/// </summary>
		/// <param name="first">The first number</param>
		/// <param name="second">The second number</param>
		/// <param name="modulus">The modulus value</param>
		/// <returns>The modules</returns>
		public static long modMult(long first, long second, long modulus) {
			//multiplies the first number by the second number with the given modulus
			//a long can have a maximum of 19 digits. Therefore, if you're multiplying
			//two ten digits numbers the usual way, things will go wrong
			//you need to multiply numbers in such a way that the result is consistently
			//modulo-ed to keep it in the range
			//however you want the algorithm to work quickly - having an addition loop
			//would result in an O(n) algorithm!
			//the trick is to use recursion - keep breaking down the multiplication into
			//smaller pieces and mod each of the pieces individually
			if (second == 0)
				return 0;
			else if (second % 2 == 0) {
				long half = modMult(first, second / 2, modulus);
				return (half + half) % modulus;
			} else {
				long half = modMult(first, second / 2, modulus);
				return (half + half + first) % modulus;
			}
		}
	}
}
