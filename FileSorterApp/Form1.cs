namespace FileSorterApp
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private string selectedDir = string.Empty;
        private string[] filePaths;
        private string[] extensions;

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (!(folderDialog.ShowDialog() == DialogResult.OK)) return;

            selectedDir = folderDialog.SelectedPath;
            filePaths = Directory.GetFiles(selectedDir, "*.*",
                SearchOption.TopDirectoryOnly);

            if (filePaths.Length == 0)
            {
                // UI updates
                dirTextBox.Text = string.Empty;
                MessageBox.Show("No files in selected folder!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            extensions = filePaths
                .Select(x => x[x.LastIndexOf(".")..])  // x = "file.jpg"; x[x.LastIndexOf(".")..] = ".jpg";
                .Distinct()  // we don't want duplicates
                .OrderBy(x => x[1])  // sort alphabetically (x[0] = '.')
                .ToArray();

            // UI updates
            dirTextBox.Text = selectedDir;
            extensionsCheckedListBox.Items.Clear();
            extensionsCheckedListBox.Items.AddRange(extensions);
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            // UI updates
            progressOutput.Clear();

            if (selectedDir.Length == 0)
            {
                MessageBox.Show("No folder selected!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // if there are checked items, set them to prefferedExtensions, otherwise set all extensions
            string[] prefferedExtensions = extensionsCheckedListBox.CheckedItems.Count > 0 ?
                extensionsCheckedListBox.CheckedItems.OfType<string>().ToArray() : extensions;

            // from filePaths, set only files whose extension is in prefferedExtensions to targetFiles
            string[] targetFiles = filePaths
                .Where(x => prefferedExtensions.Contains(x[x.LastIndexOf(".")..]))
                .ToArray();

            int foldersCreated = 0;
            int filesSorted = 0;

            foreach (var (extension, folderName, newDir) in from extension in prefferedExtensions
                                                            let folderName = $@"{extension.TrimStart('.').ToUpper()} Files"
                                                            let newDir = selectedDir + @"\" + folderName
                                                            select (extension, folderName, newDir))
            {
                if (Directory.Exists(newDir))
                {
                    // UI updates
                    progressOutput.Text += $"Directory \"{folderName}\" already exists!"
                        + Environment.NewLine;
                }
                else
                {
                    Directory.CreateDirectory(newDir);
                    foldersCreated++;

                    // UI updates
                    progressOutput.Text += $"Directory \"{folderName}\" was created successfully!"
                        + Environment.NewLine;
                }

                // set the files, whose extension is equal to the current one to files
                string[] files = targetFiles
                    .Where(x => x[x.LastIndexOf(".")..] == extension)
                    .ToArray();

                int filesMoved = 0;

                foreach (var (file, fileName, newPath) in from file in files
                                                          let fileName = file[(file.LastIndexOf("\\") + 1)..]
                                                          let newPath = newDir + @"\" + fileName
                                                          select (file, fileName, newPath))
                {
                    if (File.Exists(newPath))
                    {
                        // UI updates
                        progressOutput.Text += $"Failed moving \"{fileName}\" to \"{folderName}\"!"
                            + Environment.NewLine;
                        progressOutput.Text += $"File \"{fileName}\" already exists at \"{folderName}\"!"
                            + Environment.NewLine;

                        continue;
                    }

                    File.Move(file, newPath);
                    filesMoved++;

                    // UI updates
                    progressOutput.Text += $"Successfully moved \"{fileName}\" to \"{folderName}\"!"
                        + Environment.NewLine;
                }

                filesSorted += filesMoved;

                // UI updates
                progressOutput.Text += $"Successfully moved {filesMoved} files to \"{folderName}\"! (Failed: {files.Length - filesMoved})"
                    + Environment.NewLine;
            }

            selectedDir = string.Empty;

            // UI updates
            dirTextBox.Clear();
            extensionsCheckedListBox.Items.Clear();
            progressOutput.Text += $"Successfully created {foldersCreated} folders!"
                    + Environment.NewLine;
            progressOutput.Text += $"Successfully sorted {filesSorted} files! (Failed: {targetFiles.Length - filesSorted})"
                    + Environment.NewLine;
        }
    }
}