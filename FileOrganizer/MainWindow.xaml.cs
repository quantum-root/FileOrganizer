using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace FileOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LogYaz("Application started. Ready to organize files...");
        }

        private void LogYaz(string mesaj)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {mesaj}\n");
            txtLog.ScrollToEnd();
        }

        private void BtnSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    txtFolderPath.Text = dialog.SelectedPath;
                    LogYaz($"Selected folder: {dialog.SelectedPath}");
                }
            }
        }

        private void BtnOrganize_Click(object sender, RoutedEventArgs e)
        {
            string hedefKlasor = txtFolderPath.Text;

            if (string.IsNullOrEmpty(hedefKlasor) || !Directory.Exists(hedefKlasor))
            {
                System.Windows.MessageBox.Show("Please select a valid folder first!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                LogYaz("Warning: Organization attempted without selecting a valid folder.");
                return;
            }

            try
            {
                string[] dosyalar = Directory.GetFiles(hedefKlasor);
                int tasinanSayisi = 0;
                LogYaz("Organization process started...");

                foreach (string dosyaYolu in dosyalar)
                {
                    FileInfo fileInfo = new FileInfo(dosyaYolu);
                    string uzanti = fileInfo.Extension.ToLower();

                    if (string.IsNullOrEmpty(uzanti)) continue;

                    string kategoriKlasoru = KategoriBelirle(uzanti);
                    string yeniKlasorYolu = Path.Combine(hedefKlasor, kategoriKlasoru);

                    if (!Directory.Exists(yeniKlasorYolu))
                    {
                        Directory.CreateDirectory(yeniKlasorYolu);
                        LogYaz($"Created category folder: {kategoriKlasoru}");
                    }

                    string yeniDosyaYolu = Path.Combine(yeniKlasorYolu, fileInfo.Name);

                    if (!File.Exists(yeniDosyaYolu))
                    {
                        File.Move(dosyaYolu, yeniDosyaYolu);
                        tasinanSayisi++;
                        LogYaz($"{fileInfo.Name} -> moved to {kategoriKlasoru}");
                    }
                }

                LogYaz($"Process completed! Total {tasinanSayisi} files organized.");
                System.Windows.MessageBox.Show($"Process completed! Total {tasinanSayisi} files organized.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                LogYaz($"ERROR: {ex.Message}");
                System.Windows.MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string KategoriBelirle(string uzanti)
        {
            switch (uzanti)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                    return "Images";
                case ".pdf":
                case ".docx":
                case ".txt":
                case ".xlsx":
                    return "Documents";
                case ".mp4":
                case ".mkv":
                case ".avi":
                    return "Videos";
                case ".mp3":
                case ".wav":
                    return "Music";
                case ".zip":
                case ".rar":
                case ".7z":
                    return "Archives";
                case ".exe":
                case ".msi":
                    return "Applications";
                default:
                    return "Others";
            }
        }
    }
}
