using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using Microsoft.WindowsAPICodePack.Dialogs;

namespace Prof
{
    public partial class FUploadUpdate : Form
    {
        private int idProjectVersion = 0;
        private string FTP_path = "ftp://91.200.160.209";
        public FUploadUpdate(int idProjectVersion)
        {
            InitializeComponent();
            this.idProjectVersion = idProjectVersion;
        }

        private void FUploadUpdate_Load(object sender, EventArgs e)
        {
            using (Database.DataBase db = new Database.DataBase())
            {

                if (idProjectVersion == 0)
                {
                    tb_version.Clear();
                    tb_ftp.Clear();
                    rtb_updText.Clear();
                    rtb_updText.AppendText("\t\t\t\t[" + DateTime.Now.ToShortDateString().ToString() + "] \n\n 1)");
                } 
                else
                {
                    Database.ProjectVersion pv = db.ProjectVersions.FirstOrDefault(p => p.id == idProjectVersion);
                    tb_version.Text = pv.version;
                    tb_ftp.Text = pv.ftpPath;
                    rtb_updText.Clear();
                    rtb_updText.Rtf = pv.updText;
                }
            }

        }

        private void b_save_Click(object sender, EventArgs e)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                if (tb_version.Text.Trim() == "" && 
                    rtb_updText.Text.Trim() == "" &&
                    tb_pathReliase.Text.Trim() == "")
                {
                    MessageBox.Show("Нужно заполнить все поля!");
                }
                else
                {
                    bool upd = true;
                    var projectVersion = db.ProjectVersions;

                    foreach (Database.ProjectVersion pv in projectVersion)
                    {
                        if (pv.version.Equals(tb_version.Text) && idProjectVersion == 0)
                        {
                            if (MessageBox.Show("Данная версия выбранного проекта уже существует, указать следующие версию автоматически?", "Дебликат версии", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                string[] vers = tb_version.Text.Split('.');

                                tb_version.Text = "";

                                int major = Convert.ToInt32(vers[0]);
                                int minor = Convert.ToInt32(vers[1]);
                                int rev = Convert.ToInt32(vers[2]) + 1;

                                if (rev == 10) { minor += 1; rev = 0; }
                                if (minor == 10) { major += 1; minor = 0; }

                                tb_version.Text = major.ToString() + "." + minor.ToString() + "." + rev.ToString();

                                upd = true;
                            }
                            else upd = false;
                        }
                    }
                    if (upd)
                    {
                        if (idProjectVersion == 0)
                        {
                            foreach (Database.ProjectVersion pv in projectVersion) pv.isUse = "F";

                            tb_ftp.Clear();
                            tb_ftp.Text = FTP_path + "/update/Prof/" + tb_version.Text + "/update.7z";
                            db.ProjectVersions.Add(new Database.ProjectVersion
                            {
                                version = tb_version.Text,
                                ftpPath = tb_ftp.Text,
                                updText = rtb_updText.Rtf,
                                isUse = "T",
                                dateUpdate = DateTime.Now
                            });
                            db.SaveChanges();
                        }
                        else
                        {
                            Database.ProjectVersion pv = db.ProjectVersions.FirstOrDefault(p => p.id == idProjectVersion);
                            pv = db.ProjectVersions.FirstOrDefault(p => p.id == idProjectVersion);
                            pv.version = tb_version.Text;
                            pv.updText = rtb_updText.Rtf;
                            db.SaveChanges();
                        }
                        Close();
                    }
                }
            }
        }

        private void cb_projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb_version.Text.Trim() != "")
            {
                tb_ftp.Clear();
                tb_ftp.Text = FTP_path + "/update/Prof/" + tb_version.Text + "/update.7z";
            }
        }

        private void b_close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void checkFolderFtp(string folder)
        {
            string ftpUserID = "userFTP";
            string ftpPassword = "FTPuser_748159263";
            string ftpFullPath = FTP_path + folder;

            FtpWebRequest ftp;
            try
            {
                ftp = (FtpWebRequest)FtpWebRequest.Create(ftpFullPath);
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.KeepAlive = false;
                ftp.UseBinary = true;
                ftp.Proxy = null;
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();
                resp.Close();
            }
            catch
            {
                ftp = (FtpWebRequest)FtpWebRequest.Create(ftpFullPath);
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.KeepAlive = false;
                ftp.UseBinary = true;
                ftp.Proxy = null;
                ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();
                resp.Close();
            }
        }

        private void ftpfile(string fname)
        {
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(tb_ftp.Text);
            ftp.Credentials = new NetworkCredential("userFTP", "FTPuser_748159263");
            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.Proxy = null;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs = File.OpenRead(fname);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();
            Stream ftpstream = ftp.GetRequestStream();
            ftpstream.Write(buffer, 0, buffer.Length);
            ftpstream.Close();
        }

        public static void AddToArchive(string archiver, string fileNames, string archiveName)
        {
            try
            {
                // Предварительные проверки
                if (!File.Exists(archiver))
                    throw new Exception("Архиватор 7z по пути \"" + archiver +
                    "\" не найден");

                // Формируем параметры вызова 7z
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = archiver;
                // добавить в архив с максимальным сжатием
                startInfo.Arguments = " a -mx9 ";
                // имя архива
                startInfo.Arguments += "\"" + archiveName + "\"";
                // файлы для запаковки
                startInfo.Arguments += " \"" + fileNames + "\"";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                int sevenZipExitCode = 0;
                using (Process sevenZip = Process.Start(startInfo))
                {
                    sevenZip.WaitForExit();
                    sevenZipExitCode = sevenZip.ExitCode;
                }
                // Если с первого раза не получилось,
                //пробуем еще раз через 1 секунду
                if (sevenZipExitCode != 0 && sevenZipExitCode != 1)
                {
                    using (Process sevenZip = Process.Start(startInfo))
                    {
                        Thread.Sleep(1000);
                        sevenZip.WaitForExit();
                        switch (sevenZip.ExitCode)
                        {
                            case 0: return; // Без ошибок и предупреждений
                            case 1: return; // Есть некритичные предупреждения
                            case 2: throw new Exception("Фатальная ошибка");
                            case 7: throw new Exception("Ошибка в командной строке");
                            case 8:
                                throw new Exception("Недостаточно памяти для выполнения операции");
                            case 225:
                                throw new Exception("Пользователь отменил выполнение операции");
                            default:
                                throw new Exception("Архиватор 7z вернул недокументированный код ошибки: " + sevenZip.ExitCode.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("SevenZip.AddToArchive: " + e.Message);
            }
        }



        private void b_pathReliase_Click(object sender, EventArgs e)
        {
           /* CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tb_pathReliase.Text = dialog.FileName;
                if (tb_pathReliase.Text.Trim() != "")
                {
                    string fileVersion = @tb_pathReliase.Text + @"\version.txt";
                    File.WriteAllText(fileVersion, tb_version.Text);
                    tb_pathReliase.Text += "\\*";

                    AddToArchive(@"7z\7za.exe", @tb_pathReliase.Text, @"tmp\update.7z");
                    TopMost = true;
                    checkFolderFtp("/update");
                    checkFolderFtp("/update/Prof");
                    checkFolderFtp("/update/Prof/" + tb_version.Text);
                    ftpfile("tmp\\update.7z");
                    MessageBox.Show("Загрузили на ФТП");
                    File.Delete("tmp\\update.7z");
                }
            }*/
        }

        private void tb_version_TextChanged(object sender, EventArgs e)
        {
            tb_ftp.Clear();
            tb_ftp.Text = FTP_path + "/update/Prof/" + tb_version.Text + "/update.7z";
        }

        private void FUploadUpdate_DoubleClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }
    }
}
