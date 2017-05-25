using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLRecord;

namespace BLRecordTest
{
    [TestClass]
    public class TestFrame
    {
        //Frame------------------------------
        [TestMethod]
        public void TestScoreNoThrow()
        {
            Frame f = new Frame();
            Assert.AreEqual(0, f.GetScore());
        }

        [TestMethod]
        public void TestAddOneThrow()
        {
            Frame f = new Frame();
            f.Add(5);
            Assert.AreEqual(5, f.GetScore());
        }

        //Game------------------------------
        [TestMethod]
        public void TestTowThrowsNoMark()
        {
            Game g = new Game();
            g.Add(5);
            g.Add(4);
            Assert.AreEqual(9, g.Score());
        }

        [TestMethod]
        public void TestFousThrowsNoMark()
        {
            Game g = new Game();
            g.Add(5);
            g.Add(4);
            g.Add(7);
            g.Add(2);
            Assert.AreEqual(18,g.Score());
            Assert.AreEqual(9,g.ScoreForFrame(1));
            Assert.AreEqual(18,g.ScoreForFrame(2));
        }

        [TestMethod]
        public void testSimpleSpare()
        {
            Game g = new Game();
        }
    }
}
