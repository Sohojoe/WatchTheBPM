using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace WatchBPMWatchKitExtension
{
	public class BPMModel 
	{
		const long kMaxTime = 5000;
		const long kMaxTaps = 10;
		Stopwatch stopwatch = new Stopwatch();
		List<double> elapsedMilliseconds = new List<double>();


		double mean(List<double> data)
		{
			if (data.Count == 0)
				return 0;				
			var total = data.Sum ();
			var average = total / data.Count;
			return average;
		}

		public double MeanBPM { get { return mean (elapsedMilliseconds);} }

		public List<int> ModesBPM{ get {
				var modesList = elapsedMilliseconds
					.GroupBy(values => values)
					.Select(valueCluster =>
						new
						{
							Value = (int)valueCluster.Key,
							Occurrence = valueCluster.Count(),
						})
					.ToList();

				var maxOccurrence = modesList
					.Max(g => g.Occurrence);
				return modesList
					.Where(x => x.Occurrence == maxOccurrence && maxOccurrence > 0) // Thanks Rui!
					.Select(x => x.Value)
					.ToList();
			}}


		public double ModeBPM { get {
				if (ModesBPM.Count == 0)
					return 0;
				return (ModesBPM.Sum() / ModesBPM.Count);
			}}
		public double MedianBPM { get {
				var orderedList = elapsedMilliseconds
					.OrderBy(numbers => numbers)
					.ToList();

				int listSize = orderedList.Count;
				double result;

				if (listSize%2 == 0) // even
				{
					int midIndex = listSize/2;
					result = ((orderedList.ElementAt(midIndex - 1) +
						orderedList.ElementAt(midIndex))/2);
				}
				else // odd
				{
					double element = (double) listSize/2;
					element = Math.Round(element, MidpointRounding.AwayFromZero);

					result = orderedList.ElementAt((int) (element - 1));
				}

				return result;
			}}
		public double VarianceBPM { get {
				var mu = MeanBPM;
				var data = elapsedMilliseconds.Select (x => Math.Pow((x - mu),2)).ToList ();
				return mean (data);
			}}
		public double StdDevBPM { get { return Math.Sqrt (VarianceBPM); } }

				
		public BPMModel ()
		{
			stopwatch.Start ();
		}
//		long last = -500000;
		public void RecordTap ()
		{
			var lenght = stopwatch.ElapsedMilliseconds;
			if (lenght < kMaxTime) {
				double bpm = (60 * 1000) / (double)lenght;
				elapsedMilliseconds.Add (bpm);
				while (elapsedMilliseconds.Count>kMaxTaps){
					elapsedMilliseconds.RemoveAt(0);
				}
//				Console.WriteLine (string.Format("{0}: {1}",Math.Round (bpm), lenght) );

				Console.WriteLine (string.Format("Mean:{0} Median:{1} Varance:{2} StdDev:{3} Last:{4}",Math.Round (MeanBPM),Math.Round (MedianBPM),Math.Round (VarianceBPM, 2), Math.Round (StdDevBPM,2), Math.Round(bpm)) );
			}
			stopwatch.Restart();
		}
	}
}

