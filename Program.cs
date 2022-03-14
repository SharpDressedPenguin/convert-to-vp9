var fileNames = args;

if (fileNames.Length == 0) {
    Console.WriteLine("To use this app, select and drag the video you want to convert into this window, then press <enter>.");
    Console.WriteLine("When all files are entered, press <enter> again to process.");
    Console.WriteLine();
    Converter.Write("Fun fact: ", ConsoleColor.Green);
    Console.WriteLine("If this seems tedious, you can just select all the files in File Explorer,");
    Console.WriteLine("and drag them directly onto the convert-to-vp9.exe icon and skip this process entirely!");

    Console.WriteLine();
    Console.WriteLine("Paste or drag/drop each file here, and press <enter>");

    var newFiles = new List<string>();
    string response;
    while(!String.IsNullOrWhiteSpace(response = Console.ReadLine() ?? "")) {
        newFiles.Add(response);
    }
    fileNames = newFiles.ToArray();
};

if (fileNames.Length == 0) {
    Console.WriteLine("No files to process.  Press <Enter> to close.");
    Console.ReadLine();
    return;
}

for(int i = 0; i < fileNames.Length; i++) {
    Converter.WriteLine($"Processing {i + 1} of {fileNames.Length}...", ConsoleColor.Green);
    Converter.Convert(fileNames[i]);
}

Converter.WriteLine("Videos finished processing!", ConsoleColor.Green);

Console.WriteLine();
Console.WriteLine("Press <Enter> to close.");
Console.ReadLine();
