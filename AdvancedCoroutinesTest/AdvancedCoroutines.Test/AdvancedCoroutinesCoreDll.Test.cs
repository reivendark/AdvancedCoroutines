using System;
using System.Collections;
using AdvancedCoroutines.Core;
using NUnit.Framework;

namespace AdvancedCoroutines.Test
{
    [TestFixture]
    public class AdvancedCoroutinesCoreDllTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdvancedCoroutinesCoreDll_StartCoroutine_AllParamsAreNull()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            _dll.StartCoroutine(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdvancedCoroutinesCoreDll_StartCoroutine_IEnumeratorIsNull()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            _dll.StartCoroutine(null, this);
        }

        [Test]
        public void AdvancedCoroutinesCoreDll_StartCoroutine_AsLinked()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            var routine = _dll.StartCoroutine(enumerator(), this);
            Assert.IsFalse(routine.IsStandalone);
        }

        [Test]
        public void AdvancedCoroutinesCoreDll_StartCoroutine_AsStandalone()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            var routine = _dll.StartCoroutine(enumerator(), null);
            Assert.IsTrue(routine.IsStandalone);
        }

        [Test]
        public void AdvancedCoroutinesCoreDll_StartCoroutine()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            var routine = _dll.StartCoroutine(enumerator(), this);
            Assert.False(Routine.IsNull(routine));
        }

        [Test]
        public void AdvancedCoroutinesCoreDll_StartStandaloneCoroutine()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            var standaloneRoutine = _dll.StartCoroutine(enumerator(), null);
            Assert.False(Routine.IsNull(standaloneRoutine));
        }

        [Test]
        public void AdvancedCoroutinesCoreDll_StopCoroutine()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            var routine = _dll.StartCoroutine(enumerator(), this);
            _dll.StopCoroutine(routine);
            Assert.True(Routine.IsNull(routine));
        }

        [Test]
        public void AdvancedCoroutinesCoreDll_StopAllCoroutines()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            var routine1 = _dll.StartCoroutine(enumerator(), this);
            var routine2 = _dll.StartCoroutine(enumerator(), this);
            _dll.StopAllCoroutines(this);
            Assert.True(Routine.IsNull(routine1));
            Assert.True(Routine.IsNull(routine2));
        }

        [Test]
        public void AdvancedCoroutinesCoreDll_StopStandaloneCoroutine()
        {
            var _dll = new Core.AdvancedCoroutinesCoreDll(null);
            var standaloneRoutine = _dll.StartCoroutine(enumerator(), null);
            _dll.StopCoroutine(standaloneRoutine);
            Assert.True(Routine.IsNull(standaloneRoutine));
        }

        private IEnumerator enumerator()
        {
            yield break;
        }
    }
}
