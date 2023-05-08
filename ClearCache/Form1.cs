using System.Diagnostics;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace ClearCache
{
    public partial class Form1 : Form
    {
        private const string LogsFolder = "logs";
        private const string CrashesFolder = "crashes";
        private const string CacheFolder = "cache";
        private const string NuiStorageFolder = "nui-storage";
        private const string ServerCacheFolder = "server-cache";
        private const string ServerCachePrivFolder = "server-cache-priv";
        private const string TempFolder = "Temp";
        private const string PrefetchFolder = "Prefetch";
        private System.Windows.Forms.TextBox textBox1;

        private readonly string[] FoldersToDelete =
        {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FiveM", "FiveM.app", LogsFolder),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FiveM", "FiveM.app", CrashesFolder),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FiveM", "FiveM.app", "data", CacheFolder),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FiveM", "FiveM.app", "data", NuiStorageFolder),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FiveM", "FiveM.app", "data", ServerCacheFolder),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FiveM", "FiveM.app", "data", ServerCachePrivFolder),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), TempFolder + "*.*"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), PrefetchFolder + "*.*"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), TempFolder + "*.*")
        };

        public Form1()
        {
            InitializeComponent();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox1.Location = new System.Drawing.Point(0, this.ClientSize.Height - 200); // Position du TextBox
            this.textBox1.Multiline = true; // Permet plusieurs lignes
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(this.ClientSize.Width, 300); // Taille du TextBox
            this.textBox1.TabIndex = 0;
            this.Controls.Add(this.textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Accorde les autorisations nécessaires à l'utilisateur en cours d'exécution
                foreach (string folder in FoldersToDelete)
                {
                    if (Directory.Exists(folder))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                        // Ajoute les droits d'accès pour l'utilisateur actuel
                        directorySecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow));
                        directoryInfo.SetAccessControl(directorySecurity);

                        // Supprime tous les fichiers du dossier
                        foreach (string file in Directory.GetFiles(folder))
                        {
                            // Vérifie si le fichier est en cours d'utilisation par un autre processus
                            if (IsFileLocked(file))
                            {
                                // Si le fichier est verrouillé, attendez un peu puis réessayez
                                Thread.Sleep(500);
                                File.Delete(file);
                                textBox1.AppendText($"Deleted file: {file}\r\n");
                            }
                            else
                            {
                                // Si le fichier n'est pas verrouillé, supprimez-le
                                File.Delete(file);
                                textBox1.AppendText($"Deleted file: {file}\r\n");
                            }
                        }

                        // Tuer les processus qui utilisent les fichiers ou les dossiers que nous essayons de supprimer
                        string[] processesToKill = GetProcessesUsingFolder(folder);
                        foreach (string processName in processesToKill)
                        {
                            Process[] processes = Process.GetProcessesByName(processName);
                            foreach (Process process in processes)
                            {
                                textBox1.AppendText($"Kill process: {processName}\r\n");
                                process.Kill();
                            }
                        }

                        textBox1.AppendText($"Deleted folder: {folder}\r\n");
                        Directory.Delete(folder, true);
                    }
                }

                MessageBox.Show("Opération terminée avec succès.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la suppression des fichiers et des dossiers :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsFileLocked(string filePath)
        {
            try
            {
                // Essayez d'ouvrir le fichier en lecture/écriture
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    fileStream.Close();
                }
            }
            catch (IOException)
            {
                // Si le fichier est en cours d'utilisation, renvoie true
                return true;
            }

            // Si le fichier n'est pas verrouillé, renvoie false
            return false;
        }

        private string[] GetProcessesUsingFolder(string folder)
        {
            string folderName = new DirectoryInfo(folder).Name;
            string[] processes = { };

            switch (folderName)
            {
                case LogsFolder:
                case CrashesFolder:
                    processes = new string[] { "FiveM" };
                    break;
                case CacheFolder:
                case NuiStorageFolder:
                case ServerCacheFolder:
                case ServerCachePrivFolder:
                    processes = new string[] { "FiveM_GTAProcess" };
                    break;
                case TempFolder:
                    processes = new string[] { };
                    break;
                case PrefetchFolder:
                    processes = new string[] { "svchost" };
                    break;
            }

            return processes;
        }
    }
}
