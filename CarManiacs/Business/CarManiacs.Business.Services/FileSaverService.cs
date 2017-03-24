using Bytes2you.Validation;
using CarManiacs.Business.Services.Contracts;

using System;
using System.IO;

namespace CarManiacs.Business.Services
{
    public class FileSaverService : IFileSaverService
    {
        public string SaveFile(MemoryStream fileToSave, string dirToSaveIn, string fileName, bool shouldReplaceFile = false)
        {
            Guard.WhenArgument(fileToSave, "fileToSave").IsNull().Throw();
            Guard.WhenArgument(dirToSaveIn, "dirToSaveIn").IsNullOrEmpty().Throw();
            Guard.WhenArgument(fileName, "fileName").IsNullOrEmpty().Throw();

            Directory.CreateDirectory(dirToSaveIn);
            string filePath = Path.Combine(dirToSaveIn, fileName);
            if (!shouldReplaceFile && File.Exists(filePath))
            {
                // make file name unique
                string fileExtension = Path.GetExtension(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName) + Guid.NewGuid().ToString() + fileExtension;
                filePath = Path.Combine(dirToSaveIn, fileName);
            }

            using (FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write))
            {
                using (fileToSave)
                {
                    byte[] bytes = new byte[fileToSave.Length];
                    fileToSave.Read(bytes, 0, (int)fileToSave.Length);
                    file.Write(bytes, 0, bytes.Length);
                    file.Flush();
                }
            }

            return fileName;
        }
    }
}
