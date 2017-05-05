using GzsTool.Core.Pftxs;
using GzsTool.Core.Utility;
using System.IO;
using System.Reflection;

namespace AutoPftxsTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 1)
            {
                if (File.GetAttributes(args[0]).HasFlag(FileAttributes.Directory))
                {
                    string fileName = args[0].Substring(0, args[0].Length - 6) + ".pftxs";
                    
                    ArchiveHandler.WritePftxsArchive(fileName, args[0]);
                } //if ends
                else
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(args[0]);
                    string extension = Path.GetExtension(args[0]).Substring(1);
                    string directoryName = Path.GetDirectoryName(args[0]);
                    string outputDirectory = directoryName + "\\" + fileNameWithoutExtension + "_" + extension;

                    Directory.CreateDirectory(outputDirectory);

                    Hashing.ReadDictionary(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\qar_dictionary.txt");

                    ArchiveHandler.ExtractArchive<PftxsFile>(args[0], directoryName + "\\" + fileNameWithoutExtension + "_" + extension);
                } //else ends
            } //if ends
        } //function Main ends
    } //class Program
}
