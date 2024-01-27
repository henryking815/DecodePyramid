using System.Text;

var fileDict = new Dictionary<int, string>();

// read txt file line by line and build dictionary with line numbers as keys and line text as values
using (var fileStream = File.OpenRead("..\\..\\..\\coding_qual_input.txt"))
    using (var streamReader = new StreamReader(fileStream))
    {
        var line = "";
        while ((line = streamReader.ReadLine()) != null)
        {
            var lineSplit = line.Split(' ', 2);
            fileDict.Add(int.Parse(lineSplit[0]), lineSplit[1]);
        }
    }

decode(fileDict);
Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

static void decode(Dictionary<int, string> fileDict)
{
    var key = 1;
    var i = 1;
    var lineText = "";

    // while dictionary contains key
    while (fileDict.Count >= key)
    {
        // capture & append line text at dictionary 'key'
        lineText += fileDict[key];
        // increment 'key' by itself plus 'i' using addition operator '+='
        // this approach adds one additional increment at each while loop iteration compared to the last
        // e.g. key equals 1 then (key + 2) 3 then (key + 3) 6 then (key + 4) 10 etc
        i++;
        key += i;
    }

    Console.WriteLine(lineText);
}
