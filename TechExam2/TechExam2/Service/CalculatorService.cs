using TechExam2.Interface;

namespace TechExam2.Service
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<int> RoundingSumOf2Int(int firstNumber, int secondNumber)
        {
            int roundedValue = 0;
            int sum = 0;

            int summ = firstNumber + secondNumber;
            roundedValue = (sum % 5) == 0 ? sum : sum + 5;

            return roundedValue;
        }
    }
}
