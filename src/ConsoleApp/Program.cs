
bool stop;

do
{
    Console.WriteLine("Stop? (y/n)");
    var keyInfo = Console.ReadLine();
    stop = keyInfo == "y";
} while (!stop);