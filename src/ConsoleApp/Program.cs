
using System.Text;

bool anotherFile;

do
{
    Console.WriteLine("********************************************");
    Console.WriteLine("1 -   1Mb file    (1,048,576)bytes");
    Console.WriteLine("2 -  10Mb file   (10,485,760)bytes");
    Console.WriteLine("3 -  50Mb file   (52,428,800)bytes");
    Console.WriteLine("4 - 100Mb file  (104,857,600)bytes");
    Console.WriteLine("********************************************");
    Console.WriteLine("Option?");
    var sizeInBytesImput = Console.ReadLine();
    bool success = long.TryParse(sizeInBytesImput, out long option);
    
    if (success && option > 0)
    {
        long sizeInBytes = option switch 
        {
            1 => 1_048_576,
            2 => 10_485_760,
            3 => 52_428_800,
            4 => 104_857_600,
            _ => 0 
        };

        success = false;
        byte fileOrString = 0;
        string fileOrStringInput;

        while (!success)
        {
            Console.WriteLine("Generate 1-File or 2-String?");
            fileOrStringInput = Console.ReadLine();
            success = byte.TryParse(fileOrStringInput, out fileOrString);
        }

        if (fileOrString == 1)
        {
            var br = new BusinessRules($"generating a {sizeInBytes} bytes file.");
            br.GenerateFile(sizeInBytes);
        }
        else
        {
            var br = new BusinessRules($"generating a {sizeInBytes} bytes string.");
            br.GenerateString((int)sizeInBytes);
        }
    }

    Console.WriteLine("Would you like to continue? (y/n)");
    var keyInfo = Console.ReadLine();
    anotherFile = keyInfo == "y";
} while (anotherFile);



class BusinessRules 
{
    public BusinessRules(string msg)
    {
        Message = msg;
    }

    public string Message { get; private set; }

    public byte[] Content {get; private set; }

    public void GenerateFile(long fileSizeInBytes)
    {
        string filePath = $"zeros_{fileSizeInBytes}.txt";

        using (FileStream fs = new(filePath, FileMode.Create))        
        {
            fs.SetLength(fileSizeInBytes);
            fs.Write(new byte[fileSizeInBytes], 0, (int)fileSizeInBytes);
        }

        Content = File.ReadAllBytes(filePath);
        Console.WriteLine(Message);
    }

    public void GenerateString(int sizeInBytes)
    {
        int bufferSize = 1024; // Buffer size for StringBuilder

        // Create a StringBuilder with an initial capacity
        StringBuilder sb = new (sizeInBytes / 2, sizeInBytes);

        // Fill the StringBuilder with zeros
        for (int i = 0; i < sizeInBytes / bufferSize; i++)
        {
            sb.Append(new string('0', bufferSize));
        }

        // Add any remaining zeros
        sb.Append(new string('0', sizeInBytes % bufferSize));

        Content = Encoding.ASCII.GetBytes(sb.ToString());
    }
}