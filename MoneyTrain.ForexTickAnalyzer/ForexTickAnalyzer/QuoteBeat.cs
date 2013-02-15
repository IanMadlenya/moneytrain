﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForexTickAnalyzer
{
    class QuoteBeat
    {
        private Quote prev;
        
        public QuoteBeat()
        {
            MaxDown = 1;
            MaxUp = -1;
        }

        internal void Add(Quote quote)
        {
            if (prev == null)
            {
                prev = quote;
                return;
            }

            DeltaAsk = (quote.Ask * 100000 - prev.Ask * 100000) / 10;
            DeltaBid = (quote.Bid * 100000 - prev.Bid * 100000) / 10;

            MaxDown = Math.Min(Math.Min(DeltaAsk, DeltaBid), MaxDown);
            MaxUp = Math.Max(Math.Max(DeltaAsk, DeltaBid), MaxUp);
            prev = quote;
        }

        public double DeltaAsk { get; set; }

        public double DeltaBid { get; set; }

        public double MaxDown { get; set; }

        public double MaxUp { get; set; }
    }
}
