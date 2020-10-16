using System;
using System.IO;
using System.Text;

namespace com.xamarin.samples.location.fusedlocationprovider
{
    public class FileLogger
    {
        public void LogInformation(string value)
        {
            try
            {
                string directoryPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                var path = Path.Combine(directoryPath, "FusedLocationSampleLog");
                string filename = Path.Combine(path, "LogFile.txt");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                // Set stream position to end-of-file
                fs.Seek(0, SeekOrigin.End);

                using (StreamWriter objStreamWriter = new StreamWriter(fs, Encoding.UTF8))
                {
                    objStreamWriter.WriteLine(value);
                    objStreamWriter.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
