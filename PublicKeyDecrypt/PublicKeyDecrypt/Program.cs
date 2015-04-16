using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicKeyDecrypt {
	class Program {
		static void Main(string[] args) {
			// Initialize
			long[] publicKey = new long[3];
			long[] cipher = new long[2];
			Console.WriteLine("\nEnter the public key consists by 3 integers, use comma only to separate.\n");
			Console.Write("Public Key: ");
			try {
				string[] inputPubKey = Console.ReadLine().Split(',');
				for (int i = 0; i < inputPubKey.Length; i++) {
					publicKey[i] = long.Parse(inputPubKey[i]);
				}
				long powAns = modPow(publicKey[0], publicKey[1], publicKey[2]);
				//Console.WriteLine("The modulus is {0}.", powAns);
				Console.WriteLine("\nEnter the cipher consists by 2 integers, use comma only to separate.\n");
				Console.Write("Cipher: ");
				string[] inputCipher = Console.ReadLine().Split(',');
				if (inputCipher.Length == 2) {
					for (int i = 0; i < inputCipher.Length; i++) {
						cipher[i] = long.Parse(inputCipher[i]);
					}
					Console.WriteLine("\nCracking...");
					Console.WriteLine("\n{0} ^ x mod {1} = {2}", publicKey[1], publicKey[0], publicKey[2]);
					long privateKey = findPow(publicKey[1], publicKey[0], publicKey[2]);
					Console.WriteLine("x = {0}\n\tis the private key.", privateKey);
					Console.WriteLine("\nImplementing to cipher...");
					long modVal = modPow(cipher[0], publicKey[0] - 1 - privateKey, publicKey[0]);
					Console.WriteLine("\n{0} ^ ({1} - 1 - {2}) % {3} = {4}", cipher[0], publicKey[0], privateKey, publicKey[0], modVal);
					Console.WriteLine("{0} * {1} % {2} = {3}\n\tis the encrypted message.", modVal, cipher[1], publicKey[0], modVal * cipher[1] % publicKey[0]);
				} else {
					Console.WriteLine("\nERROR: Overloaded carries.");
					Console.WriteLine("The cipher shall only contains 2 integers.");
					Environment.Exit(0);
				}
				//Console.WriteLine(modPow(23, 23, 29));
				//Console.WriteLine(findPow(2, 29, 3));
				//Console.WriteLine(modMult(23, 27, 5));
				//Console.WriteLine("Implement the cipher: {0}.", modMult(15268076, 743675, powAns));
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

		/// <summary>
		/// Find the power in the following form
		/// number ^ power mod modulus = answer
		/// </summary>
		/// <param name="number">The first number</param>
		/// <param name="modulus">The modulus number</param>
		/// <param name="answer">The answer</param>
		/// <returns>The power value</returns>
		public static long findPow(long number, long modulus, long answer) {
			Boolean flag = false;
			long result = 0;
			for (long i = 0; i < modulus; i++) {
				if (modPow(number, i, modulus) == answer) {
					result = i;		// Send the answer to outer loop
					flag = true;	// The flag of return
					break;
				}
			}
			if (flag == true) {
				return result;
			} else {
				return 0;
			}
		}
	}
}
