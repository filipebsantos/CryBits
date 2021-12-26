﻿using DarkUI.Controls;
using System.Windows.Forms;

namespace Editors
{
    partial class Editor_Maps
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor_Maps));
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tolStrip = new DarkUI.Controls.DarkToolStrip();
            this.butSaveAll = new System.Windows.Forms.ToolStripButton();
            this.butReload = new System.Windows.Forms.ToolStripButton();
            this.butClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.butMNormal = new System.Windows.Forms.ToolStripButton();
            this.butMAttributes = new System.Windows.Forms.ToolStripButton();
            this.butMZones = new System.Windows.Forms.ToolStripButton();
            this.butMLighting = new System.Windows.Forms.ToolStripButton();
            this.butMNPCs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.butCut = new System.Windows.Forms.ToolStripButton();
            this.butCopy = new System.Windows.Forms.ToolStripButton();
            this.butPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.butPencil = new System.Windows.Forms.ToolStripButton();
            this.butRectangle = new System.Windows.Forms.ToolStripButton();
            this.butArea = new System.Windows.Forms.ToolStripButton();
            this.butDiscover = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.butFill = new System.Windows.Forms.ToolStripButton();
            this.butEraser = new System.Windows.Forms.ToolStripButton();
            this.butZoom_Normal = new System.Windows.Forms.ToolStripButton();
            this.butZoom_2x = new System.Windows.Forms.ToolStripButton();
            this.butZoom_4x = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.butVisualization = new System.Windows.Forms.ToolStripButton();
            this.butEdition = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.butGrid = new System.Windows.Forms.ToolStripButton();
            this.butAudio = new System.Windows.Forms.ToolStripButton();
            this.butEditors = new System.Windows.Forms.ToolStripDropDownButton();
            this.butEditors_Classes = new System.Windows.Forms.ToolStripMenuItem();
            this.butEditors_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.butEditors_Interface = new System.Windows.Forms.ToolStripMenuItem();
            this.butEditors_Items = new System.Windows.Forms.ToolStripMenuItem();
            this.butEditors_NPCs = new System.Windows.Forms.ToolStripMenuItem();
            this.butEditors_Shops = new System.Windows.Forms.ToolStripMenuItem();
            this.butEditors_Tiles = new System.Windows.Forms.ToolStripMenuItem();
            this.picTile = new System.Windows.Forms.PictureBox();
            this.scrlTileY = new System.Windows.Forms.VScrollBar();
            this.scrlMapX = new System.Windows.Forms.HScrollBar();
            this.scrlMapY = new System.Windows.Forms.VScrollBar();
            this.scrlTileX = new System.Windows.Forms.HScrollBar();
            this.Strip = new DarkUI.Controls.DarkStatusStrip();
            this.FPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Revision = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.Position = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkAuto = new DarkUI.Controls.DarkCheckBox();
            this.cmbTiles = new DarkUI.Controls.DarkComboBox();
            this.grpLayers = new DarkUI.Controls.DarkGroupBox();
            this.Trip_Layers = new DarkUI.Controls.DarkToolStrip();
            this.butLayers_Add = new System.Windows.Forms.ToolStripButton();
            this.butLayers_Remove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.butLayers_Up = new System.Windows.Forms.ToolStripButton();
            this.butLayers_Down = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.butLayers_Edit = new System.Windows.Forms.ToolStripButton();
            this.lstLayers = new System.Windows.Forms.ListView();
            this.colVisible = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNúmero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpLayer_Add = new DarkUI.Controls.DarkGroupBox();
            this.txtLayer_Name = new DarkUI.Controls.DarkTextBox();
            this.cmbLayers_Type = new DarkUI.Controls.DarkComboBox();
            this.butLayer_Edit = new DarkUI.Controls.DarkButton();
            this.butLayer_Cancel = new DarkUI.Controls.DarkButton();
            this.label2 = new DarkUI.Controls.DarkLabel();
            this.label1 = new DarkUI.Controls.DarkLabel();
            this.butLayer_Add = new DarkUI.Controls.DarkButton();
            this.grpZones = new DarkUI.Controls.DarkGroupBox();
            this.scrlZone_Clear = new DarkUI.Controls.DarkButton();
            this.scrlZone = new System.Windows.Forms.HScrollBar();
            this.butLight_Clear = new DarkUI.Controls.DarkButton();
            this.grpLighting = new DarkUI.Controls.DarkGroupBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.grpTile = new DarkUI.Controls.DarkGroupBox();
            this.grpAttributes = new DarkUI.Controls.DarkGroupBox();
            this.grpA_Item = new DarkUI.Controls.DarkGroupBox();
            this.numA_Item_Amount = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbA_Item = new DarkUI.Controls.DarkComboBox();
            this.label15 = new DarkUI.Controls.DarkLabel();
            this.label16 = new DarkUI.Controls.DarkLabel();
            this.optA_Item = new DarkUI.Controls.DarkRadioButton();
            this.butAttributes_Import = new DarkUI.Controls.DarkButton();
            this.optA_Warp = new DarkUI.Controls.DarkRadioButton();
            this.optA_DirBlock = new DarkUI.Controls.DarkRadioButton();
            this.optA_Block = new DarkUI.Controls.DarkRadioButton();
            this.butAttributes_Clear = new DarkUI.Controls.DarkButton();
            this.grpA_Warp = new DarkUI.Controls.DarkGroupBox();
            this.cmbA_Warp_Direction = new DarkUI.Controls.DarkComboBox();
            this.label7 = new DarkUI.Controls.DarkLabel();
            this.numA_Warp_Y = new DarkUI.Controls.DarkNumericUpDown();
            this.numA_Warp_X = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbA_Warp_Map = new DarkUI.Controls.DarkComboBox();
            this.label6 = new DarkUI.Controls.DarkLabel();
            this.label5 = new DarkUI.Controls.DarkLabel();
            this.label4 = new DarkUI.Controls.DarkLabel();
            this.picTile_Background = new System.Windows.Forms.PictureBox();
            this.grpNPCs = new DarkUI.Controls.DarkGroupBox();
            this.groupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.cmbNPC = new DarkUI.Controls.DarkComboBox();
            this.label13 = new DarkUI.Controls.DarkLabel();
            this.label11 = new DarkUI.Controls.DarkLabel();
            this.numNPC_Zone = new DarkUI.Controls.DarkNumericUpDown();
            this.label9 = new DarkUI.Controls.DarkLabel();
            this.butNPC_Add = new DarkUI.Controls.DarkButton();
            this.groupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstNPC = new System.Windows.Forms.ListBox();
            this.butNPC_Remove = new DarkUI.Controls.DarkButton();
            this.butNPC_Clear = new DarkUI.Controls.DarkButton();
            this.List = new System.Windows.Forms.TreeView();
            this.txtFilter = new DarkUI.Controls.DarkTextBox();
            this.picBackground = new System.Windows.Forms.Panel();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.prgProperties = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.butNew = new System.Windows.Forms.ToolStripButton();
            this.butRemove = new System.Windows.Forms.ToolStripButton();
            this.tolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).BeginInit();
            this.Strip.SuspendLayout();
            this.grpLayers.SuspendLayout();
            this.Trip_Layers.SuspendLayout();
            this.grpLayer_Add.SuspendLayout();
            this.grpZones.SuspendLayout();
            this.grpLighting.SuspendLayout();
            this.grpTile.SuspendLayout();
            this.grpAttributes.SuspendLayout();
            this.grpA_Item.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numA_Item_Amount)).BeginInit();
            this.grpA_Warp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numA_Warp_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA_Warp_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTile_Background)).BeginInit();
            this.grpNPCs.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNPC_Zone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.picBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tolStrip
            // 
            this.tolStrip.AutoSize = false;
            this.tolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butSaveAll,
            this.butReload,
            this.butClearAll,
            this.toolStripSeparator3,
            this.butMNormal,
            this.butMAttributes,
            this.butMZones,
            this.butMLighting,
            this.butMNPCs,
            this.toolStripSeparator2,
            this.butCut,
            this.butCopy,
            this.butPaste,
            this.toolStripSeparator11,
            this.butPencil,
            this.butRectangle,
            this.butArea,
            this.butDiscover,
            this.toolStripSeparator8,
            this.butFill,
            this.butEraser,
            this.toolStripSeparator5,
            this.butZoom_Normal,
            this.butZoom_2x,
            this.butZoom_4x,
            this.toolStripSeparator19,
            this.butVisualization,
            this.butEdition,
            this.toolStripSeparator1,
            this.butGrid,
            this.butAudio,
            this.butEditors});
            this.tolStrip.Location = new System.Drawing.Point(0, 0);
            this.tolStrip.Name = "tolStrip";
            this.tolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.tolStrip.Size = new System.Drawing.Size(1366, 25);
            this.tolStrip.TabIndex = 78;
            this.tolStrip.Text = "toolStrip2";
            // 
            // butSaveAll
            // 
            this.butSaveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butSaveAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butSaveAll.Image = ((System.Drawing.Image)(resources.GetObject("butSaveAll.Image")));
            this.butSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butSaveAll.Name = "butSaveAll";
            this.butSaveAll.Size = new System.Drawing.Size(23, 22);
            this.butSaveAll.Text = "Save All";
            this.butSaveAll.Click += new System.EventHandler(this.butSaveAll_Click);
            // 
            // butReload
            // 
            this.butReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butReload.Image = ((System.Drawing.Image)(resources.GetObject("butReload.Image")));
            this.butReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(23, 22);
            this.butReload.Text = "Reload";
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // butClearAll
            // 
            this.butClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butClearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butClearAll.Image = ((System.Drawing.Image)(resources.GetObject("butClearAll.Image")));
            this.butClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butClearAll.Name = "butClearAll";
            this.butClearAll.Size = new System.Drawing.Size(23, 22);
            this.butClearAll.Text = "Clear All";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // butMNormal
            // 
            this.butMNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butMNormal.Checked = true;
            this.butMNormal.CheckOnClick = true;
            this.butMNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.butMNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butMNormal.Image = ((System.Drawing.Image)(resources.GetObject("butMNormal.Image")));
            this.butMNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMNormal.Name = "butMNormal";
            this.butMNormal.Size = new System.Drawing.Size(23, 22);
            this.butMNormal.Text = "Normal";
            this.butMNormal.CheckedChanged += new System.EventHandler(this.butMNormal_CheckedChanged);
            this.butMNormal.Click += new System.EventHandler(this.butMNormal_Click);
            // 
            // butMAttributes
            // 
            this.butMAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butMAttributes.CheckOnClick = true;
            this.butMAttributes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMAttributes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butMAttributes.Image = ((System.Drawing.Image)(resources.GetObject("butMAttributes.Image")));
            this.butMAttributes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMAttributes.Name = "butMAttributes";
            this.butMAttributes.Size = new System.Drawing.Size(23, 22);
            this.butMAttributes.Text = "Attributes";
            this.butMAttributes.Click += new System.EventHandler(this.butMAttributes_Click);
            // 
            // butMZones
            // 
            this.butMZones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butMZones.CheckOnClick = true;
            this.butMZones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMZones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butMZones.Image = ((System.Drawing.Image)(resources.GetObject("butMZones.Image")));
            this.butMZones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMZones.Name = "butMZones";
            this.butMZones.Size = new System.Drawing.Size(23, 22);
            this.butMZones.Text = "Zones";
            this.butMZones.CheckedChanged += new System.EventHandler(this.butMZones_CheckedChanged);
            this.butMZones.Click += new System.EventHandler(this.butMZones_Click);
            // 
            // butMLighting
            // 
            this.butMLighting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butMLighting.CheckOnClick = true;
            this.butMLighting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMLighting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butMLighting.Image = ((System.Drawing.Image)(resources.GetObject("butMLighting.Image")));
            this.butMLighting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMLighting.Name = "butMLighting";
            this.butMLighting.Size = new System.Drawing.Size(23, 22);
            this.butMLighting.Text = "Lighting";
            this.butMLighting.CheckedChanged += new System.EventHandler(this.butMLighting_CheckedChanged);
            this.butMLighting.Click += new System.EventHandler(this.butMLighting_Click);
            // 
            // butMNPCs
            // 
            this.butMNPCs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butMNPCs.CheckOnClick = true;
            this.butMNPCs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMNPCs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butMNPCs.Image = ((System.Drawing.Image)(resources.GetObject("butMNPCs.Image")));
            this.butMNPCs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMNPCs.Name = "butMNPCs";
            this.butMNPCs.Size = new System.Drawing.Size(23, 22);
            this.butMNPCs.Text = "NPCs";
            this.butMNPCs.Click += new System.EventHandler(this.butMNPCs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // butCut
            // 
            this.butCut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butCut.Enabled = false;
            this.butCut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butCut.Image = ((System.Drawing.Image)(resources.GetObject("butCut.Image")));
            this.butCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butCut.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.butCut.Name = "butCut";
            this.butCut.Size = new System.Drawing.Size(23, 22);
            this.butCut.Text = "Cut";
            this.butCut.Click += new System.EventHandler(this.butCut_Click);
            // 
            // butCopy
            // 
            this.butCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butCopy.Enabled = false;
            this.butCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butCopy.Image = ((System.Drawing.Image)(resources.GetObject("butCopy.Image")));
            this.butCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butCopy.Name = "butCopy";
            this.butCopy.Size = new System.Drawing.Size(23, 22);
            this.butCopy.Text = "Copy";
            this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
            // 
            // butPaste
            // 
            this.butPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butPaste.Enabled = false;
            this.butPaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butPaste.Image = ((System.Drawing.Image)(resources.GetObject("butPaste.Image")));
            this.butPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butPaste.Name = "butPaste";
            this.butPaste.Size = new System.Drawing.Size(23, 22);
            this.butPaste.Text = "Paste";
            this.butPaste.Click += new System.EventHandler(this.butPaste_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator11.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // butPencil
            // 
            this.butPencil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butPencil.Checked = true;
            this.butPencil.CheckOnClick = true;
            this.butPencil.CheckState = System.Windows.Forms.CheckState.Checked;
            this.butPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butPencil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butPencil.Image = ((System.Drawing.Image)(resources.GetObject("butPencil.Image")));
            this.butPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butPencil.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.butPencil.Name = "butPencil";
            this.butPencil.Size = new System.Drawing.Size(23, 22);
            this.butPencil.Text = "Pencil";
            this.butPencil.Click += new System.EventHandler(this.butPencil_Click);
            // 
            // butRectangle
            // 
            this.butRectangle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butRectangle.CheckOnClick = true;
            this.butRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butRectangle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butRectangle.Image = ((System.Drawing.Image)(resources.GetObject("butRectangle.Image")));
            this.butRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butRectangle.Name = "butRectangle";
            this.butRectangle.Size = new System.Drawing.Size(23, 22);
            this.butRectangle.Text = "Rectangle";
            this.butRectangle.Click += new System.EventHandler(this.butRectangle_Click);
            // 
            // butArea
            // 
            this.butArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butArea.CheckOnClick = true;
            this.butArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butArea.Image = ((System.Drawing.Image)(resources.GetObject("butArea.Image")));
            this.butArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butArea.Name = "butArea";
            this.butArea.Size = new System.Drawing.Size(23, 22);
            this.butArea.Text = "Select area";
            this.butArea.Click += new System.EventHandler(this.butArea_Click);
            // 
            // butDiscover
            // 
            this.butDiscover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butDiscover.CheckOnClick = true;
            this.butDiscover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butDiscover.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butDiscover.Image = ((System.Drawing.Image)(resources.GetObject("butDiscover.Image")));
            this.butDiscover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butDiscover.Name = "butDiscover";
            this.butDiscover.Size = new System.Drawing.Size(23, 22);
            this.butDiscover.Text = "Discover tile";
            this.butDiscover.Click += new System.EventHandler(this.butDiscover_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator8.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // butFill
            // 
            this.butFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butFill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butFill.Image = ((System.Drawing.Image)(resources.GetObject("butFill.Image")));
            this.butFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butFill.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.butFill.Name = "butFill";
            this.butFill.Size = new System.Drawing.Size(23, 22);
            this.butFill.Text = "Fill";
            this.butFill.Click += new System.EventHandler(this.butFill_Click);
            // 
            // butEraser
            // 
            this.butEraser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butEraser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butEraser.Image = ((System.Drawing.Image)(resources.GetObject("butEraser.Image")));
            this.butEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butEraser.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.butEraser.Name = "butEraser";
            this.butEraser.Size = new System.Drawing.Size(23, 22);
            this.butEraser.Text = "Clear";
            this.butEraser.Click += new System.EventHandler(this.butEraser_Click);
            // 
            // butZoom_Normal
            // 
            this.butZoom_Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butZoom_Normal.Checked = true;
            this.butZoom_Normal.CheckOnClick = true;
            this.butZoom_Normal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.butZoom_Normal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butZoom_Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butZoom_Normal.Image = ((System.Drawing.Image)(resources.GetObject("butZoom_Normal.Image")));
            this.butZoom_Normal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butZoom_Normal.Name = "butZoom_Normal";
            this.butZoom_Normal.Size = new System.Drawing.Size(23, 22);
            this.butZoom_Normal.Text = "1:1";
            this.butZoom_Normal.Click += new System.EventHandler(this.butZoom_Normal_Click);
            // 
            // butZoom_2x
            // 
            this.butZoom_2x.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butZoom_2x.CheckOnClick = true;
            this.butZoom_2x.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butZoom_2x.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butZoom_2x.Image = ((System.Drawing.Image)(resources.GetObject("butZoom_2x.Image")));
            this.butZoom_2x.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butZoom_2x.Name = "butZoom_2x";
            this.butZoom_2x.Size = new System.Drawing.Size(23, 22);
            this.butZoom_2x.Text = "1:2";
            this.butZoom_2x.Click += new System.EventHandler(this.butZoom_2x_Click);
            // 
            // butZoom_4x
            // 
            this.butZoom_4x.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butZoom_4x.CheckOnClick = true;
            this.butZoom_4x.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butZoom_4x.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butZoom_4x.Image = ((System.Drawing.Image)(resources.GetObject("butZoom_4x.Image")));
            this.butZoom_4x.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butZoom_4x.Name = "butZoom_4x";
            this.butZoom_4x.Size = new System.Drawing.Size(23, 22);
            this.butZoom_4x.Text = "1:4";
            this.butZoom_4x.Click += new System.EventHandler(this.butZoom_4x_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator19.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // butVisualization
            // 
            this.butVisualization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butVisualization.Checked = true;
            this.butVisualization.CheckOnClick = true;
            this.butVisualization.CheckState = System.Windows.Forms.CheckState.Checked;
            this.butVisualization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butVisualization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butVisualization.Image = ((System.Drawing.Image)(resources.GetObject("butVisualization.Image")));
            this.butVisualization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butVisualization.Name = "butVisualization";
            this.butVisualization.Size = new System.Drawing.Size(23, 22);
            this.butVisualization.Text = "Visualization";
            this.butVisualization.Click += new System.EventHandler(this.butVisualization_Click);
            // 
            // butEdition
            // 
            this.butEdition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butEdition.CheckOnClick = true;
            this.butEdition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butEdition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butEdition.Image = ((System.Drawing.Image)(resources.GetObject("butEdition.Image")));
            this.butEdition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butEdition.Name = "butEdition";
            this.butEdition.Size = new System.Drawing.Size(23, 22);
            this.butEdition.Text = "Edition";
            this.butEdition.Click += new System.EventHandler(this.butEdition_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // butGrid
            // 
            this.butGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butGrid.CheckOnClick = true;
            this.butGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butGrid.Image = ((System.Drawing.Image)(resources.GetObject("butGrid.Image")));
            this.butGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butGrid.Name = "butGrid";
            this.butGrid.Size = new System.Drawing.Size(23, 22);
            this.butGrid.Text = "Grids";
            this.butGrid.Click += new System.EventHandler(this.butGrids_Click);
            // 
            // butAudio
            // 
            this.butAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butAudio.Checked = true;
            this.butAudio.CheckOnClick = true;
            this.butAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.butAudio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butAudio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butAudio.Image = ((System.Drawing.Image)(resources.GetObject("butAudio.Image")));
            this.butAudio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAudio.Name = "butAudio";
            this.butAudio.Size = new System.Drawing.Size(23, 22);
            this.butAudio.Text = "Audios";
            this.butAudio.Click += new System.EventHandler(this.butAudio_Click);
            // 
            // butEditors
            // 
            this.butEditors.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butEditors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butEditors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butEditors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butEditors_Classes,
            this.butEditors_Data,
            this.butEditors_Interface,
            this.butEditors_Items,
            this.butEditors_NPCs,
            this.butEditors_Shops,
            this.butEditors_Tiles});
            this.butEditors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butEditors.Image = ((System.Drawing.Image)(resources.GetObject("butEditors.Image")));
            this.butEditors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butEditors.Name = "butEditors";
            this.butEditors.Size = new System.Drawing.Size(102, 22);
            this.butEditors.Text = "Content Editors";
            // 
            // butEditors_Classes
            // 
            this.butEditors_Classes.Name = "butEditors_Classes";
            this.butEditors_Classes.Size = new System.Drawing.Size(120, 22);
            this.butEditors_Classes.Text = "Classes";
            this.butEditors_Classes.Click += new System.EventHandler(this.butEditors_Classes_Click);
            // 
            // butEditors_Data
            // 
            this.butEditors_Data.Name = "butEditors_Data";
            this.butEditors_Data.Size = new System.Drawing.Size(120, 22);
            this.butEditors_Data.Text = "Data";
            this.butEditors_Data.Click += new System.EventHandler(this.butEditors_Data_Click);
            // 
            // butEditors_Interface
            // 
            this.butEditors_Interface.Name = "butEditors_Interface";
            this.butEditors_Interface.Size = new System.Drawing.Size(120, 22);
            this.butEditors_Interface.Text = "Interface";
            this.butEditors_Interface.Click += new System.EventHandler(this.butEditors_Interface_Click);
            // 
            // butEditors_Items
            // 
            this.butEditors_Items.Name = "butEditors_Items";
            this.butEditors_Items.Size = new System.Drawing.Size(120, 22);
            this.butEditors_Items.Text = "Items";
            this.butEditors_Items.Click += new System.EventHandler(this.butEditors_Items_Click);
            // 
            // butEditors_NPCs
            // 
            this.butEditors_NPCs.Name = "butEditors_NPCs";
            this.butEditors_NPCs.Size = new System.Drawing.Size(120, 22);
            this.butEditors_NPCs.Text = "NPCs";
            this.butEditors_NPCs.Click += new System.EventHandler(this.butEditors_NPCs_Click);
            // 
            // butEditors_Shops
            // 
            this.butEditors_Shops.Name = "butEditors_Shops";
            this.butEditors_Shops.Size = new System.Drawing.Size(120, 22);
            this.butEditors_Shops.Text = "Shops";
            this.butEditors_Shops.Click += new System.EventHandler(this.butEditors_Shops_Click);
            // 
            // butEditors_Tiles
            // 
            this.butEditors_Tiles.Name = "butEditors_Tiles";
            this.butEditors_Tiles.Size = new System.Drawing.Size(120, 22);
            this.butEditors_Tiles.Text = "Tiles";
            this.butEditors_Tiles.Click += new System.EventHandler(this.butEditors_Tiles_Click);
            // 
            // picTile
            // 
            this.picTile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picTile.BackColor = System.Drawing.Color.Black;
            this.picTile.Location = new System.Drawing.Point(0, 48);
            this.picTile.Name = "picTile";
            this.picTile.Size = new System.Drawing.Size(256, 363);
            this.picTile.TabIndex = 2;
            this.picTile.TabStop = false;
            this.picTile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTile_MouseDown);
            this.picTile.MouseLeave += new System.EventHandler(this.picTile_MouseLeave);
            this.picTile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTile_MouseMove);
            this.picTile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picTile_MouseUp);
            this.picTile.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picTile_MouseWheel);
            // 
            // scrlTileY
            // 
            this.scrlTileY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scrlTileY.Cursor = System.Windows.Forms.Cursors.Default;
            this.scrlTileY.LargeChange = 32;
            this.scrlTileY.Location = new System.Drawing.Point(256, 48);
            this.scrlTileY.Maximum = 255;
            this.scrlTileY.Name = "scrlTileY";
            this.scrlTileY.Size = new System.Drawing.Size(19, 363);
            this.scrlTileY.SmallChange = 32;
            this.scrlTileY.TabIndex = 67;
            // 
            // scrlMapX
            // 
            this.scrlMapX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrlMapX.LargeChange = 1;
            this.scrlMapX.Location = new System.Drawing.Point(279, 637);
            this.scrlMapX.Name = "scrlMapX";
            this.scrlMapX.Size = new System.Drawing.Size(797, 19);
            this.scrlMapX.TabIndex = 68;
            // 
            // scrlMapY
            // 
            this.scrlMapY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrlMapY.Cursor = System.Windows.Forms.Cursors.Default;
            this.scrlMapY.LargeChange = 1;
            this.scrlMapY.Location = new System.Drawing.Point(1076, 28);
            this.scrlMapY.Maximum = 255;
            this.scrlMapY.Name = "scrlMapY";
            this.scrlMapY.Size = new System.Drawing.Size(19, 608);
            this.scrlMapY.TabIndex = 69;
            // 
            // scrlTileX
            // 
            this.scrlTileX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scrlTileX.LargeChange = 32;
            this.scrlTileX.Location = new System.Drawing.Point(0, 411);
            this.scrlTileX.Name = "scrlTileX";
            this.scrlTileX.Size = new System.Drawing.Size(256, 19);
            this.scrlTileX.SmallChange = 32;
            this.scrlTileX.TabIndex = 15;
            // 
            // Strip
            // 
            this.Strip.AutoSize = false;
            this.Strip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Strip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FPS,
            this.toolStripSeparator6,
            this.Revision,
            this.toolStripSeparator9,
            this.Position});
            this.Strip.Location = new System.Drawing.Point(0, 656);
            this.Strip.Name = "Strip";
            this.Strip.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.Strip.Size = new System.Drawing.Size(1366, 31);
            this.Strip.SizingGrip = false;
            this.Strip.TabIndex = 83;
            this.Strip.Text = "0";
            // 
            // FPS
            // 
            this.FPS.AutoSize = false;
            this.FPS.Name = "FPS";
            this.FPS.Size = new System.Drawing.Size(50, 18);
            this.FPS.Text = "FPS: 64";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // Revision
            // 
            this.Revision.Name = "Revision";
            this.Revision.Size = new System.Drawing.Size(51, 18);
            this.Revision.Text = "Revision";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // Position
            // 
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(50, 18);
            this.Position.Text = "Position";
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(10, 19);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(48, 17);
            this.chkAuto.TabIndex = 101;
            this.chkAuto.Text = "Auto";
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // cmbTiles
            // 
            this.cmbTiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTiles.FormattingEnabled = true;
            this.cmbTiles.Location = new System.Drawing.Point(0, 27);
            this.cmbTiles.Name = "cmbTiles";
            this.cmbTiles.Size = new System.Drawing.Size(275, 21);
            this.cmbTiles.TabIndex = 102;
            this.cmbTiles.SelectedIndexChanged += new System.EventHandler(this.cmbTiles_SelectedIndexChanged);
            // 
            // grpLayers
            // 
            this.grpLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpLayers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpLayers.Controls.Add(this.Trip_Layers);
            this.grpLayers.Controls.Add(this.lstLayers);
            this.grpLayers.Location = new System.Drawing.Point(12, 491);
            this.grpLayers.Name = "grpLayers";
            this.grpLayers.Size = new System.Drawing.Size(258, 166);
            this.grpLayers.TabIndex = 97;
            this.grpLayers.TabStop = false;
            this.grpLayers.Text = "Layers";
            // 
            // Trip_Layers
            // 
            this.Trip_Layers.AutoSize = false;
            this.Trip_Layers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Trip_Layers.Dock = System.Windows.Forms.DockStyle.None;
            this.Trip_Layers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Trip_Layers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butLayers_Add,
            this.butLayers_Remove,
            this.toolStripSeparator12,
            this.butLayers_Up,
            this.butLayers_Down,
            this.toolStripSeparator13,
            this.butLayers_Edit});
            this.Trip_Layers.Location = new System.Drawing.Point(6, 135);
            this.Trip_Layers.Name = "Trip_Layers";
            this.Trip_Layers.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.Trip_Layers.Size = new System.Drawing.Size(139, 25);
            this.Trip_Layers.TabIndex = 109;
            // 
            // butLayers_Add
            // 
            this.butLayers_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butLayers_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLayers_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butLayers_Add.Image = ((System.Drawing.Image)(resources.GetObject("butLayers_Add.Image")));
            this.butLayers_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butLayers_Add.Name = "butLayers_Add";
            this.butLayers_Add.Size = new System.Drawing.Size(23, 22);
            this.butLayers_Add.Text = "Add";
            this.butLayers_Add.Click += new System.EventHandler(this.butLayers_Add_Click);
            // 
            // butLayers_Remove
            // 
            this.butLayers_Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butLayers_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLayers_Remove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butLayers_Remove.Image = ((System.Drawing.Image)(resources.GetObject("butLayers_Remove.Image")));
            this.butLayers_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butLayers_Remove.Name = "butLayers_Remove";
            this.butLayers_Remove.Size = new System.Drawing.Size(23, 22);
            this.butLayers_Remove.Text = "Remove";
            this.butLayers_Remove.ToolTipText = "Remover";
            this.butLayers_Remove.Click += new System.EventHandler(this.butLayers_Remove_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator12.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // butLayers_Up
            // 
            this.butLayers_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butLayers_Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLayers_Up.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butLayers_Up.Image = ((System.Drawing.Image)(resources.GetObject("butLayers_Up.Image")));
            this.butLayers_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butLayers_Up.Name = "butLayers_Up";
            this.butLayers_Up.Size = new System.Drawing.Size(23, 22);
            this.butLayers_Up.Text = "Up";
            this.butLayers_Up.ToolTipText = "Acima";
            this.butLayers_Up.Click += new System.EventHandler(this.butLayers_Up_Click);
            // 
            // butLayers_Down
            // 
            this.butLayers_Down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butLayers_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLayers_Down.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butLayers_Down.Image = ((System.Drawing.Image)(resources.GetObject("butLayers_Down.Image")));
            this.butLayers_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butLayers_Down.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.butLayers_Down.Name = "butLayers_Down";
            this.butLayers_Down.Size = new System.Drawing.Size(23, 22);
            this.butLayers_Down.Text = "Down";
            this.butLayers_Down.ToolTipText = "Abaixo";
            this.butLayers_Down.Click += new System.EventHandler(this.butLayers_Down_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator13.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // butLayers_Edit
            // 
            this.butLayers_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butLayers_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLayers_Edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butLayers_Edit.Image = ((System.Drawing.Image)(resources.GetObject("butLayers_Edit.Image")));
            this.butLayers_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butLayers_Edit.Name = "butLayers_Edit";
            this.butLayers_Edit.Size = new System.Drawing.Size(24, 24);
            this.butLayers_Edit.Text = "Edit";
            this.butLayers_Edit.ToolTipText = "Editar";
            this.butLayers_Edit.Click += new System.EventHandler(this.butLayers_Edit_Click);
            // 
            // lstLayers
            // 
            this.lstLayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstLayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLayers.CheckBoxes = true;
            this.lstLayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVisible,
            this.colNúmero,
            this.colName,
            this.colType});
            this.lstLayers.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstLayers.FullRowSelect = true;
            this.lstLayers.HideSelection = false;
            this.lstLayers.Location = new System.Drawing.Point(6, 19);
            this.lstLayers.MultiSelect = false;
            this.lstLayers.Name = "lstLayers";
            this.lstLayers.Size = new System.Drawing.Size(246, 111);
            this.lstLayers.TabIndex = 2;
            this.lstLayers.UseCompatibleStateImageBehavior = false;
            this.lstLayers.View = System.Windows.Forms.View.Details;
            // 
            // colVisible
            // 
            this.colVisible.Text = "";
            this.colVisible.Width = 20;
            // 
            // colNúmero
            // 
            this.colNúmero.Text = "Nº";
            this.colNúmero.Width = 24;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 70;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 50;
            // 
            // grpLayer_Add
            // 
            this.grpLayer_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpLayer_Add.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpLayer_Add.Controls.Add(this.txtLayer_Name);
            this.grpLayer_Add.Controls.Add(this.cmbLayers_Type);
            this.grpLayer_Add.Controls.Add(this.butLayer_Edit);
            this.grpLayer_Add.Controls.Add(this.butLayer_Cancel);
            this.grpLayer_Add.Controls.Add(this.label2);
            this.grpLayer_Add.Controls.Add(this.label1);
            this.grpLayer_Add.Controls.Add(this.butLayer_Add);
            this.grpLayer_Add.Location = new System.Drawing.Point(12, 491);
            this.grpLayer_Add.Name = "grpLayer_Add";
            this.grpLayer_Add.Size = new System.Drawing.Size(258, 166);
            this.grpLayer_Add.TabIndex = 98;
            this.grpLayer_Add.TabStop = false;
            this.grpLayer_Add.Text = "Add Layer";
            this.grpLayer_Add.Visible = false;
            // 
            // txtLayer_Name
            // 
            this.txtLayer_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtLayer_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLayer_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtLayer_Name.Location = new System.Drawing.Point(9, 33);
            this.txtLayer_Name.Name = "txtLayer_Name";
            this.txtLayer_Name.Size = new System.Drawing.Size(243, 20);
            this.txtLayer_Name.TabIndex = 4;
            // 
            // cmbLayers_Type
            // 
            this.cmbLayers_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbLayers_Type.FormattingEnabled = true;
            this.cmbLayers_Type.Location = new System.Drawing.Point(10, 71);
            this.cmbLayers_Type.Name = "cmbLayers_Type";
            this.cmbLayers_Type.Size = new System.Drawing.Size(242, 21);
            this.cmbLayers_Type.TabIndex = 8;
            // 
            // butLayer_Edit
            // 
            this.butLayer_Edit.Location = new System.Drawing.Point(10, 136);
            this.butLayer_Edit.Name = "butLayer_Edit";
            this.butLayer_Edit.Padding = new System.Windows.Forms.Padding(5);
            this.butLayer_Edit.Size = new System.Drawing.Size(171, 24);
            this.butLayer_Edit.TabIndex = 10;
            this.butLayer_Edit.Text = "Edit";
            this.butLayer_Edit.Click += new System.EventHandler(this.butLayer_Edit_Click);
            // 
            // butLayer_Cancel
            // 
            this.butLayer_Cancel.Location = new System.Drawing.Point(186, 136);
            this.butLayer_Cancel.Name = "butLayer_Cancel";
            this.butLayer_Cancel.Padding = new System.Windows.Forms.Padding(5);
            this.butLayer_Cancel.Size = new System.Drawing.Size(66, 24);
            this.butLayer_Cancel.TabIndex = 9;
            this.butLayer_Cancel.Text = "Cancel";
            this.butLayer_Cancel.Click += new System.EventHandler(this.butLayer_Cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // butLayer_Add
            // 
            this.butLayer_Add.Location = new System.Drawing.Point(10, 136);
            this.butLayer_Add.Name = "butLayer_Add";
            this.butLayer_Add.Padding = new System.Windows.Forms.Padding(5);
            this.butLayer_Add.Size = new System.Drawing.Size(171, 24);
            this.butLayer_Add.TabIndex = 3;
            this.butLayer_Add.Text = "Add";
            this.butLayer_Add.Click += new System.EventHandler(this.butLayer_Add_Click);
            // 
            // grpZones
            // 
            this.grpZones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpZones.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpZones.Controls.Add(this.scrlZone_Clear);
            this.grpZones.Controls.Add(this.scrlZone);
            this.grpZones.Location = new System.Drawing.Point(0, 27);
            this.grpZones.Name = "grpZones";
            this.grpZones.Size = new System.Drawing.Size(275, 630);
            this.grpZones.TabIndex = 103;
            this.grpZones.TabStop = false;
            this.grpZones.Text = "Zone: None";
            this.grpZones.Visible = false;
            // 
            // scrlZone_Clear
            // 
            this.scrlZone_Clear.Location = new System.Drawing.Point(8, 46);
            this.scrlZone_Clear.Name = "scrlZone_Clear";
            this.scrlZone_Clear.Padding = new System.Windows.Forms.Padding(5);
            this.scrlZone_Clear.Size = new System.Drawing.Size(256, 24);
            this.scrlZone_Clear.TabIndex = 12;
            this.scrlZone_Clear.Text = "Clear";
            this.scrlZone_Clear.Click += new System.EventHandler(this.scrlZone_Clear_Click);
            // 
            // scrlZone
            // 
            this.scrlZone.Location = new System.Drawing.Point(8, 24);
            this.scrlZone.Name = "scrlZone";
            this.scrlZone.Size = new System.Drawing.Size(256, 19);
            this.scrlZone.TabIndex = 0;
            this.scrlZone.ValueChanged += new System.EventHandler(this.scrlZone_ValueChanged);
            // 
            // butLight_Clear
            // 
            this.butLight_Clear.Location = new System.Drawing.Point(7, 23);
            this.butLight_Clear.Name = "butLight_Clear";
            this.butLight_Clear.Padding = new System.Windows.Forms.Padding(5);
            this.butLight_Clear.Size = new System.Drawing.Size(262, 24);
            this.butLight_Clear.TabIndex = 12;
            this.butLight_Clear.Text = "Clear lights";
            this.butLight_Clear.Click += new System.EventHandler(this.butLight_Clear_Click);
            // 
            // grpLighting
            // 
            this.grpLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpLighting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpLighting.Controls.Add(this.butLight_Clear);
            this.grpLighting.Location = new System.Drawing.Point(0, 27);
            this.grpLighting.Name = "grpLighting";
            this.grpLighting.Size = new System.Drawing.Size(275, 630);
            this.grpLighting.TabIndex = 104;
            this.grpLighting.TabStop = false;
            this.grpLighting.Text = "Lighting";
            this.grpLighting.Visible = false;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 1;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // grpTile
            // 
            this.grpTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpTile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpTile.Controls.Add(this.chkAuto);
            this.grpTile.Location = new System.Drawing.Point(12, 435);
            this.grpTile.Name = "grpTile";
            this.grpTile.Size = new System.Drawing.Size(252, 52);
            this.grpTile.TabIndex = 13;
            this.grpTile.TabStop = false;
            this.grpTile.Text = "Mode";
            // 
            // grpAttributes
            // 
            this.grpAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpAttributes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpAttributes.Controls.Add(this.grpA_Item);
            this.grpAttributes.Controls.Add(this.optA_Item);
            this.grpAttributes.Controls.Add(this.butAttributes_Import);
            this.grpAttributes.Controls.Add(this.optA_Warp);
            this.grpAttributes.Controls.Add(this.optA_DirBlock);
            this.grpAttributes.Controls.Add(this.optA_Block);
            this.grpAttributes.Controls.Add(this.butAttributes_Clear);
            this.grpAttributes.Controls.Add(this.grpA_Warp);
            this.grpAttributes.Location = new System.Drawing.Point(0, 27);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Size = new System.Drawing.Size(275, 630);
            this.grpAttributes.TabIndex = 105;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Attributes";
            this.grpAttributes.Visible = false;
            // 
            // grpA_Item
            // 
            this.grpA_Item.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpA_Item.Controls.Add(this.numA_Item_Amount);
            this.grpA_Item.Controls.Add(this.cmbA_Item);
            this.grpA_Item.Controls.Add(this.label15);
            this.grpA_Item.Controls.Add(this.label16);
            this.grpA_Item.Location = new System.Drawing.Point(9, 148);
            this.grpA_Item.Name = "grpA_Item";
            this.grpA_Item.Size = new System.Drawing.Size(255, 106);
            this.grpA_Item.TabIndex = 8;
            this.grpA_Item.TabStop = false;
            this.grpA_Item.Text = "Item";
            this.grpA_Item.Visible = false;
            // 
            // numA_Item_Amount
            // 
            this.numA_Item_Amount.Location = new System.Drawing.Point(14, 73);
            this.numA_Item_Amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numA_Item_Amount.Name = "numA_Item_Amount";
            this.numA_Item_Amount.Size = new System.Drawing.Size(228, 20);
            this.numA_Item_Amount.TabIndex = 4;
            this.numA_Item_Amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numA_Item_Amount.ValueChanged += new System.EventHandler(this.numA_Item_Amount_ValueChanged);
            // 
            // cmbA_Item
            // 
            this.cmbA_Item.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbA_Item.FormattingEnabled = true;
            this.cmbA_Item.Location = new System.Drawing.Point(14, 30);
            this.cmbA_Item.Name = "cmbA_Item";
            this.cmbA_Item.Size = new System.Drawing.Size(228, 21);
            this.cmbA_Item.TabIndex = 3;
            this.cmbA_Item.SelectedIndexChanged += new System.EventHandler(this.cmbA_Item_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label15.Location = new System.Drawing.Point(11, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Amount:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label16.Location = new System.Drawing.Point(10, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Item:";
            // 
            // optA_Item
            // 
            this.optA_Item.AutoSize = true;
            this.optA_Item.Location = new System.Drawing.Point(17, 113);
            this.optA_Item.Name = "optA_Item";
            this.optA_Item.Size = new System.Drawing.Size(45, 17);
            this.optA_Item.TabIndex = 80;
            this.optA_Item.Text = "Item";
            this.optA_Item.CheckedChanged += new System.EventHandler(this.optA_Item_CheckedChanged);
            this.optA_Item.Click += new System.EventHandler(this.optA_Item_CheckedChanged);
            // 
            // butAttributes_Import
            // 
            this.butAttributes_Import.Location = new System.Drawing.Point(138, 24);
            this.butAttributes_Import.Name = "butAttributes_Import";
            this.butAttributes_Import.Padding = new System.Windows.Forms.Padding(5);
            this.butAttributes_Import.Size = new System.Drawing.Size(126, 24);
            this.butAttributes_Import.TabIndex = 79;
            this.butAttributes_Import.Text = "Import attributes";
            this.butAttributes_Import.Click += new System.EventHandler(this.butAttributes_Import_Click);
            // 
            // optA_Warp
            // 
            this.optA_Warp.AutoSize = true;
            this.optA_Warp.Location = new System.Drawing.Point(17, 93);
            this.optA_Warp.Name = "optA_Warp";
            this.optA_Warp.Size = new System.Drawing.Size(51, 17);
            this.optA_Warp.TabIndex = 78;
            this.optA_Warp.Text = "Warp";
            this.optA_Warp.CheckedChanged += new System.EventHandler(this.optA_Warp_CheckedChanged);
            this.optA_Warp.Click += new System.EventHandler(this.optA_Warp_CheckedChanged);
            // 
            // optA_DirBlock
            // 
            this.optA_DirBlock.AutoSize = true;
            this.optA_DirBlock.Location = new System.Drawing.Point(17, 73);
            this.optA_DirBlock.Name = "optA_DirBlock";
            this.optA_DirBlock.Size = new System.Drawing.Size(70, 17);
            this.optA_DirBlock.TabIndex = 77;
            this.optA_DirBlock.Text = "Dir. block";
            // 
            // optA_Block
            // 
            this.optA_Block.AutoSize = true;
            this.optA_Block.Checked = true;
            this.optA_Block.Location = new System.Drawing.Point(17, 53);
            this.optA_Block.Name = "optA_Block";
            this.optA_Block.Size = new System.Drawing.Size(52, 17);
            this.optA_Block.TabIndex = 76;
            this.optA_Block.TabStop = true;
            this.optA_Block.Text = "Block";
            // 
            // butAttributes_Clear
            // 
            this.butAttributes_Clear.Location = new System.Drawing.Point(9, 24);
            this.butAttributes_Clear.Name = "butAttributes_Clear";
            this.butAttributes_Clear.Padding = new System.Windows.Forms.Padding(5);
            this.butAttributes_Clear.Size = new System.Drawing.Size(127, 24);
            this.butAttributes_Clear.TabIndex = 12;
            this.butAttributes_Clear.Text = "Clear";
            this.butAttributes_Clear.Click += new System.EventHandler(this.butAttributes_Clear_Click);
            // 
            // grpA_Warp
            // 
            this.grpA_Warp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpA_Warp.Controls.Add(this.cmbA_Warp_Direction);
            this.grpA_Warp.Controls.Add(this.label7);
            this.grpA_Warp.Controls.Add(this.numA_Warp_Y);
            this.grpA_Warp.Controls.Add(this.numA_Warp_X);
            this.grpA_Warp.Controls.Add(this.cmbA_Warp_Map);
            this.grpA_Warp.Controls.Add(this.label6);
            this.grpA_Warp.Controls.Add(this.label5);
            this.grpA_Warp.Controls.Add(this.label4);
            this.grpA_Warp.Location = new System.Drawing.Point(9, 148);
            this.grpA_Warp.Name = "grpA_Warp";
            this.grpA_Warp.Size = new System.Drawing.Size(255, 149);
            this.grpA_Warp.TabIndex = 7;
            this.grpA_Warp.TabStop = false;
            this.grpA_Warp.Text = "Warp";
            this.grpA_Warp.Visible = false;
            // 
            // cmbA_Warp_Direction
            // 
            this.cmbA_Warp_Direction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbA_Warp_Direction.FormattingEnabled = true;
            this.cmbA_Warp_Direction.Items.AddRange(new object[] {
            "Keep",
            "Up",
            "Down",
            "Left",
            "Right"});
            this.cmbA_Warp_Direction.Location = new System.Drawing.Point(14, 120);
            this.cmbA_Warp_Direction.Name = "cmbA_Warp_Direction";
            this.cmbA_Warp_Direction.Size = new System.Drawing.Size(228, 21);
            this.cmbA_Warp_Direction.TabIndex = 8;
            this.cmbA_Warp_Direction.SelectedIndexChanged += new System.EventHandler(this.cmbA_Warp_Direction_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label7.Location = new System.Drawing.Point(10, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Direction:";
            // 
            // numA_Warp_Y
            // 
            this.numA_Warp_Y.Location = new System.Drawing.Point(134, 77);
            this.numA_Warp_Y.Name = "numA_Warp_Y";
            this.numA_Warp_Y.Size = new System.Drawing.Size(108, 20);
            this.numA_Warp_Y.TabIndex = 5;
            this.numA_Warp_Y.ValueChanged += new System.EventHandler(this.numA_Warp_Y_ValueChanged);
            // 
            // numA_Warp_X
            // 
            this.numA_Warp_X.Location = new System.Drawing.Point(14, 76);
            this.numA_Warp_X.Name = "numA_Warp_X";
            this.numA_Warp_X.Size = new System.Drawing.Size(108, 20);
            this.numA_Warp_X.TabIndex = 4;
            this.numA_Warp_X.ValueChanged += new System.EventHandler(this.numA_Warp_X_ValueChanged);
            // 
            // cmbA_Warp_Map
            // 
            this.cmbA_Warp_Map.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbA_Warp_Map.FormattingEnabled = true;
            this.cmbA_Warp_Map.Location = new System.Drawing.Point(14, 33);
            this.cmbA_Warp_Map.Name = "cmbA_Warp_Map";
            this.cmbA_Warp_Map.Size = new System.Drawing.Size(228, 21);
            this.cmbA_Warp_Map.TabIndex = 3;
            this.cmbA_Warp_Map.SelectedIndexChanged += new System.EventHandler(this.cmbA_Warp_Map_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label6.Location = new System.Drawing.Point(135, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label5.Location = new System.Drawing.Point(11, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label4.Location = new System.Drawing.Point(10, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Map:";
            // 
            // picTile_Background
            // 
            this.picTile_Background.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picTile_Background.BackColor = System.Drawing.Color.Black;
            this.picTile_Background.Location = new System.Drawing.Point(0, 48);
            this.picTile_Background.Name = "picTile_Background";
            this.picTile_Background.Size = new System.Drawing.Size(256, 363);
            this.picTile_Background.TabIndex = 107;
            this.picTile_Background.TabStop = false;
            // 
            // grpNPCs
            // 
            this.grpNPCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpNPCs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpNPCs.Controls.Add(this.groupBox2);
            this.grpNPCs.Controls.Add(this.groupBox1);
            this.grpNPCs.Location = new System.Drawing.Point(0, 26);
            this.grpNPCs.Name = "grpNPCs";
            this.grpNPCs.Size = new System.Drawing.Size(275, 630);
            this.grpNPCs.TabIndex = 104;
            this.grpNPCs.TabStop = false;
            this.grpNPCs.Text = "NPCs";
            this.grpNPCs.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox2.Controls.Add(this.cmbNPC);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.numNPC_Zone);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.butNPC_Add);
            this.groupBox2.Location = new System.Drawing.Point(12, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 159);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add";
            // 
            // cmbNPC
            // 
            this.cmbNPC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbNPC.FormattingEnabled = true;
            this.cmbNPC.Location = new System.Drawing.Point(10, 36);
            this.cmbNPC.Name = "cmbNPC";
            this.cmbNPC.Size = new System.Drawing.Size(239, 21);
            this.cmbNPC.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label13.Location = new System.Drawing.Point(41, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "(Click on the map to set a specific location)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label11.Location = new System.Drawing.Point(7, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "NPC:";
            // 
            // numNPC_Zone
            // 
            this.numNPC_Zone.Location = new System.Drawing.Point(10, 78);
            this.numNPC_Zone.Name = "numNPC_Zone";
            this.numNPC_Zone.Size = new System.Drawing.Size(239, 20);
            this.numNPC_Zone.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label9.Location = new System.Drawing.Point(8, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Zone:";
            // 
            // butNPC_Add
            // 
            this.butNPC_Add.Location = new System.Drawing.Point(10, 104);
            this.butNPC_Add.Name = "butNPC_Add";
            this.butNPC_Add.Padding = new System.Windows.Forms.Padding(5);
            this.butNPC_Add.Size = new System.Drawing.Size(239, 22);
            this.butNPC_Add.TabIndex = 3;
            this.butNPC_Add.Text = "Add";
            this.butNPC_Add.Click += new System.EventHandler(this.butNPC_Add_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox1.Controls.Add(this.lstNPC);
            this.groupBox1.Controls.Add(this.butNPC_Remove);
            this.groupBox1.Controls.Add(this.butNPC_Clear);
            this.groupBox1.Location = new System.Drawing.Point(11, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 231);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List";
            // 
            // lstNPC
            // 
            this.lstNPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstNPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstNPC.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstNPC.FormattingEnabled = true;
            this.lstNPC.Location = new System.Drawing.Point(7, 19);
            this.lstNPC.Name = "lstNPC";
            this.lstNPC.Size = new System.Drawing.Size(243, 171);
            this.lstNPC.TabIndex = 0;
            // 
            // butNPC_Remove
            // 
            this.butNPC_Remove.Location = new System.Drawing.Point(6, 198);
            this.butNPC_Remove.Name = "butNPC_Remove";
            this.butNPC_Remove.Padding = new System.Windows.Forms.Padding(5);
            this.butNPC_Remove.Size = new System.Drawing.Size(121, 19);
            this.butNPC_Remove.TabIndex = 2;
            this.butNPC_Remove.Text = "Remove";
            this.butNPC_Remove.Click += new System.EventHandler(this.butNPC_Remove_Click);
            // 
            // butNPC_Clear
            // 
            this.butNPC_Clear.Location = new System.Drawing.Point(129, 198);
            this.butNPC_Clear.Name = "butNPC_Clear";
            this.butNPC_Clear.Padding = new System.Windows.Forms.Padding(5);
            this.butNPC_Clear.Size = new System.Drawing.Size(121, 19);
            this.butNPC_Clear.TabIndex = 4;
            this.butNPC_Clear.Text = "Clear";
            this.butNPC_Clear.Click += new System.EventHandler(this.butNPC_Clear_Click);
            // 
            // List
            // 
            this.List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.ForeColor = System.Drawing.Color.Gainsboro;
            this.List.HideSelection = false;
            this.List.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.List.Location = new System.Drawing.Point(1101, 73);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(256, 258);
            this.List.TabIndex = 109;
            this.List.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.List_AfterSelect);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtFilter.Location = new System.Drawing.Point(1101, 26);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(256, 20);
            this.txtFilter.TabIndex = 112;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // picBackground
            // 
            this.picBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackground.BackColor = System.Drawing.Color.Black;
            this.picBackground.Controls.Add(this.picMap);
            this.picBackground.Location = new System.Drawing.Point(276, 28);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(800, 608);
            this.picBackground.TabIndex = 113;
            // 
            // picMap
            // 
            this.picMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMap.BackColor = System.Drawing.Color.Black;
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Location = new System.Drawing.Point(0, 0);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(800, 734);
            this.picMap.TabIndex = 3;
            this.picMap.TabStop = false;
            this.picMap.SizeChanged += new System.EventHandler(this.picMap_SizeChanged);
            this.picMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseDown);
            this.picMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseMove);
            this.picMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseUp);
            this.picMap.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseWheel);
            // 
            // prgProperties
            // 
            this.prgProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prgProperties.CategoryForeColor = System.Drawing.Color.Gainsboro;
            this.prgProperties.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.CommandsBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.CommandsForeColor = System.Drawing.Color.Gainsboro;
            this.prgProperties.CommandsVisibleIfAvailable = false;
            this.prgProperties.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.prgProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgProperties.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.prgProperties.HelpBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.HelpForeColor = System.Drawing.Color.Gainsboro;
            this.prgProperties.HelpVisible = false;
            this.prgProperties.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.prgProperties.Location = new System.Drawing.Point(1101, 337);
            this.prgProperties.Name = "prgProperties";
            this.prgProperties.Size = new System.Drawing.Size(256, 320);
            this.prgProperties.TabIndex = 114;
            this.prgProperties.ToolbarVisible = false;
            this.prgProperties.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.prgProperties.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.ViewForeColor = System.Drawing.Color.Gainsboro;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butNew,
            this.butRemove});
            this.toolStrip1.Location = new System.Drawing.Point(1101, 48);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(99, 25);
            this.toolStrip1.TabIndex = 115;
            // 
            // butNew
            // 
            this.butNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butNew.Image = ((System.Drawing.Image)(resources.GetObject("butNew.Image")));
            this.butNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(23, 22);
            this.butNew.Text = "Add";
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butRemove
            // 
            this.butRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.butRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.butRemove.Image = ((System.Drawing.Image)(resources.GetObject("butRemove.Image")));
            this.butRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(23, 22);
            this.butRemove.Text = "Remove";
            this.butRemove.ToolTipText = "Remover";
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // Editor_Maps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1366, 687);
            this.Controls.Add(this.List);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpAttributes);
            this.Controls.Add(this.prgProperties);
            this.Controls.Add(this.picBackground);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.picTile);
            this.Controls.Add(this.grpTile);
            this.Controls.Add(this.cmbTiles);
            this.Controls.Add(this.Strip);
            this.Controls.Add(this.tolStrip);
            this.Controls.Add(this.scrlTileX);
            this.Controls.Add(this.scrlMapY);
            this.Controls.Add(this.scrlMapX);
            this.Controls.Add(this.scrlTileY);
            this.Controls.Add(this.grpLayers);
            this.Controls.Add(this.grpZones);
            this.Controls.Add(this.grpLayer_Add);
            this.Controls.Add(this.picTile_Background);
            this.Controls.Add(this.grpLighting);
            this.Controls.Add(this.grpNPCs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Editor_Maps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CryBits Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_Maps_FormClosing);
            this.Load += new System.EventHandler(this.Editor_Maps_Load);
            this.SizeChanged += new System.EventHandler(this.Editor_Maps_SizeChanged);
            this.tolStrip.ResumeLayout(false);
            this.tolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).EndInit();
            this.Strip.ResumeLayout(false);
            this.Strip.PerformLayout();
            this.grpLayers.ResumeLayout(false);
            this.Trip_Layers.ResumeLayout(false);
            this.Trip_Layers.PerformLayout();
            this.grpLayer_Add.ResumeLayout(false);
            this.grpLayer_Add.PerformLayout();
            this.grpZones.ResumeLayout(false);
            this.grpLighting.ResumeLayout(false);
            this.grpTile.ResumeLayout(false);
            this.grpTile.PerformLayout();
            this.grpAttributes.ResumeLayout(false);
            this.grpAttributes.PerformLayout();
            this.grpA_Item.ResumeLayout(false);
            this.grpA_Item.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numA_Item_Amount)).EndInit();
            this.grpA_Warp.ResumeLayout(false);
            this.grpA_Warp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numA_Warp_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA_Warp_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTile_Background)).EndInit();
            this.grpNPCs.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNPC_Zone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.picBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private DarkToolStrip tolStrip;
        private System.Windows.Forms.ToolStripButton butSaveAll;
        private System.Windows.Forms.ToolStripButton butClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton butPencil;
        private System.Windows.Forms.ToolStripButton butFill;
        public System.Windows.Forms.ToolStripButton butZoom_Normal;
        public System.Windows.Forms.ToolStripButton butZoom_2x;
        public System.Windows.Forms.ToolStripButton butZoom_4x;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        public System.Windows.Forms.ToolStripButton butVisualization;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton butGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.PictureBox picTile;
        public System.Windows.Forms.VScrollBar scrlTileY;
        public System.Windows.Forms.HScrollBar scrlMapX;
        public System.Windows.Forms.VScrollBar scrlMapY;
        public System.Windows.Forms.HScrollBar scrlTileX;
        private DarkStatusStrip Strip;
        private System.Windows.Forms.ToolStripStatusLabel Revision;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripStatusLabel Position;
        public System.Windows.Forms.ToolStripButton butEdition;
        private DarkGroupBox grpLayers;
        internal System.Windows.Forms.ColumnHeader colNúmero;
        internal System.Windows.Forms.ColumnHeader colVisible;
        internal System.Windows.Forms.ColumnHeader colName;
        public DarkCheckBox chkAuto;
        private DarkGroupBox grpLayer_Add;
        private DarkButton butLayer_Add;
        private System.Windows.Forms.ColumnHeader colType;
        private DarkLabel label2;
        private DarkLabel label1;
        private DarkTextBox txtLayer_Name;
        private DarkComboBox cmbLayers_Type;
        private DarkButton butLayer_Cancel;
        private DarkButton butLayer_Edit;
        public ListView lstLayers;
        public System.Windows.Forms.ToolStripButton butDiscover;
        public System.Windows.Forms.ToolStripButton butRectangle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton butEraser;
        private System.Windows.Forms.ToolStripButton butArea;
        public System.Windows.Forms.ToolStripButton butMNormal;
        public System.Windows.Forms.ToolStripButton butMZones;
        private DarkGroupBox grpZones;
        private System.Windows.Forms.HScrollBar scrlZone;
        private DarkButton scrlZone_Clear;
        public System.Windows.Forms.ToolStripButton butMLighting;
        public System.Windows.Forms.ToolStripButton butCut;
        public System.Windows.Forms.ToolStripButton butCopy;
        private System.Windows.Forms.ToolStripButton butPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private DarkButton butLight_Clear;
        private DarkGroupBox grpLighting;
        public DarkComboBox cmbTiles;
        private System.Windows.Forms.Timer tmrUpdate;
        private DarkGroupBox grpTile;
        public System.Windows.Forms.ToolStripButton butAudio;
        private System.Windows.Forms.ToolStripButton butReload;
        public System.Windows.Forms.ToolStripButton butMAttributes;
        private DarkGroupBox grpAttributes;
        private DarkButton butAttributes_Clear;
        private System.Windows.Forms.ToolStripStatusLabel FPS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.PictureBox picTile_Background;
        public System.Windows.Forms.ToolStripButton butMNPCs;
        private DarkGroupBox grpNPCs;
        private DarkButton butNPC_Add;
        private DarkButton butNPC_Remove;
        private DarkComboBox cmbNPC;
        private System.Windows.Forms.ListBox lstNPC;
        private DarkButton butNPC_Clear;
        private DarkRadioButton optA_Block;
        private DarkRadioButton optA_Warp;
        private DarkButton butAttributes_Import;
        public DarkRadioButton optA_DirBlock;
        private DarkNumericUpDown numA_Warp_Y;
        private DarkNumericUpDown numA_Warp_X;
        private DarkComboBox cmbA_Warp_Map;
        private DarkLabel label6;
        private DarkLabel label5;
        private DarkLabel label4;
        private DarkGroupBox grpA_Warp;
        private DarkComboBox cmbA_Warp_Direction;
        private DarkLabel label7;
        private DarkGroupBox groupBox2;
        private DarkLabel label11;
        private DarkNumericUpDown numNPC_Zone;
        private DarkLabel label9;
        private DarkGroupBox groupBox1;
        private DarkLabel label13;
        private DarkRadioButton optA_Item;
        private DarkGroupBox grpA_Item;
        private DarkNumericUpDown numA_Item_Amount;
        private DarkComboBox cmbA_Item;
        private DarkLabel label15;
        private DarkToolStrip Trip_Layers;
        private System.Windows.Forms.ToolStripButton butLayers_Add;
        private System.Windows.Forms.ToolStripButton butLayers_Remove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton butLayers_Up;
        public System.Windows.Forms.ToolStripButton butLayers_Down;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton butLayers_Edit;
        public System.Windows.Forms.TreeView List;
        private System.Windows.Forms.ToolStripDropDownButton butEditors;
        private System.Windows.Forms.ToolStripMenuItem butEditors_Classes;
        private System.Windows.Forms.ToolStripMenuItem butEditors_Data;
        private System.Windows.Forms.ToolStripMenuItem butEditors_Interface;
        private System.Windows.Forms.ToolStripMenuItem butEditors_Items;
        private System.Windows.Forms.ToolStripMenuItem butEditors_NPCs;
        private System.Windows.Forms.ToolStripMenuItem butEditors_Shops;
        private System.Windows.Forms.ToolStripMenuItem butEditors_Tiles;
        public DarkTextBox txtFilter;
        private DarkLabel label16;
        private System.Windows.Forms.Panel picBackground;
        public System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.PropertyGrid prgProperties;
        private DarkToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butNew;
        private System.Windows.Forms.ToolStripButton butRemove;
    }
}