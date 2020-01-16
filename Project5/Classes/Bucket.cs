using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Classes
{
	class Bucket
	{
		public Dictionary<int, int> buckets = new Dictionary<int, int>();
		private List<int> values = new List<int>();
		private int bucketCount;
		private int rangeLow;
		private int rangeHigh;
		private int stepSize;
		private int numberOfIterations;

		public Bucket(int bucketCount, int rangeLow, int rangeHigh, int numberOfIterations)
		{
			this.bucketCount = bucketCount;
			this.rangeLow = rangeLow;
			this.rangeHigh = rangeHigh;
			this.stepSize = (Math.Abs(rangeHigh) - Math.Abs(rangeLow)) / bucketCount;
			this.numberOfIterations = numberOfIterations;

			this.initBuckets();
		}

		public void initBuckets()
		{
			for (int i = 0; i < this.bucketCount; i++)
				this.buckets.Add(this.rangeLow + (this.stepSize * i) , 0);
		}

		public void addValueToBucket(int val)
		{
			int idx = this.getBucketIdxForValue(val);
			this.buckets[this.buckets.ElementAt(idx).Key]++;
			values.Add(val);
		}

		public (int, int, int) CalculateTime()
		{
			return (this.values.Min(), this.values.Max(), (int)this.values.Average());
		}

		public int getBucketIdxForValue(int val)
		{
			int  idx = 0;
			while ((idx < this.bucketCount - 1) && val > this.rangeLow + this.stepSize * (idx + 1))
				idx++;

			return idx;
		}

		public override string ToString()
		{
			String output = "";
			foreach (KeyValuePair<int, int> b in this.buckets)
				output += $"{b.Key} days : {(b.Value / (double)this.numberOfIterations) * 100}%\n";

			return output;
		}

		public void ToAccumulated()
		{
			for (int i = 1; i < buckets.Count; i++)
				buckets[buckets.ElementAt(i).Key] = buckets.ElementAt(i - 1).Value + buckets.ElementAt(i).Value;
		}
	}
}
