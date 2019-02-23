using System.Collections.Generic;
using System.Linq;

namespace ConsoleBowling
{
    internal class Game
    {
        private Frame[] Frames { get; } = Enumerable.Range(0, 10).Select(i => new Frame()).ToArray();

        private int? FrameIndex
        {
            get
            {
                for (var i = 0; i < Frames.Length; i++)
                {
                    var frame = Frames[i];
                    if (!frame.Over)
                        return i;
                }

                if (!Frames.All(frame => frame.Satisfied)) return Frames.Length - 1;

                return null;
            }
        }

        public int? FrameNumber => FrameIndex + 1;

        public Frame CurrentFrame => FrameIndex.HasValue ? Frames[FrameIndex.Value] : null;

        public int PinsUp
        {
            get
            {
                if (CurrentFrame == null) return 10;
                var remaining = 10 - CurrentFrame.Score;
                if (remaining <= 0) return 10;
                return remaining;
            }
        }

        public int Score => Frames.Sum(frame => frame.Score);

        private List<Frame> Unsatisfied
        {
            get
            {
                var unsatisfied = new List<Frame>();
                for (var i = 0; i < FrameNumber; i++)
                {
                    var theFrame = Frames[i];
                    if (!theFrame.Satisfied)
                        unsatisfied.Add(theFrame);
                }

                return unsatisfied;
            }
        }

        public int NextRollWorth => Unsatisfied.Count;

        public void ApplyRoll(int pinsHit)
        {
            foreach (var frame in Unsatisfied)
                frame.Rolls.Add(pinsHit);
        }
    }
}