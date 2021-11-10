#%USERPROFILE%\.vscode\extensions\mushan.vscode-paste-image-1.0.4\res
$data = [Windows.Clipboard]::GetDataObject();
$formats = $data.GetFormats();
if($formats.Contains("PNG"))
{
    $src = [IO.MemoryStream]$data.GetData("PNG");
    $dst = [IO.File]::Open($imagePath, "OpenOrCreate")
    $src.CopyTo($dst);
    $src.Dispose();
    $dst.Dispose();
    $imagePath
    return;
}