using NUnit.Framework;
using Resplan.Antonini.Utility;

namespace Resplan.Antonini.Test
{
    [TestFixture]
    public class TestMapToSet
    {
        [Test]
        public void TestCreation()
        {
            IMapToSet<int, int> map = new HashMapToSet<int, int>();
            Assert.True(map.IsEmpty());
        }

        [Test]
        public void TestAddingFirstSet()
        {
            IMapToSet<int, int> map = new HashMapToSet<int, int>();
            map.Put(1, 1);
            Assert.True(map.Get(1)!.Contains(1));
        }

        [Test]
        public void TestMappingMultipleElementsAtSameKey()
        {
            IMapToSet<int, int> map = new HashMapToSet<int, int>();
            map.Put(1, 1);
            map.Put(1, 2);
            map.Put(1, 3);
            Assert.AreEqual(3, map.Get(1)!.Count);
        }

        [Test]
        public void TestRemoveElementFromSet()
        {
            IMapToSet<int, int> map = new HashMapToSet<int, int>();
            map.Put(1, 1);
            map.Put(1, 2);
            map.Put(1, 3);
            map.Remove(1, 2);
            Assert.AreEqual(2, map.Get(1)!.Count);
            Assert.False(map.Get(1)!.Contains(2));
        }

        [Test]
        public void TestRemoveLastSetItem()
        {
            IMapToSet<int, int> map = new HashMapToSet<int, int>();
            map.Put(1, 1);
            map.Put(2, 1);
            map.Remove(1, 1);
            Assert.False(map.ContainsKey(1));
        }
    }
}