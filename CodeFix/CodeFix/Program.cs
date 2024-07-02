namespace CodeFix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\simen\OneDrive\Desktop\AspektCodeFix"; //My directory path

            List<string> txtFiles = new List<string>();

            GetTxtFiles(directoryPath, txtFiles);

            foreach (var file in txtFiles)
            {
                AppendTextToFile(file, "ASPEKT");
            }

        }

        static void GetTxtFiles(string directoryPath, List<string> txtFiles)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.txt");
            txtFiles.AddRange(files);
            string[] subdirectories = Directory.GetDirectories(directoryPath);
            foreach (string subdirectory in subdirectories) 
            {
                GetTxtFiles(subdirectory, txtFiles); //The change was necessary because a source error limited the recursive process to only the base directory directoryPath, without processing subdirectories. This resulted in not processing all .txt files in my subdirectories.
            }
        }
        static void AppendTextToFile(string filePath, string textToAppend)
        {
            StreamWriter writer = null;
            writer = File.AppendText(filePath);
            writer.WriteLine(textToAppend);
            writer.Close(); //Without closing the StreamWriter using writer.Close(), the text I want may not be written until it is closed.
        }
    }
}