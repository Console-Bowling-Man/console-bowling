using System.Collections.Generic;
using System.Linq;

namespace ConsoleBowling
{
    internal class Game
    {
        public Frame[] Frames { get; set; } = Enumerable.Range(0, 10).Select(i => new Frame()).ToArray();

        public int? FrameIndex
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

        public void ApplyRoll(int pinsHit)
        {
            var unsatisfied = new List<Frame>();
            for (int i = 0; i < FrameNumber; i++)
            {
                var theFrame = Frames[i];
                if (!theFrame.Satisfied)
                    unsatisfied.Add(theFrame);
            }
            foreach (var frame in unsatisfied)
                frame.Rolls.Add(pinsHit);
        }
    }
}
