using FFMpegCore;
using Konsole;

static class Converter {
    public static bool Convert(string inputFile) {
        var outputFile = Path.GetFileNameWithoutExtension(inputFile) + ".webm";
        var outputPath = Path.Combine(Path.GetDirectoryName(inputFile), outputFile);

        GlobalFFOptions.Configure(new FFOptions { BinaryFolder = Path.GetDirectoryName(typeof(Program).Assembly.Location) });

        var analysis = FFProbe.Analyse(inputFile);
        var pixelInfo = analysis.PrimaryVideoStream.GetPixelFormatInfo();
        var hasAlpha = pixelInfo.Components == 4;

        Converter.WriteLine($"Input File: {inputFile}");
        Converter.WriteLine($"Length: {analysis.Duration.ToString(@"hh\:mm\:ss\.ff")}");
        Converter.Write($"Contains alpha channel: ");
        Converter.WriteLine($"{hasAlpha}", hasAlpha ? ConsoleColor.Green : ConsoleColor.Yellow);
        Converter.WriteLine();

        var pb = new ProgressBar(100);
        var result = FFMpegArguments
            .FromFileInput(inputFile)
            .OutputToFile(outputPath, true, options => options
                .WithVideoCodec("vp9")
                .ForceFormat("webm"))
            .NotifyOnProgress(progress => {
                pb.Refresh((int) Math.Ceiling(progress), $"Processing {outputFile}");
            }, analysis.Duration)
            .ProcessSynchronously();

        Converter.WriteLine();
        return result;
    }

    private static void TempColor(ConsoleColor color, Action method) {
        var origColor = Console.ForegroundColor;

        Console.ForegroundColor = color;
        method();
        Console.ForegroundColor = origColor;
    }

    public static void WriteLine(string text = "", ConsoleColor color = ConsoleColor.Gray) =>
        TempColor(color, () => Console.WriteLine(text));

    public static void Write(string text = "", ConsoleColor color = ConsoleColor.Gray) =>
        TempColor(color, () => Console.Write(text));
}