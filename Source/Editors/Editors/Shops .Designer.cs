﻿namespace Editors
{
    partial class Editor_Shops
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor_Shops));
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstSold = new System.Windows.Forms.ListBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpSold = new System.Windows.Forms.GroupBox();
            this.butSold_Remove = new System.Windows.Forms.Button();
            this.butSold_Add = new System.Windows.Forms.Button();
            this.grpBought = new System.Windows.Forms.GroupBox();
            this.butBought_Remove = new System.Windows.Forms.Button();
            this.butBought_Add = new System.Windows.Forms.Button();
            this.lstBought = new System.Windows.Forms.ListBox();
            this.grpAddItem = new System.Windows.Forms.GroupBox();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.butConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butNew = new System.Windows.Forms.Button();
            this.butRemove = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.TreeView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.grpGeneral.SuspendLayout();
            this.grpSold.SuspendLayout();
            this.grpBought.SuspendLayout();
            this.grpAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(219, 412);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(250, 25);
            this.butSave.TabIndex = 16;
            this.butSave.Text = "Save All";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(475, 412);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(250, 25);
            this.butCancel.TabIndex = 17;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 20);
            this.txtName.TabIndex = 20;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Name:";
            // 
            // lstSold
            // 
            this.lstSold.FormattingEnabled = true;
            this.lstSold.Location = new System.Drawing.Point(6, 19);
            this.lstSold.Name = "lstSold";
            this.lstSold.Size = new System.Drawing.Size(238, 264);
            this.lstSold.TabIndex = 22;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cmbCurrency);
            this.grpGeneral.Controls.Add(this.label5);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.Controls.Add(this.label3);
            this.grpGeneral.Location = new System.Drawing.Point(219, 12);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(506, 68);
            this.grpGeneral.TabIndex = 23;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            this.grpGeneral.Visible = false;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(258, 36);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(242, 21);
            this.cmbCurrency.TabIndex = 22;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Default currency:";
            // 
            // grpSold
            // 
            this.grpSold.Controls.Add(this.butSold_Remove);
            this.grpSold.Controls.Add(this.butSold_Add);
            this.grpSold.Controls.Add(this.lstSold);
            this.grpSold.Location = new System.Drawing.Point(219, 86);
            this.grpSold.Name = "grpSold";
            this.grpSold.Size = new System.Drawing.Size(250, 321);
            this.grpSold.TabIndex = 24;
            this.grpSold.TabStop = false;
            this.grpSold.Text = "Items Sold";
            this.grpSold.Visible = false;
            // 
            // butSold_Remove
            // 
            this.butSold_Remove.Location = new System.Drawing.Point(126, 289);
            this.butSold_Remove.Name = "butSold_Remove";
            this.butSold_Remove.Size = new System.Drawing.Size(118, 23);
            this.butSold_Remove.TabIndex = 24;
            this.butSold_Remove.Text = "Remove";
            this.butSold_Remove.UseVisualStyleBackColor = true;
            this.butSold_Remove.Click += new System.EventHandler(this.butSold_Remove_Click);
            // 
            // butSold_Add
            // 
            this.butSold_Add.Location = new System.Drawing.Point(6, 289);
            this.butSold_Add.Name = "butSold_Add";
            this.butSold_Add.Size = new System.Drawing.Size(118, 23);
            this.butSold_Add.TabIndex = 23;
            this.butSold_Add.Text = "Add";
            this.butSold_Add.UseVisualStyleBackColor = true;
            this.butSold_Add.Click += new System.EventHandler(this.butSold_Add_Click);
            // 
            // grpBought
            // 
            this.grpBought.Controls.Add(this.butBought_Remove);
            this.grpBought.Controls.Add(this.butBought_Add);
            this.grpBought.Controls.Add(this.lstBought);
            this.grpBought.Location = new System.Drawing.Point(475, 87);
            this.grpBought.Name = "grpBought";
            this.grpBought.Size = new System.Drawing.Size(250, 320);
            this.grpBought.TabIndex = 25;
            this.grpBought.TabStop = false;
            this.grpBought.Text = "Items Bought";
            this.grpBought.Visible = false;
            // 
            // butBought_Remove
            // 
            this.butBought_Remove.Location = new System.Drawing.Point(126, 288);
            this.butBought_Remove.Name = "butBought_Remove";
            this.butBought_Remove.Size = new System.Drawing.Size(118, 23);
            this.butBought_Remove.TabIndex = 26;
            this.butBought_Remove.Text = "Remove";
            this.butBought_Remove.UseVisualStyleBackColor = true;
            this.butBought_Remove.Click += new System.EventHandler(this.butBought_Remove_Click);
            // 
            // butBought_Add
            // 
            this.butBought_Add.Location = new System.Drawing.Point(6, 288);
            this.butBought_Add.Name = "butBought_Add";
            this.butBought_Add.Size = new System.Drawing.Size(118, 23);
            this.butBought_Add.TabIndex = 25;
            this.butBought_Add.Text = "Add";
            this.butBought_Add.UseVisualStyleBackColor = true;
            this.butBought_Add.Click += new System.EventHandler(this.butBought_Add_Click);
            // 
            // lstBought
            // 
            this.lstBought.FormattingEnabled = true;
            this.lstBought.Location = new System.Drawing.Point(6, 19);
            this.lstBought.Name = "lstBought";
            this.lstBought.Size = new System.Drawing.Size(238, 264);
            this.lstBought.TabIndex = 22;
            // 
            // grpAddItem
            // 
            this.grpAddItem.Controls.Add(this.numAmount);
            this.grpAddItem.Controls.Add(this.numPrice);
            this.grpAddItem.Controls.Add(this.cmbItems);
            this.grpAddItem.Controls.Add(this.butConfirm);
            this.grpAddItem.Controls.Add(this.label4);
            this.grpAddItem.Controls.Add(this.label2);
            this.grpAddItem.Controls.Add(this.label1);
            this.grpAddItem.Location = new System.Drawing.Point(219, 86);
            this.grpAddItem.Name = "grpAddItem";
            this.grpAddItem.Size = new System.Drawing.Size(506, 320);
            this.grpAddItem.TabIndex = 26;
            this.grpAddItem.TabStop = false;
            this.grpAddItem.Text = "Add Item";
            this.grpAddItem.Visible = false;
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(170, 133);
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(166, 20);
            this.numAmount.TabIndex = 22;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(170, 172);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(166, 20);
            this.numPrice.TabIndex = 21;
            // 
            // cmbItems
            // 
            this.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(170, 93);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(166, 21);
            this.cmbItems.TabIndex = 20;
            // 
            // butConfirm
            // 
            this.butConfirm.Location = new System.Drawing.Point(170, 198);
            this.butConfirm.Name = "butConfirm";
            this.butConfirm.Size = new System.Drawing.Size(166, 20);
            this.butConfirm.TabIndex = 19;
            this.butConfirm.Text = "Confirm";
            this.butConfirm.UseVisualStyleBackColor = true;
            this.butConfirm.Click += new System.EventHandler(this.butConfirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item:";
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(12, 412);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(98, 25);
            this.butNew.TabIndex = 27;
            this.butNew.Text = "New";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butRemove
            // 
            this.butRemove.Location = new System.Drawing.Point(116, 412);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(98, 25);
            this.butRemove.TabIndex = 28;
            this.butRemove.Text = "Remove";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // List
            // 
            this.List.HideSelection = false;
            this.List.Location = new System.Drawing.Point(12, 38);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(201, 369);
            this.List.TabIndex = 23;
            this.List.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.List_AfterSelect);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(12, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(201, 20);
            this.txtFilter.TabIndex = 43;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // Editor_Shops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 447);
            this.ControlBox = false;
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.List);
            this.Controls.Add(this.butRemove);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.grpAddItem);
            this.Controls.Add(this.grpBought);
            this.Controls.Add(this.grpSold);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Editor_Shops";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Editor";
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpSold.ResumeLayout(false);
            this.grpBought.ResumeLayout(false);
            this.grpAddItem.ResumeLayout(false);
            this.grpAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butCancel;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstSold;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpSold;
        private System.Windows.Forms.GroupBox grpBought;
        private System.Windows.Forms.ListBox lstBought;
        private System.Windows.Forms.Button butSold_Remove;
        private System.Windows.Forms.Button butSold_Add;
        private System.Windows.Forms.Button butBought_Remove;
        private System.Windows.Forms.Button butBought_Add;
        private System.Windows.Forms.GroupBox grpAddItem;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.ComboBox cmbItems;
        private System.Windows.Forms.Button butConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Button butRemove;
        private System.Windows.Forms.TreeView List;
        public System.Windows.Forms.TextBox txtFilter;
    }
}