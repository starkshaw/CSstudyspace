using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickProblem {
	class Stick {
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
			this.side1 = ran.Next(1, circumferrence);
			this.side2 = ran.Next(1, circumferrence - this.side1);
			this.side3 = circumferrence - this.side1 - this.side2;
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

	}
}
