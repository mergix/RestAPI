// namespace Service;
//
//
//
// public interface IFileService
// {
//     public List<string> GetDirectoriesInPath(string path);
// }
//
// public class FileService :IFileService
// {
//     public List<string> GetDirectoriesInPath(string path)
//     {
//         try
//         {
//             var test = new DirectoryInfo("/Users/mergixf/RiderProjects/Pictures");
//             File.Delete("/Users/mergixf/RiderProjects/Pictures");
//             Console.WriteLine(test.FullName);
//             Directory.GetParent();
//             return new DirectoryInfo(path).EnumerateDirectories().Select(s => s.FullName).ToList();
//         } catch (Exception)
//         {
//             return new List<string>();
//         }
//     }
// }