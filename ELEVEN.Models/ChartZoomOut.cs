using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class ChartZoomOut
    {
        public int Index { get; set; }
        public double PosXStart { get; set; }
        public double PosXFinish { get; set; }
        public double PosYStart { get; set; }
        public double PosYFinish { get; set; }
    }

    public class FormState
    {
        public string FormUniqueName { get; set; }
        public int LockState { get; set; }
        public int VisibleState { get; set; }
        public string TimeFrame { get; set; }
    }
}
