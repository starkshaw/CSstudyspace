using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonteCarloAlgorithms {
	class Dice {
		private static Random ran = new Random();
		private int point;
		public Dice()
			: base() {
		}

		public void roll() {
			//this.point = (int)(ran.Next(0, 100) % 6) + 1;
			this.point = ran.Next(1, 7);			// Those two methods have different behaviors.
		}

		// Getter and Setter
		public int Point {
			get { return this.point; }
			set { this.point = value; }
		}

	}
}
