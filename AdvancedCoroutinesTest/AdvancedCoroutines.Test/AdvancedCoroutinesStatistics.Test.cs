using System.Collections;
using AdvancedCoroutines.Statistics;
using NUnit.Framework;

namespace AdvancedCoroutines.Test
{
    [TestFixture]
    public class AdvancedCoroutinesStatistics_Test
    {
        [Test]
        public void AdvancedCoroutinesStatistics_Erase()
        {
            AdvancedCoroutinesStatistics.Erase();
            var routine = new Routine(enumerator(), this);
            var standaloneRoutine = new Routine(enumerator(), null);
            AdvancedCoroutinesStatistics.Add(routine, "A\nB");
            AdvancedCoroutinesStatistics.Add(standaloneRoutine, "A\nB");
            AdvancedCoroutinesStatistics.Erase();
            Assert.AreEqual(AdvancedCoroutinesStatistics.TotalCoroutinesStarts, 0);
            Assert.AreEqual(AdvancedCoroutinesStatistics.TotalCoroutinesStops, 0);
        }

        [Test]
        public void AdvancedCoroutinesStatistics_AddRoutine()
        {
            AdvancedCoroutinesStatistics.Erase();
            var routine = new Routine(enumerator(), this);
            AdvancedCoroutinesStatistics.Add(routine, "A\nB");
            Assert.AreEqual(AdvancedCoroutinesStatistics.TotalCoroutinesStarts, 1);
            Assert.AreEqual(AdvancedCoroutinesStatistics.TotalCoroutinesStops, 0);
            var stat = AdvancedCoroutinesStatistics.GetStatistics();
            Assert.AreEqual(stat.Count, 1);
            Assert.AreEqual(stat[routine].Length, 2);
        }

        private IEnumerator enumerator()
        {
            yield break;
        }
    }
}