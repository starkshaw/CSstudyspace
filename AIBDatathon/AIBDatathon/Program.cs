using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
// Zhenbang Xiao
namespace AIBDatathon {
	class Program {
		static void Main(string[] args) {
			// Initialize
			int maxID = 0;
			double[] RatingInfo;
			Console.WriteLine("Loading files...");
			string currentPath = Directory.GetCurrentDirectory();
			//Console.WriteLine(@"{0}\data\Ratings.csv", currentPath);
			string[] Ratings = File.ReadAllLines(string.Format(@"{0}\data\Ratings.txt", currentPath));
			string[] Movies = File.ReadAllLines(string.Format(@"{0}\data\Movies.txt", currentPath));
			string[,] splitedRatings = new string[Ratings.Length, 3];
			// Initialize splitedRatings
			Console.WriteLine("Initialize splitedRatings...");
			for (int i = 0; i < splitedRatings.GetLength(0); i++) {
				for (int j = 0; j < splitedRatings.GetLength(1); j++) {
					splitedRatings[i, j] = "0";
				}
			}
			// Split Ratings
			Console.WriteLine("Spliting Ratings...");
			for (int i = 0; i < splitedRatings.GetLength(0); i++) {
				string[] tmp = Ratings[i].Split('\t');
				for (int j = 0; j < splitedRatings.GetLength(1); j++) {
					splitedRatings[i, j] = tmp[j];
				}
			}
			// Get maximum movie ID
			Console.WriteLine("Obtaining maximum movie ID...");
			for (int i = 0; i < splitedRatings.GetLength(0); i++) {
				if (maxID < int.Parse(splitedRatings[i, 1])) {
					maxID = int.Parse(splitedRatings[i, 1]);
				}
			}
			// Initialize movie
			Console.WriteLine("Initialize splitedMovies...");
			string[,] splitedMovies = new string[maxID, 3];
			for (int i = 0; i < splitedMovies.GetLength(0); i++) {
				for (int j = 0; j < splitedMovies.GetLength(1); j++) {
					splitedMovies[i, j] = "null";
				}
			}
			// Split Movies
			Console.WriteLine("Spliting Movies...");
			for (int i = 0; i < splitedMovies.GetLength(0); i++) {
				string[] tmp = Movies[i].Split('\t');
				for (int j = 0; j <= 1; j++) {
					splitedMovies[i, j] = tmp[j];
				}
			}
			// Get the average rating of each movie
			Console.WriteLine("Calculating average...");
			RatingInfo = getAverage(splitedRatings, maxID);
			// Merge the average to the movie array
			Console.WriteLine("Merging...");
			for (int i = 0; i < splitedMovies.GetLength(0); i++) {
				splitedMovies[i, 2] = RatingInfo[i] + "";
			}
			// Handle NaN
			Console.WriteLine("Handling exceptions...");
			string tmpNaNScore = "";
			string tmpNaNNo = "";
			string tmpNaNTitle = "";
			int occurance = 0;
			for (int i = 0; i < splitedMovies.GetLength(0); i++) {
				if ((splitedMovies[i, 2] == "非数字" || splitedMovies[i, 2] == "NaN") && (i < splitedMovies.GetLength(0) - 1 - occurance)) {
					tmpNaNScore = splitedMovies[splitedMovies.GetLength(0) - 1 - occurance, 2];
					tmpNaNNo = splitedMovies[splitedMovies.GetLength(0) - 1 - occurance, 0];
					tmpNaNTitle = splitedMovies[splitedMovies.GetLength(0) - 1 - occurance, 1];
					splitedMovies[splitedMovies.GetLength(0) - 1 - occurance, 2] = splitedMovies[i, 2];
					splitedMovies[splitedMovies.GetLength(0) - 1 - occurance, 0] = splitedMovies[i, 0];
					splitedMovies[splitedMovies.GetLength(0) - 1 - occurance, 1] = splitedMovies[i, 1];
					splitedMovies[i, 2] = tmpNaNScore;
					splitedMovies[i, 0] = tmpNaNNo;
					splitedMovies[i, 1] = tmpNaNTitle;
					occurance++;
				}
			}
			// Sort with the array on decreasing score
			Console.WriteLine("Sorting...");
			string tmpScore = "";
			string tmpNo = "";
			string tmpTitle = "";
			for (int i = 0; i < splitedMovies.GetLength(0); i++) {
				for (int j = splitedMovies.GetLength(0) - 1; j > i; j--) {
					if (double.Parse(splitedMovies[j, 2]) > double.Parse(splitedMovies[j - 1, 2])) {
						tmpScore = splitedMovies[j - 1, 2];
						tmpNo = splitedMovies[j - 1, 0];
						tmpTitle = splitedMovies[j - 1, 1];
						splitedMovies[j - 1, 2] = splitedMovies[j, 2];
						splitedMovies[j - 1, 0] = splitedMovies[j, 0];
						splitedMovies[j - 1, 1] = splitedMovies[j, 1];
						splitedMovies[j, 2] = tmpScore;
						splitedMovies[j, 0] = tmpNo;
						splitedMovies[j, 1] = tmpTitle;
					}
				}
			}
			// Save
			string[] output = new string[maxID];
			for (int i = 0; i < output.GetLength(0); i++) {
				output[i]=string.Format("{0}\t{1}\t{2}\t{3}",i+1,splitedMovies[i,0],splitedMovies[i,1],splitedMovies[i,2]);
			}
			System.IO.File.WriteAllLines(string.Format(@"{0}\data\output.txt",currentPath), output);
			Console.WriteLine("File saved to {0}.", string.Format(@"{0}\data\output.txt", currentPath));
			//print2DString(splitedMovies);

		}

		public static double[] getAverage(string[,] FilmWithRate, int maxFilmID) {
			string[,] sorted = new string[maxFilmID, 3];
			double[] average = new double[maxFilmID];
			for (int i = 0; i < sorted.GetLength(0); i++) {
				int sum = 0;
				int people = 0;
				for (int j = 0; j < FilmWithRate.GetLength(0); j++) {
					if (i + 1 == int.Parse(FilmWithRate[j, 1])) {
						sum = sum + int.Parse(FilmWithRate[j, 2].Substring(0, 1));
						people++;
					}
				}
				sorted[i, 0] = i + 1 + "";
				sorted[i, 1] = sum + "";
				sorted[i, 2] = people + "";
			}
			for (int i = 0; i < average.Length; i++) {
				average[i] = (double)(int.Parse(sorted[i, 1])) / (double)(int.Parse(sorted[i, 2]));
			}
			return average;
		}

		public static void print2DString(string[,] String) {
			for (int i = 0; i < String.GetLength(0); i++) {
				for (int j = 0; j < String.GetLength(1); j++) {
					Console.Write("{0} ", String[i, j]);
				}
				Console.WriteLine();
			}
		}
	}
}
