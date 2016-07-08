using System;
using System.Collections;
using NUnit.Framework;

namespace AdvancedCoroutines.Test
{
    [TestFixture]
    public class Routine_Test
    {
        Routine routine;

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Routine_CreateRoutine_ParamsAreNulls()
        {
            routine = new Routine(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Routine_CreateRoutine_EnumeratorIsNull()
        {
            routine = new Routine(null, this);
        }

        [Test]
        public void Routine_CreateRoutine_IsStandalone()
        {
            routine = new Routine(enumerator(), null);
            Assert.IsTrue(routine.IsStandalone);
        }

        [Test]
        public void Routine_CreateRoutine_IsPausedState()
        {
            routine = new Routine(enumerator(), this);
            Assert.IsFalse(routine.IsPaused());
        }

        [Test]
        public void Routine_SetOnPause()
        {
            routine = new Routine(enumerator(), this);
            routine.Pause();
            Assert.IsTrue(routine.IsPaused());
        }

        [Test]
        public void Routine_Resume()
        {
            routine = new Routine(enumerator(), this);
            routine.Pause();
            routine.Resume();
            Assert.IsFalse(routine.IsPaused());
        }

        private IEnumerator enumerator()
        {
            yield break;
        }
    }
}