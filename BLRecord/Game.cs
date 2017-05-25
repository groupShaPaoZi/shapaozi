using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLRecord
{
    public class Game
    {
        private int itsScore = 0;
        private int[] itsThrows = new int[21];
        private int itsCurrentThrow = 0;
        //private bool firstThrow = true;
        private int itsCurrentFrame = 1;
        private int ball;
        private int firstThrow;
        private int secondThrow;
        private bool firstThrowInFrame = true;

        public int Score()
        {
            //return itsScore;
            return ScoreForFrame(GetCurrentFrame() - 1);
        }

        public void Add(int pins)
        {
            itsThrows[itsCurrentThrow++] = pins;
            itsScore += pins;
            adjustCurrentFrame(pins);
        }

        private void adjustCurrentFrame(int pins)
        {
            if (firstThrowInFrame == true)
            {
                if (pins == 10)
                    itsCurrentFrame++;
                else
                    firstThrowInFrame = false;
            }
            else
            {
                firstThrowInFrame = true;
                itsCurrentFrame++;
            }
            itsCurrentFrame = Math.Min(10, itsCurrentFrame);
        }

        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                //firstThrow = itsThrows[ball];
                if (strike())
                {
                    score += 10 + nextTwoBallForStrike();
                    ball++;
                }
                else if (spare())
                {
                    score += 10 + nextBallForSpare();
                    ball += 2;
                }
                else
                {
                    score += twoBallsInFrame();
                    ball += 2;
                }
            }
            return score;
        }

        public int nextBallForSpare()
        {
            return itsThrows[ball + 2];
        }

        public int nextTwoBallForStrike()
        {
            return itsThrows[ball + 1] + itsThrows[ball + 2];
        }

        private int nextTwoBalls()
        {
            return itsThrows[ball] + itsThrows[ball + 1];
        }

        private bool strike()
        {
            return itsThrows[ball] == 10;
        }

        private int handleSecondThrow()
        {
            int score = 0;
            //secondThrow = itsThrows[ball + 1];
            //int frameScore = firstThrow + secondThrow;
            if (spare())
            {
                ball += 2;
                score += 10 + nextBall();
            }
            else
            {
                score += twoBallsInFrame();
                ball += 2;
            }
            return score;
        }

        private int twoBallsInFrame()
        {
            return itsThrows[ball] + itsThrows[ball + 1];
        }

        private int nextBall()
        {
            return itsThrows[ball];
        }

        private bool spare()
        {
            return (itsThrows[ball] + itsThrows[ball + 1]) == 10;
        }

        public int GetCurrentFrame()
        {
            return itsCurrentFrame;
            //return 1 + (itsCurrentThrow - 1) / 2;
        }
    }
}
