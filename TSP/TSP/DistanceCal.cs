using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP {
	public static class DistanceCal {

		public const double RADIUS = 6371;               // The mean radius of earth

		public static double calDistance(double lat1, double lon1, double lat2, double lon2) {
			double dlon = ToRadians(lon2 - lon1);   // Delta longitude
			double dlat = ToRadians(lat2 - lat1);   // Delta latitude

			double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2)
					+ Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2))
					* Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

			return RADIUS * c;
		}

		public static double ToRadians(this double val) {
			return (Math.PI / 180) * val;
		}

		public static double CalDistanceByIndex(int index1, int index2, double[,] coordinates) {
			return DistanceCal.calDistance(
					coordinates[index1,0],
					coordinates[index1,1],
					coordinates[index2,0],
					coordinates[index2,1]);
		}

	}
}
