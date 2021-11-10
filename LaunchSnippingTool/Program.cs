public static class Program
{
    public static async Task Main(string[] args)
    {
        //Launch screen snipping
        //https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-screen-snipping

        var path = args.FirstOrDefault();
        if(path is null || !File.Exists(path))
        {
            Console.WriteLine($"ファイルが見つかりませんでした：{path}");
            return;
        }

        var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(path);
        var token = Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager.AddFile(file);

        await Windows.System.Launcher.LaunchUriAsync(new Uri($"ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken={token}"));
    }
}