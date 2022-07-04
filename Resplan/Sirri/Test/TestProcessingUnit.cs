using System;
using System.Collections.Generic;
using NUnit.Framework;
using Resplan.Sirri.ProcessingUnit;

namespace Resplan.Sirri.Test
{
    [TestFixture]
    public class TestProcessingUnit
    {
        private IProcessingUnit ProcessingUnit { get; set; } = null!;

        [Test]
        public void TestCreation()
        {
            try
            {
                ProcessingUnit = new ProcessingUnit.ProcessingUnit(new List<AbstractEffect>().AsReadOnly());
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                ProcessingUnit = new ProcessingUnit.ProcessingUnit(new List<AbstractEffect> { new Compressor(2), 
                        new Gate(2) }.AsReadOnly());
                Assert.AreEqual(2, ProcessingUnit.Size);
                Assert.AreEqual("Compressor", ProcessingUnit.GetEffectAtPosition(0).Name);
                Assert.AreEqual("Gate", ProcessingUnit.GetEffectAtPosition(1).Name);
            }
        }

        [Test]
        public void TestAddition()
        {
            ProcessingUnit = new ProcessingUnit.ProcessingUnit(new List<AbstractEffect> { new Compressor(2), 
                new Gate(2) }.AsReadOnly());
            ProcessingUnit.AddEffectAtPosition(2, new HighPassFilter(2));
            Assert.AreEqual("High Pass", ProcessingUnit.GetEffectAtPosition(2).Name);
            try
            {
                ProcessingUnit.AddEffectAtPosition(-1, new Compressor(1));
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                try
                {
                    ProcessingUnit.AddEffectAtPosition(5, new Compressor(1));
                    Assert.Fail();
                }
                catch (IndexOutOfRangeException) {}
            }
        }

        [Test]
        public void TestRemoval()
        {
            ProcessingUnit = new ProcessingUnit.ProcessingUnit(new List<AbstractEffect> { new Compressor(2), 
                new Gate(2), new HighPassFilter(2)}.AsReadOnly());
            ProcessingUnit.RemoveEffectAtPosition(1);
            Assert.AreEqual(2, ProcessingUnit.Effects.Count);
            Assert.AreEqual("Compressor", ProcessingUnit.GetEffectAtPosition(0).Name);
            Assert.AreEqual("High Pass", ProcessingUnit.GetEffectAtPosition(1).Name);
            try
            {
                ProcessingUnit.RemoveEffectAtPosition(-1);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                try
                {
                    ProcessingUnit.RemoveEffectAtPosition(3);
                    Assert.Fail();
                }
                catch (IndexOutOfRangeException) {}
            }
            ProcessingUnit.RemoveEffectAtPosition(0);
            try
            {
                ProcessingUnit.RemoveEffectAtPosition(0);
                Assert.Fail();
            }
            catch (InvalidOperationException) {}
        }
    }
}