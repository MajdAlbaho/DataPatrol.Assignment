namespace DataPatrol.Services.IGeneratorServices
{
    public interface INumberGenerator
    {
        int Generate(int minNumber = 1, int maxNumber = 10);
    }
}
