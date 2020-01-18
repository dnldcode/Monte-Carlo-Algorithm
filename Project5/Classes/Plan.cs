using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task = Project5.Classes.Task;

namespace Project5.Classes
{
	class Plan
	{
		List<Task> tasks = new List<Task>();
		Random random = new Random();
		public int NumberOfIterations { get; set; } = 10000;

		public void AddTask(Task task)
		{
			this.tasks.Add(task);
		}

		public (int, int, int) CalculateTime()
		{
			int minimum = 0, maximum = 0, average = 0;

			foreach(Task task in tasks)
			{
				minimum += task.BestCase;
				maximum += task.WorstCase;
				average += task.AverageCase;
			}

			return (minimum, maximum, average);
		}

		public Bucket Simulate()
		{
			int totalCostOfRandomPlans = 0;
			var values = CalculateTime();
			int dif = (values.Item2 - values.Item1);
			int div = (dif / 10);
			if (dif == 0 && div == 0) dif = div = 1;
			Bucket bucket = new Bucket(dif / (div != 0 ? div : 1), values.Item1, values.Item2, this.NumberOfIterations);

			for (int i = 0; i < NumberOfIterations; i++)
			{
				int randomPlanCost = 0;
				foreach (Task task in tasks)
					randomPlanCost += task.GetRandomEstimate();

				//Console.WriteLine(randomPlanCost);
				bucket.addValueToBucket(randomPlanCost);

				totalCostOfRandomPlans += randomPlanCost;
			}

			return bucket;
		}
	}
}
