namespace MYaSyncQL.Client.Forms.Controls
{
    partial class UCClassBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCClassBuilder));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataTables = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkFullyAsyncReading = new System.Windows.Forms.CheckBox();
            this.chkUseNullableRefTypes = new System.Windows.Forms.CheckBox();
            this.chkIncludeAttributes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamespace = new MYaSyncQL.Client.Forms.Controls.Controls.ExtendedTextBox(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtClassCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.txtTargetPath = new MYaSyncQL.Client.Forms.Controls.Controls.ExtendedTextBox(this.components);
            this.btnOpenTargetFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveClasses = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTables)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1353, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataTables);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 156);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 4);
            this.panel1.Size = new System.Drawing.Size(264, 609);
            this.panel1.TabIndex = 0;
            // 
            // dataTables
            // 
            this.dataTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTables.Location = new System.Drawing.Point(0, 0);
            this.dataTables.Name = "dataTables";
            this.dataTables.Size = new System.Drawing.Size(264, 609);
            this.dataTables.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 147);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 4);
            this.panel3.Controls.Add(this.btnSaveClasses);
            this.panel3.Controls.Add(this.btnOpenTargetFolder);
            this.panel3.Controls.Add(this.chkFullyAsyncReading);
            this.panel3.Controls.Add(this.chkUseNullableRefTypes);
            this.panel3.Controls.Add(this.chkIncludeAttributes);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtTargetPath);
            this.panel3.Controls.Add(this.txtNamespace);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(273, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1077, 147);
            this.panel3.TabIndex = 2;
            // 
            // chkFullyAsyncReading
            // 
            this.chkFullyAsyncReading.AutoSize = true;
            this.chkFullyAsyncReading.Location = new System.Drawing.Point(22, 95);
            this.chkFullyAsyncReading.Name = "chkFullyAsyncReading";
            this.chkFullyAsyncReading.Size = new System.Drawing.Size(132, 19);
            this.chkFullyAsyncReading.TabIndex = 2;
            this.chkFullyAsyncReading.Text = "Fully Async Reading";
            this.chkFullyAsyncReading.UseVisualStyleBackColor = true;
            // 
            // chkUseNullableRefTypes
            // 
            this.chkUseNullableRefTypes.AutoSize = true;
            this.chkUseNullableRefTypes.Location = new System.Drawing.Point(22, 70);
            this.chkUseNullableRefTypes.Name = "chkUseNullableRefTypes";
            this.chkUseNullableRefTypes.Size = new System.Drawing.Size(181, 19);
            this.chkUseNullableRefTypes.TabIndex = 2;
            this.chkUseNullableRefTypes.Text = "Use C# 8.0 Nullable Ref Types";
            this.chkUseNullableRefTypes.UseVisualStyleBackColor = true;
            // 
            // chkIncludeAttributes
            // 
            this.chkIncludeAttributes.AutoSize = true;
            this.chkIncludeAttributes.Checked = true;
            this.chkIncludeAttributes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeAttributes.Location = new System.Drawing.Point(22, 45);
            this.chkIncludeAttributes.Name = "chkIncludeAttributes";
            this.chkIncludeAttributes.Size = new System.Drawing.Size(120, 19);
            this.chkIncludeAttributes.TabIndex = 2;
            this.chkIncludeAttributes.Text = "Include Attributes";
            this.chkIncludeAttributes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Namespace:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNamespace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNamespace.Location = new System.Drawing.Point(116, 16);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(259, 23);
            this.txtNamespace.TabIndex = 0;
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 4);
            this.panel4.Controls.Add(this.txtClassCode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(273, 156);
            this.panel4.Name = "panel4";
            this.tableLayoutPanel1.SetRowSpan(this.panel4, 4);
            this.panel4.Size = new System.Drawing.Size(1077, 609);
            this.panel4.TabIndex = 3;
            // 
            // txtClassCode
            // 
            this.txtClassCode.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtClassCode.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.txtClassCode.AutoScrollMinSize = new System.Drawing.Size(158, 15);
            this.txtClassCode.BackBrush = null;
            this.txtClassCode.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.txtClassCode.CharHeight = 15;
            this.txtClassCode.CharWidth = 7;
            this.txtClassCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClassCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtClassCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClassCode.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtClassCode.IsReplaceMode = false;
            this.txtClassCode.Language = FastColoredTextBoxNS.Language.CSharp;
            this.txtClassCode.LeftBracket = '(';
            this.txtClassCode.LeftBracket2 = '{';
            this.txtClassCode.Location = new System.Drawing.Point(0, 0);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Paddings = new System.Windows.Forms.Padding(0);
            this.txtClassCode.RightBracket = ')';
            this.txtClassCode.RightBracket2 = '}';
            this.txtClassCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtClassCode.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtClassCode.ServiceColors")));
            this.txtClassCode.Size = new System.Drawing.Size(1077, 609);
            this.txtClassCode.TabIndex = 0;
            this.txtClassCode.Text = "fastColoredTextBox1";
            this.txtClassCode.Zoom = 100;
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTargetPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTargetPath.Location = new System.Drawing.Point(482, 16);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(358, 23);
            this.txtTargetPath.TabIndex = 0;
            // 
            // btnOpenTargetFolder
            // 
            this.btnOpenTargetFolder.Location = new System.Drawing.Point(846, 16);
            this.btnOpenTargetFolder.Name = "btnOpenTargetFolder";
            this.btnOpenTargetFolder.Size = new System.Drawing.Size(111, 24);
            this.btnOpenTargetFolder.TabIndex = 3;
            this.btnOpenTargetFolder.Text = "Open Folder...";
            this.btnOpenTargetFolder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Save to:";
            // 
            // btnSaveClasses
            // 
            this.btnSaveClasses.Location = new System.Drawing.Point(846, 46);
            this.btnSaveClasses.Name = "btnSaveClasses";
            this.btnSaveClasses.Size = new System.Drawing.Size(111, 24);
            this.btnSaveClasses.TabIndex = 3;
            this.btnSaveClasses.Text = "Save C# classes";
            this.btnSaveClasses.UseVisualStyleBackColor = true;
            // 
            // UCClassBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCClassBuilder";
            this.Size = new System.Drawing.Size(1353, 768);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTables)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtClassCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataTables;
        private FastColoredTextBoxNS.FastColoredTextBox txtClassCode;
        private System.Windows.Forms.Label label1;
        private Controls.ExtendedTextBox txtNamespace;
        private System.Windows.Forms.CheckBox chkIncludeAttributes;
        private System.Windows.Forms.CheckBox chkFullyAsyncReading;
        private System.Windows.Forms.CheckBox chkUseNullableRefTypes;
        private System.Windows.Forms.Button btnOpenTargetFolder;
        private Controls.ExtendedTextBox txtTargetPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveClasses;
    }
}
