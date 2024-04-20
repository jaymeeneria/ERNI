namespace TechExam2.Interface
{
    public interface ICalculatorService
    {
        Task<int> RoundingSumOf2Int(int firstNumber, int secondNumber);
    }
}
