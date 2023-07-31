using App;

while (true)
{
    Console.WriteLine("Write your matrix (e.g., '1,0,1;1,1,0'): ");
    string? inputString = Console.ReadLine();
    if (!ArrayProcess.IsInputStringValid(inputString))
    {
        Console.WriteLine("Invalid Value");
        return;
    }
    var areaCount = ArrayProcess.GetAreasCount(inputString);
    Console.WriteLine($"Number of areas formed of number 1: {areaCount}\n");
}
