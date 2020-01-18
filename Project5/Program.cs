using Project5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task = Project5.Classes.Task;

namespace Project5
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Enter tasks in the following format: c1,c2,...\nwherex is cost");
				Console.WriteLine("Type END to finish entering tasks");

				int i = 0;
				Plan plan = new Plan();

				while (true)
				{
					Console.Write($"Task #{++i}: ");
					String input = Console.ReadLine();

					if (input.Trim().ToUpper() == "END")
						break;

					plan.AddTask(new Task(input));
				}

				Bucket bucket = plan.Simulate();
				var calculatedTime = bucket.CalculateTime();
				Console.WriteLine($"After probing {plan.NumberOfIterations} random plans, the results are:");
				Console.WriteLine($"Minimum = {calculatedTime.Item1} days");
				Console.WriteLine($"Maximum = {calculatedTime.Item2} days");
				Console.WriteLine($"Average = {calculatedTime.Item3} days");

				Console.WriteLine("Probability of finishing the plan in:\n" + bucket);

				bucket.ToAccumulated();

				Console.WriteLine("Accumulated probability of finishing the plan in or before:\n" + bucket);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error occured: " + e.Message);
			}
		}
	}
}
