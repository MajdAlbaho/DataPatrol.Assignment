using DataPatrol.Services.IGeneratorServices;

namespace DataPatrol.Services.GeneratorServices
{
    public class NumberGenerator : INumberGenerator
    {
        public int Generate(int minNumber = 1, int maxNumber = 10) {
            var random = new Random();
            int randomNumber = random.Next(minNumber, maxNumber + 1);

            return randomNumber;
        }
    }
}
