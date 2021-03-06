﻿using LiveSplit.Model.Comparisons;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LiveSplit.Model
{
    [Serializable]
    public class Segment : ISegment
    {
        public Image Icon { get; set; }
        public string Name { get; set; }
        public Time PersonalBestSplitTime
        {
            get { return Comparisons[Run.PersonalBestComparisonName]; }
            set { Comparisons[Run.PersonalBestComparisonName] = value; }
        }
        public IComparisons Comparisons { get; set; }
        public Time BestSegmentTime { get; set; }
        public Time SplitTime { get; set; }
        public SegmentHistory SegmentHistory { get; set;}
        
        public Segment(
            string name, Time pbSplitTime = default(Time), 
            Time bestSegmentTime = default(Time), Image icon = null,
            Time splitTime = default(Time))
        {
            Comparisons = new CompositeComparisons();
            Name = name;
            PersonalBestSplitTime = pbSplitTime;
            BestSegmentTime = bestSegmentTime;
            SplitTime = splitTime;
            Icon = icon;
            SegmentHistory = new SegmentHistory();
        }

        public object Clone()
        {
            var newSegmentHistory = SegmentHistory.Clone();

            return new Segment(Name)
            {
                BestSegmentTime = BestSegmentTime,
                SplitTime = SplitTime,
                Icon = Icon, //TODO: Should be a clone //(this.Icon != null) ? this.Icon.Clone() as Image : null,
                SegmentHistory = newSegmentHistory,
                Comparisons = (IComparisons)Comparisons.Clone()
            };
        }
    }
}
