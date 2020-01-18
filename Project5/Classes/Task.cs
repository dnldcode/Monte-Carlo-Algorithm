using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Classes
{
	class Task
	{
		private List<int> estimations = new List<int>();
		public int WorstCase { get; }
		public int AverageCase { get; }
		public int BestCase { get; }
		private Random random = new Random();

		public Task(int bestCase, int averageCase, int worstCase)
		{
			this.BestCase = bestCase;
			this.AverageCase = averageCase;
			this.WorstCase = worstCase;
		}

		public Task (String input)
		{
			input = input.Trim();

			estimations = input.Split(',').Select(Int32.Parse).ToList();

			if (estimations.Count != estimations.Distinct().ToList().Count)
				throw new Exception("Inable to create task. Estimations could not repeat.");

			if (estimations.Count < 1)
				throw new Exception("Invalid input provided while creating object Task");

			this.BestCase = estimations.Min();
			this.AverageCase = (int)estimations.Average();
			this.WorstCase = estimations.Max();
		}

		public int GetRandomEstimate()
		{
			return estimations[random.Next(0, estimations.Count)];
		}
	}
}
