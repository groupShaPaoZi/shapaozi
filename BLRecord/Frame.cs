using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLRecord
{
    public class Frame
    {
        private int itsScore;
        public int GetScore()
        {
            return itsScore;
        }

        public void Add(int pins)
        {
            itsScore += pins;
        }
    }


}
