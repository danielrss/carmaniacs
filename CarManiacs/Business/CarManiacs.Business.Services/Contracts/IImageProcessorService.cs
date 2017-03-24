using System.IO;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IImageProcessorService
    {
        MemoryStream ProcessImage(byte[] photoBytes, int width, int height, string fileFormat, int qualityPercentage);
    }
}
