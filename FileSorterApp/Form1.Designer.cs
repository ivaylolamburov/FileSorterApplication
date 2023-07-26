namespace FileSorterApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dirTextBox = new TextBox();
            browseButton = new Button();
            label1 = new Label();
            sortButton = new Button();
            extensionsCheckedListBox = new CheckedListBox();
            label2 = new Label();
            progressOutput = new RichTextBox();
            label3 = new Label();
            folderDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // dirTextBox
            // 
            dirTextBox.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            dirTextBox.Location = new Point(31, 46);
            dirTextBox.Name = "dirTextBox";
            dirTextBox.ReadOnly = true;
            dirTextBox.Size = new Size(575, 31);
            dirTextBox.TabIndex = 0;
            // 
            // browseButton
            // 
            browseButton.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            browseButton.Location = new Point(627, 46);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(144, 31);
            browseButton.TabIndex = 1;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += BrowseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 18);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 2;
            label1.Text = "Path to folder";
            // 
            // sortButton
            // 
            sortButton.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            sortButton.Location = new Point(627, 396);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(144, 31);
            sortButton.TabIndex = 3;
            sortButton.Text = "Sort";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += SortButton_Click;
            // 
            // extensionsCheckedListBox
            // 
            extensionsCheckedListBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            extensionsCheckedListBox.FormattingEnabled = true;
            extensionsCheckedListBox.Location = new Point(31, 137);
            extensionsCheckedListBox.Name = "extensionsCheckedListBox";
            extensionsCheckedListBox.Size = new Size(120, 290);
            extensionsCheckedListBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(31, 109);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 5;
            label2.Text = "Extensions";
            // 
            // progressOutput
            // 
            progressOutput.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            progressOutput.Location = new Point(187, 137);
            progressOutput.Name = "progressOutput";
            progressOutput.ReadOnly = true;
            progressOutput.Size = new Size(584, 253);
            progressOutput.TabIndex = 6;
            progressOutput.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(187, 109);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 7;
            label3.Text = "Progress";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(progressOutput);
            Controls.Add(label2);
            Controls.Add(extensionsCheckedListBox);
            Controls.Add(sortButton);
            Controls.Add(label1);
            Controls.Add(browseButton);
            Controls.Add(dirTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox dirTextBox;
        private Button browseButton;
        private Label label1;
        private Button sortButton;
        private CheckedListBox extensionsCheckedListBox;
        private Label label2;
        private RichTextBox progressOutput;
        private Label label3;
        private FolderBrowserDialog folderDialog;
    }
}