using System.Collections.Generic;

namespace TuringMachine.Garage
{
    public class SubtractorByOne : TuringMachine
    {
        public SubtractorByOne()
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
                    {(0, '|'), (-1, '#', 0)}
                };
        }
    }
}