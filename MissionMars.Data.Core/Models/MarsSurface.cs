using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Data.Core.Model
{
    public class MarsSurface
    {
        public int FirstEdge { get; set; }
        public int SecondEdge { get; set; }

        public MarsSurface(int FirstEdge ,int SecondEdge)
        {
            FirstEdge = FirstEdge;
            SecondEdge = SecondEdge;
        }
    }
}
