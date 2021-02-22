using System.Collections.Generic;

namespace TuringMachine.Garage
{
    public abstract class TuringMachine
    {
        protected Dictionary<(int conditionNumber, char currentSymbol), (int nextCondition, char newSymbol, int
            tapeShift)
        > TuringDictionary;

        protected abstract void BuildMachine();
        
        public char[] Evaluate(char[] tape)
        {
            int conditionNumber = 0;
            int currentSymbolIndex = 0;
            
            while (conditionNumber != -1 && conditionNumber != -2)
            {
                (int nextCondition, char newSymbol, int tapeShift) nextConditionData = TuringDictionary[(conditionNumber, tape[currentSymbolIndex])];
                
                conditionNumber = nextConditionData.nextCondition;
                tape[currentSymbolIndex] = nextConditionData.newSymbol;
                currentSymbolIndex += nextConditionData.tapeShift;
            }

            return tape;
        }
    }
}