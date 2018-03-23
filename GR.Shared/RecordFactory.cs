using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    public abstract class RecordFactory
    {
        public abstract Record GetRecord(string[] input);
    }
}
