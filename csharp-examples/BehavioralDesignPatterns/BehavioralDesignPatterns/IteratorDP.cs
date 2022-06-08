using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehavioralDesignPatterns
{
    public class RadioStation
    {
        private float mFrequency;
        public RadioStation(float frequency)
        {
            mFrequency = frequency;
        }
        public float GetFrequency()
        {
            return this.mFrequency;
        }
    }

    //iterator
    class StationList : IEnumerable<RadioStation>
    {
        List<RadioStation> mStations = new List<RadioStation> ();
        public RadioStation this[int index]
        {
            get { return mStations [index]; }
            set { mStations.Insert(index, value); }
        }
        public void Add(RadioStation station)
        {
            mStations.Add(station);
        }
        public void Remove(RadioStation station)
        {
            mStations.Remove(station);
        }
        public IEnumerator<RadioStation> GetEnumerator()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach(var x in mStations)
            {
                yield return x;
            }
        }
    }
    internal class IteratorDP
    {
        public void Main()
        {
            var stations = new StationList();
            var station1 = new RadioStation(89);
            stations.Add(station1);
            var station2 = new RadioStation(101);
            stations.Add(station2);
            var station3 = new RadioStation(102);
            stations.Add(station3);
            foreach(var x in stations)
            {
                Console.WriteLine(x.GetFrequency());
            }
            var q = stations.Where(x => x.GetFrequency() == 89).FirstOrDefault();
            Console.WriteLine(q.GetFrequency());
        }
    }
}
