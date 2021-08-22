using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Tests.Helpers
{
    public static class FileDividerUtils
    {
        public static void AssertIsInAscendingOrder(List<int> updates)
        {
            var orderedUpdates = updates.OrderBy(i => i).ToList();
            Assert.IsTrue(orderedUpdates.SequenceEqual(updates));
        }
    }
}
