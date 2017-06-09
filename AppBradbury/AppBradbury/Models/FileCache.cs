using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using PCLStorage;
using System.Net.Http;

namespace AppBradbury.Models
{
    public static class FileCache
    {
        private static IFolder folder;
        private static object locker = new object();
        private static Dictionary<string, Task<bool>> downloadTasks = new Dictionary<string, Task<bool>>();

        static FileCache()
        {
            Init();
        }

        static void Init()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            folder = rootFolder;
        }

        public static async Task<string> Download(string url, string fileName)
        {
            try
            {
                var path = Path.Combine(folder.Path, fileName);
                var exists = await folder.CheckExistsAsync(fileName);
                if (exists == ExistenceCheckResult.FileExists && !downloadTasks.ContainsKey(path))
                {
                    return path;
                }

                var succes = await GetDownload(url, path);
                return succes ? path : "";
            }
            catch (Exception ex)
            {
                throw new Exception("[FileCache::Download] Error al descargar archivo. Razón: " + ex.Message);
            }
        }

        private static Task<bool> GetDownload(string url, string fileName)
        {
            try
            {
                lock (locker)
                {
                    Task<bool> task;
                    if (downloadTasks.TryGetValue(fileName, out task))
                        return task;

                    downloadTasks.Add(fileName, task = download(url, fileName));
                    return task;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[FileCache::GetDownload]Error:" + ex.Message);
            }
        }

        private static async Task<bool> download(string url, string fileName)
        {
            IFile file = null;
            try
            {
                var client = Utilities.Utilities.obtenerClienteHTTP();
                var data = await client.GetByteArrayAsync(url);
                var fileNamePaths = fileName.Split('\\');
                fileName = fileNamePaths[fileNamePaths.Length - 1];
                file = await FileSystem.Current.LocalStorage.CreateFileAsync(fileName,
                    CreationCollisionOption.ReplaceExisting);

                using (var fileStream = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
                {
                    fileStream.Write(data, 0, data.Length);
                }
                return true;
            }
            catch (Exception ex)
            {
                if (file != null)
                    await file.DeleteAsync();
                throw new Exception("[FileCache::download]Error en descarga.Razón: " + ex.Message);
            }
        }

        public static async Task<string> saveFileMemory(string sUrl)
        {
            try
            {
                byte[] buffer;
                string fileName = "fichero.pdf";
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder folder = await rootFolder.CreateFolderAsync("Cache", CreationCollisionOption.OpenIfExists);
                IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

                System.Diagnostics.Debug.WriteLine("LocalStorage: (" + rootFolder.Path + ")");
                System.Diagnostics.Debug.WriteLine("Saved to Cache: (" + file.Path + ")");

                HttpClient a = new HttpClient();
                buffer = await a.GetByteArrayAsync(sUrl);

                using (Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }

                return file.Path;
            }
            catch (Exception ex)
            {
                throw new Exception("[FileCache::saveFileMemory] Error: " + ex.Message);
            }
        }
    }
}
