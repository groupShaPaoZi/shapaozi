using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLRecord;

namespace BLRecordTest
{
    [TestClass]
    public class TestGame
    {
        private Game g;

        [TestMethod]
        public void setUp()
        {
            g = new Game();
        }

        [TestMethod]
        public void testOneThrows()
        {
            g.Add(5);
            Assert.AreEqual(5, g.Score());
            Assert.AreEqual(1, g.GetCurrentFrame());
        }

        [TestMethod]
        public void testTowThrowsNoMark()
        {
            g.Add(5);
            g.Add(4);
            Assert.AreEqual(9, g.Score());
            Assert.AreEqual(2, g.GetCurrentFrame());
        }

        [TestMethod]
        public void TestFousThrowsNoMark()
        {
            g.Add(5);
            g.Add(4);
            g.Add(7);
            g.Add(2);
            Assert.AreEqual(18, g.Score());
            Assert.AreEqual(9, g.ScoreForFrame(1));
            Assert.AreEqual(18, g.ScoreForFrame(2));
            Assert.AreEqual(3, g.GetCurrentFrame());
        }

        [TestMethod]
        public void testSimpleSpare()
        {
            g.Add(3);
            g.Add(7);
            g.Add(3);
            Assert.AreEqual(13, g.ScoreForFrame(1));
            Assert.AreEqual(2, g.GetCurrentFrame());
        }

        [TestMethod]
        public void testSimpleFrameAfterSpare()
        {
            g.Add(3);
            g.Add(7);
            g.Add(3);
            g.Add(2);
            Assert.AreEqual(13, g.ScoreForFrame(1));
            Assert.AreEqual(18, g.ScoreForFrame(2));
            Assert.AreEqual(18, g.Score());
            Assert.AreEqual(3, g.GetCurrentFrame());
        }

        [TestMethod]
        public void test()
        {
            g.Add(10);
            g.Add(3);
            g.Add(6);
            Assert.AreEqual(19, g.ScoreForFrame(1));
            Assert.AreEqual(28, g.Score());
            Assert.AreEqual(3, g.GetCurrentFrame());
        }

        [TestMethod]
        public void testPerfectGame()
        {
            for (int i = 0; i < 12; i++)
            {
                g.Add(10);
            }
            Assert.AreEqual(300, g.Score());
            Assert.AreEqual(11, g.GetCurrentFrame());
        }

        [TestMethod]
        public void testEndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                g.Add(0);
                g.Add(0);
            }
            g.Add(2);
            g.Add(8);
            g.Add(10);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void testSampleGame()//原记分卡上的数据
        {
            g.Add(1);
            g.Add(4);
            g.Add(4);
            g.Add(5);
            g.Add(6);
            g.Add(5);
            g.Add(6);
            g.Add(6);
            g.Add(10);
            g.Add(0);
            g.Add(1);
            g.Add(7);
            g.Add(3);
            g.Add(6);
            g.Add(4);
            g.Add(10);
            g.Add(2);
            g.Add(8);
            g.Add(6);
            Assert.AreEqual(133, g.Score());
        }

        [TestMethod]
        public void testHeartBreak()//11次全中，最后一次仅中9个
        {
            for (int i = 0; i < 11; i++)
                g.Add(10);
            g.Add(9);
            Assert.AreEqual(299, g.Score());
        }

        [TestMethod]
        public void testTenthFrameSpare()
        {
            for (int i = 0; i < 9; i++)
                g.Add(10);
            g.Add(9);
            g.Add(1);
            g.Add(1);
            Assert.AreEqual(270, g.Score());
        }
    }
}
