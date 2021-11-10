namespace CopyPngToClipboardWithAlpha;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

public static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var file = args.FirstOrDefault();

        if (!File.Exists(file) || Path.GetExtension(file)?.ToLower() is not ".png")
        {
            Console.WriteLine($"ファイルが見つかりませんでした：{file}");
            return;
        }

        using var stream = new FileStream(file, FileMode.Open, FileAccess.Read);
        var frame = BitmapFrame.Create(stream);

        var dataObject = new DataObject();
        dataObject.SetImage(frame);
        dataObject.SetData("PNG", stream);
        Clipboard.SetDataObject(dataObject, true);
    }
}