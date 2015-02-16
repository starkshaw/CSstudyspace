using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickProblem {
	public class Stick {
		// Initialize
		private Random ran = new Random();
		private int circumferrence = 0;		// Define the Circumferrence
		private int side1, side2, side3;
		// Constructors
		public Stick()
			: base() {
			circumferrence = 100;
		}

		public Stick(int Circumferrence) {
			this.circumferrence = Circumferrence;
		}

		/// <summary>
		/// Input / Output of Circumferrence
		/// </summary>
		public int Circumferrence {
			get { return circumferrence; }
			set { this.circumferrence = value; }
		}

		/// <summary>
		/// Break the stick into 3 random pieces.
		/// </summary>
		/// <returns>The length of 3 broken pieces.</returns>
		public int[] separate() {
			int[] sides = new int[3];
		examine:
			this.side1 = ran.Next(1, circumferrence);
			this.side2 = ran.Next(1, circumferrence - this.side1);
			this.side3 = circumferrence - this.side1 - this.side2;
			if (this.side1 + this.side2 == circumferrence) {
				goto examine;
			}
			sides[0] = this.side1;
			sides[1] = this.side2;
			sides[2] = this.side3;
			sort(sides);
			return sides;
		}

		/// <summary>
		/// Sort those broken pieces into ascending order.
		/// </summary>
		/// <param name="sides">The array of 3 sides.</param>
		private void sort(int[] sides) {
			for (int i = 1; i < sides.Length; i++) {
				int tmp = sides[i];
				int j = i;
				while (j > 0 && sides[j - 1] >= tmp) {
					sides[j] = sides[j - 1];
					j--;
				}
				sides[j] = tmp;
			}
		}

		// Method for Advanced Stick Problem
		/// <summary>
		/// This method is for Advanced Stick Problem to simulate a stick randomly break into several times
		/// </summary>
		/// <param name="times">The amount of time it break. The value must greater or equal than 2.</param>
		/// <param name="length">The length of stick.</param>
		/// <returns>An integer array consists lengths of broken sticks.</returns>
		public int[] separate(int times, int length) {
			int[] sides = new int[times];
			examine:
			int sum = 0;	// Store the length of broken sticks
			for (int i = 0; i < sides.GetLength(0) - 1; i++) {
				sides[i] = ran.Next(1, length - sum);
				sum += sides[i];
			}
			if (sum == length) {
				goto examine;
			}
			sides[sides.GetLength(0) - 1] = length - sum;
			sort(sides);
			return sides;
		}
	}
}
