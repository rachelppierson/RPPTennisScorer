using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTests.Helpers
{
    internal static class NumberHelpers
    {
        internal static int RandomIntBetween(int lower, int upper) => new Random().Next(lower, upper);
    }
}
