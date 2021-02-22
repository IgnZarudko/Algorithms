using System.Collections.Generic;

namespace TuringMachine.Garage
{
    public class MultiplierByTwo : TuringMachine
    {
        public MultiplierByTwo()
        {
            BuildMachine();
        }
        
        protected sealed override void BuildMachine()
        {
            TuringDictionary =
                new Dictionary<(int conditionNumber, char currentSymbol), (int nextCondition, char newSymbol, int
                    tapeShift)>
                {
                    {(0, '#'), (0, '#', 1)},
                    {(0, '|'), (1, '#', 1)},
                    {(1, '|'), (1, '|', 1)},
                    {(1, '#'), (2, '#', 1)},
                    {(2, '|'), (2, '|', 1)},
                    {(2, '#'), (3, '|', 1)},
                    {(3, '#'), (4, '|', 0)},
                    {(4, '|'), (4, '|', -1)},
                    {(4, '#'), (5, '#', -1)},
                    {(5, '|'), (6, '|', -1)},
                    {(5, '#'), (-1, '#', 0)},
                    {(6, '|'), (6, '|', -1)},
                    {(6, '#'), (0, '#', 1)}
                };
        }
    }
}