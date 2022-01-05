/* ==============================================================================
* 类名称：VersionChecker
* 类描述：
* 创建人：siazon
* 创建时间：2022/1/3 19:05:54
* 修改人：
* 修改时间：
* 修改备注：
* @version 1.0
* ==============================================================================*/
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.System;

namespace Updater
{
    /// <summary>
    /// VersionChecker
    /// </summary>
    public class VersionChecker
    {
        private string updateFileDir = "ftp://127.0.0.1/";
        string appDir;
        string appName = "";
        string NewVersion = "";
        public VersionChecker(string appDir, string appName)
        {
            this.appDir = appDir;
            this.appName = appName;
        }
        public void CheckUpdate()
        {
            var temo = Package.Current.Id.Version;
            Version LocalVer = new Version("0.0.0.1");

            string path = updateFileDir + "ver.txt";
            var client = new  System.Net.WebClient();
            client.DownloadDataCompleted += (sender, e) =>
            {
                try
                {
                    Version remoteVer = LocalVer;
                    string Rsec = "";
                    byte[] data = e.Result;
                    string txtData = Encoding.UTF8.GetString(data);
                    string[] datas = txtData.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    int rsecIndex = 0;
                    for (int i = 0; i < datas.Length; i++)
                    {
                        if (datas[i].Contains("version:"))
                        {
                            NewVersion = datas[i].Substring(8, datas[i].Length - 8);
                            remoteVer = new Version(NewVersion);
                        }
                        if (datas[i].Contains("updateInfo:"))
                        {
                            if (datas[i].Length > 5)
                            {
                                Rsec += datas[i].Substring(11, datas[i].Length - 11);
                                Rsec += Environment.NewLine;
                            }
                            rsecIndex = i;
                        }
                        if (i > rsecIndex)
                        {
                            Rsec += datas[i];
                            Rsec += Environment.NewLine;
                        }
                    }
                    if (remoteVer > LocalVer)
                    {
                        //  this.txtProcess.Text = $"发现新的版本({NewVersion}),是否现在更新";
                    }
                    else
                    {
                        // this.txtProcess.Text = "当前版本已经是最新版本！";
                    }
                    //UpdateAppConfig("updateFileDir", txtaddr.Text);
                }
                catch (Exception ex)
                {
                    //  this.txtProcess.Text = "获取远程版本信息异常，请检查下方地址是否正确、文件服务器是否开启！";
                }
            };
            client.DownloadDataAsync(new Uri(path));
        }
        public void DownloadUpdateFile()
        {
            var url = updateFileDir + "update.zip";
            string tempDir = appDir + "\\temp";
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            var client = new System.Net.WebClient();
            client.DownloadProgressChanged += (sender, e) =>
            {
                UpdateProcess(e.BytesReceived, e.TotalBytesToReceive);
            };
            client.DownloadDataCompleted += (sender, e) =>
            {
                try
                {
                    string zipFilePath = System.IO.Path.Combine(tempDir, "update.zip");
                    byte[] data = e.Result;
                    BinaryWriter writer = new BinaryWriter(new FileStream(zipFilePath, FileMode.OpenOrCreate));
                    writer.Write(data);
                    writer.Flush();
                    writer.Close();

                    System.Threading.ThreadPool.QueueUserWorkItem((s) =>
                        {
                        //  txtProcess.Text = "开始更新程序...";

                        if (zipFilePath.Substring(zipFilePath.LastIndexOf(".") + 1, 3).ToLower() != "zip")
                            {
                            // txtProcess.Text = "服务器文件错误，更新包只能为zip包";
                            return;

                            }
                            UnZipFile(zipFilePath, appDir);

                            try
                            {
                            //清空缓存文件夹
                            foreach (string p in System.IO.Directory.EnumerateDirectories(appDir))
                                {
                                    if (p.ToLower().Equals(tempDir.ToLower()))
                                    {
                                        System.IO.Directory.Delete(p, true);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            //MessageBox.Show(ex.Message);
                        }

                            try
                            {
                            //启动软件
                            string exePath = System.IO.Path.Combine(appDir, $"{appName}.exe");
                            //var info = new System.Diagnostics.ProcessStartInfo(exePath);
                            //info.UseShellExecute = true;
                            //info.WorkingDirectory = appDir;// exePath.Substring(0, exePath.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
                            //System.Diagnostics.Process.Start(info);
                            launch(exePath);

                            //UpdateAppConfig("Ver", NewVersion);
                        }
                            catch (Exception ex)
                            {
                            //MessageBox.Show(ex.Message);
                        }
                        });
                }
                catch (Exception ex)
                {

                }
            };
            client.DownloadDataAsync(new Uri(url));
        }
        public async void launch(string path)
        {
            try
            {
                var uri = new Uri("apkhelper:");
                var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch (Exception ex)
            {

            }

        }
        private void UpdateAppConfig(string newKey, string newValue)
        {
            //bool isModified = false;
            //foreach (string key in ConfigurationManager.AppSettings)
            //{
            //    if (key == newKey)
            //    {
            //        isModified = true;
            //    }
            //}

            //// Open App.Config of executable
            //Configuration config =
            //    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //// You need to remove the old settings object before you can replace it
            //if (isModified)
            //{
            //    config.AppSettings.Settings.Remove(newKey);
            //}
            //// Add an Application Setting.
            //config.AppSettings.Settings.Add(newKey, newValue);
            //// Save the changes in App.config file.
            //config.Save(ConfigurationSaveMode.Modified);
            //// Force a reload of a changed section.
            //ConfigurationManager.RefreshSection("appSettings");
        }
        private static void UnZipFile(string zipFilePath, string targetDir)
        {
            using (IArchive archive = ArchiveFactory.Open(zipFilePath))
            {
                foreach (IArchiveEntry entry in archive.Entries)
                {
                    //var WaitProgressValue = archive.Entries.GetProgressValue(entry);
                    if (!entry.IsDirectory)
                    {
                        string fileName = System.IO.Path.Combine(targetDir, entry.Key);
                        Thread.Sleep(100);
                        if (File.Exists(fileName))
                            File.Delete(fileName);
                        entry.WriteToDirectory(targetDir, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
            }
            //ICCEmbedded.SharpZipLib.Zip.FastZipEvents evt = new ICCEmbedded.SharpZipLib.Zip.FastZipEvents();
            //ICCEmbedded.SharpZipLib.Zip.FastZip fz = new ICCEmbedded.SharpZipLib.Zip.FastZip(evt);
            //fz.ExtractZip(zipFilePath, targetDir, "");
        }

        public void UpdateProcess(long current, long total)
        {
            if (total <= 0) return;
            string status = (int)((float)current * 100 / (float)total) + "%";
            // this.txtProcess.Text = status;
            // rectProcess.Width = ((float)current / (float)total) * bProcess.ActualWidth;
        }

        public void CopyDirectory(string sourceDirName, string destDirName)
        {
            try
            {
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                    File.SetAttributes(destDirName, File.GetAttributes(sourceDirName));
                }
                if (destDirName[destDirName.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                    destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;
                string[] files = Directory.GetFiles(sourceDirName);
                foreach (string file in files)
                {
                    File.Copy(file, destDirName + System.IO.Path.GetFileName(file), true);
                    File.SetAttributes(destDirName + System.IO.Path.GetFileName(file), System.IO.FileAttributes.Normal);
                }
                string[] dirs = Directory.GetDirectories(sourceDirName);
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("复制文件错误");
            }
        }

    }
}