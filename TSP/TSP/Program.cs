using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace TSP {
	public class Program {

		public static string currentPath = Directory.GetCurrentDirectory();

		public static string filePath = string.Format(@"{0}//alltowns.txt", currentPath);

		public static void Main(string[] args) {
			Console.Write("Loading file... ");
			if (File.Exists(filePath)) {
				Console.WriteLine("Finished. Organizing... ");
				string[] rawData = File.ReadAllLines(filePath);
				string[,] allData = new String[rawData.Length, 4];
				for (int i = 0; i < allData.GetLength(0); i++) {
					string[] tmp = rawData[i].Split(',');
					for (int j = 0; j < allData.GetLength(1); j++) {
						allData[i, j] = tmp[j];
					}
				}
				double[,] coordinates = new double[allData.GetLength(0), 2];
				for (int i = 0; i < coordinates.GetLength(0); i++) {
					coordinates[i, 0] = double.Parse(allData[i, 2]);
					coordinates[i, 1] = double.Parse(allData[i, 3]);
				}
				Console.WriteLine("Finished.\nCalculating... ");
				double[,] distanceTable = new double[allData.GetLength(0), allData.GetLength(0)];
				for (int i = 0; i < distanceTable.GetLength(0); i++) {
					for (int j = 0; j < distanceTable.GetLength(1); j++) {
						distanceTable[i, j] = DistanceCal.CalDistanceByIndex(i, j, coordinates);
						Console.Write(Math.Round(distanceTable[i, j], 0) + "\t");
					}
					Console.WriteLine();
				}
				for (int i = 0; i < allData.GetLength(0); i++) {
					ArrayList unvisitedList = new ArrayList();
					for (int j = 0; i < allData.GetLength(0); j++) {
						unvisitedList.Add(i);
					}
					while (unvisitedList.Count != 0) {
						
					}
				}
			} else {
				Console.WriteLine("Failed.\nFile {0} does not exist.", filePath);
				Environment.Exit(-1);
			}
		}
	}
}
