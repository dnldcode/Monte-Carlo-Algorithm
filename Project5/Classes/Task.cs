using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Classes
{
	class Task
	{
		public int WorstCase { get; }
		public int AverageCase { get; }
		public int BestCase { get; }

		public Task(int bestCase, int averageCase, int worstCase)
		{
			this.BestCase = bestCase;
			this.AverageCase = averageCase;
			this.WorstCase = worstCase;
		}

		public Task (String input)
		{
			input = input.Trim();

			int[] values = input.Split(',').Select(Int32.Parse).ToArray();

			if (values.Length != 3 || values[1] <= values[0] || values[2] <= values[1])
				throw new Exception("Invalid input provided while creating object Task");

			this.BestCase = values[0];
			this.AverageCase = values[1];
			this.WorstCase = values[2];
		}

		public int GetRandomEstimate()
		{
			switch(new Random().Next(0,3))
			{
				case 0:
					return WorstCase;
				case 1:
					return AverageCase;
				case 2:
					return BestCase;
			}

			throw new Exception("??");
		}
	}
}
