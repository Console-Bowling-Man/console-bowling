using System.Collections.Generic;
using System.Linq;

namespace ConsoleBowling
{
    internal class Frame
    {
        public List<int> Rolls { get; set; } = new List<int>();

        public bool Over
        {
            get
            {
                if (Rolls.Count <= 0) return false;
                if (Rolls.Count == 1)
                    return Rolls[0] == 10;
                return true;
            }
        }

        public bool Strike => Rolls.Count >= 1 && Rolls[0] == 10;

        public bool Spare => Rolls.Count >= 2 && Rolls[0] + Rolls[1] == 10;

        public bool Satisfied
        {
            get
            {
                if (Strike || Spare)
                    return Rolls.Count >= 3;
                return Rolls.Count >= 2;
            }
        }
        public int Score => Rolls.Sum();

        public int RollNumber => Rolls.Count + 1;
    }
}