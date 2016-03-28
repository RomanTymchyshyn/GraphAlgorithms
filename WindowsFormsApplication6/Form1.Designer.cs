using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using OpenTK.Graphics;

namespace WFA6
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.ChoosingAction = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Algorithms = new System.Windows.Forms.Button();
            this.DFS = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BFS = new System.Windows.Forms.Button();
            this.Kruskal = new System.Windows.Forms.Button();
            this.BellmanFord = new System.Windows.Forms.Button();
            this.Dejkstra = new System.Windows.Forms.Button();
            this.FlojdVorshell = new System.Windows.Forms.Button();
            this.Johnson = new System.Windows.Forms.Button();
            this.Prim = new System.Windows.Forms.Button();
            this.FordFalkerson = new System.Windows.Forms.Button();
            this.EdmondsKarp = new System.Windows.Forms.Button();
            this.gen_not_oriented = new System.Windows.Forms.Button();
            this.Graph_delete = new System.Windows.Forms.Button();
            this.Graph_clear = new System.Windows.Forms.Button();
            this.Information = new System.Windows.Forms.Label();
            this.simpleOpenGlControl1 = new WFA6.MyControl();
            this.makeGraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1162, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate Random";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Gen_Rand_Click);
            // 
            // ChoosingAction
            // 
            this.ChoosingAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChoosingAction.FormattingEnabled = true;
            this.ChoosingAction.Items.AddRange(new object[] {
            "Add Vertex",
            "Add Arc",
            "Add Edge",
            "Information"});
            this.ChoosingAction.Location = new System.Drawing.Point(1208, 88);
            this.ChoosingAction.Name = "ChoosingAction";
            this.ChoosingAction.Size = new System.Drawing.Size(107, 21);
            this.ChoosingAction.TabIndex = 3;
            this.ChoosingAction.Text = "Choose Action";
            this.ChoosingAction.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.ChoosingAction.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1228, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose Vertexes";
            this.label1.Visible = false;
            // 
            // Algorithms
            // 
            this.Algorithms.Location = new System.Drawing.Point(1208, 263);
            this.Algorithms.Name = "Algorithms";
            this.Algorithms.Size = new System.Drawing.Size(107, 24);
            this.Algorithms.TabIndex = 5;
            this.Algorithms.Text = "Algorithms";
            this.Algorithms.UseVisualStyleBackColor = true;
            this.Algorithms.Click += new System.EventHandler(this.Algorithms_Click);
            // 
            // DFS
            // 
            this.DFS.Location = new System.Drawing.Point(1162, 294);
            this.DFS.Name = "DFS";
            this.DFS.Size = new System.Drawing.Size(78, 27);
            this.DFS.TabIndex = 6;
            this.DFS.Text = "DFS";
            this.DFS.UseVisualStyleBackColor = true;
            this.DFS.Visible = false;
            this.DFS.Click += new System.EventHandler(this.DFS_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3;
            // 
            // BFS
            // 
            this.BFS.Location = new System.Drawing.Point(1274, 293);
            this.BFS.Name = "BFS";
            this.BFS.Size = new System.Drawing.Size(70, 29);
            this.BFS.TabIndex = 7;
            this.BFS.Text = "BFS";
            this.BFS.UseVisualStyleBackColor = true;
            this.BFS.Visible = false;
            this.BFS.Click += new System.EventHandler(this.BFS_Click);
            // 
            // Kruskal
            // 
            this.Kruskal.Location = new System.Drawing.Point(1162, 330);
            this.Kruskal.Name = "Kruskal";
            this.Kruskal.Size = new System.Drawing.Size(78, 29);
            this.Kruskal.TabIndex = 8;
            this.Kruskal.Text = "Kruskal";
            this.Kruskal.UseVisualStyleBackColor = true;
            this.Kruskal.Visible = false;
            this.Kruskal.Click += new System.EventHandler(this.Kruskal_Click);
            // 
            // BellmanFord
            // 
            this.BellmanFord.AutoSize = true;
            this.BellmanFord.Location = new System.Drawing.Point(1162, 365);
            this.BellmanFord.Name = "BellmanFord";
            this.BellmanFord.Size = new System.Drawing.Size(78, 29);
            this.BellmanFord.TabIndex = 9;
            this.BellmanFord.Text = "Bellman-Ford";
            this.BellmanFord.UseVisualStyleBackColor = true;
            this.BellmanFord.Visible = false;
            this.BellmanFord.Click += new System.EventHandler(this.BellmanFord_Click);
            // 
            // Dejkstra
            // 
            this.Dejkstra.Location = new System.Drawing.Point(1274, 363);
            this.Dejkstra.Name = "Dejkstra";
            this.Dejkstra.Size = new System.Drawing.Size(69, 32);
            this.Dejkstra.TabIndex = 10;
            this.Dejkstra.Text = "Dejkstra";
            this.Dejkstra.UseVisualStyleBackColor = true;
            this.Dejkstra.Visible = false;
            this.Dejkstra.Click += new System.EventHandler(this.Dejkstra_Click);
            // 
            // FlojdVorshell
            // 
            this.FlojdVorshell.Location = new System.Drawing.Point(1162, 401);
            this.FlojdVorshell.Name = "FlojdVorshell";
            this.FlojdVorshell.Size = new System.Drawing.Size(78, 32);
            this.FlojdVorshell.TabIndex = 11;
            this.FlojdVorshell.Text = "Flojd-Vorshell";
            this.FlojdVorshell.UseVisualStyleBackColor = true;
            this.FlojdVorshell.Visible = false;
            this.FlojdVorshell.Click += new System.EventHandler(this.FlojdVorshell_Click);
            // 
            // Johnson
            // 
            this.Johnson.Location = new System.Drawing.Point(1274, 401);
            this.Johnson.Name = "Johnson";
            this.Johnson.Size = new System.Drawing.Size(69, 32);
            this.Johnson.TabIndex = 12;
            this.Johnson.Text = "Johnson";
            this.Johnson.UseVisualStyleBackColor = true;
            this.Johnson.Visible = false;
            this.Johnson.Click += new System.EventHandler(this.Johnson_Click);
            // 
            // Prim
            // 
            this.Prim.Location = new System.Drawing.Point(1274, 328);
            this.Prim.Name = "Prim";
            this.Prim.Size = new System.Drawing.Size(69, 29);
            this.Prim.TabIndex = 13;
            this.Prim.Text = "Prim";
            this.Prim.UseVisualStyleBackColor = true;
            this.Prim.Visible = false;
            this.Prim.Click += new System.EventHandler(this.Prim_Click);
            // 
            // FordFalkerson
            // 
            this.FordFalkerson.Location = new System.Drawing.Point(1162, 439);
            this.FordFalkerson.Name = "FordFalkerson";
            this.FordFalkerson.Size = new System.Drawing.Size(85, 30);
            this.FordFalkerson.TabIndex = 14;
            this.FordFalkerson.Text = "Ford-Falkerson";
            this.FordFalkerson.UseVisualStyleBackColor = true;
            this.FordFalkerson.Visible = false;
            this.FordFalkerson.Click += new System.EventHandler(this.FordFalkerson_Click);
            // 
            // EdmondsKarp
            // 
            this.EdmondsKarp.Location = new System.Drawing.Point(1253, 439);
            this.EdmondsKarp.Name = "EdmondsKarp";
            this.EdmondsKarp.Size = new System.Drawing.Size(90, 30);
            this.EdmondsKarp.TabIndex = 15;
            this.EdmondsKarp.Text = "Edmonds-Karp";
            this.EdmondsKarp.UseVisualStyleBackColor = true;
            this.EdmondsKarp.Visible = false;
            this.EdmondsKarp.Click += new System.EventHandler(this.EdmondsKarp_Click);
            // 
            // gen_not_oriented
            // 
            this.gen_not_oriented.Location = new System.Drawing.Point(1208, 44);
            this.gen_not_oriented.Name = "gen_not_oriented";
            this.gen_not_oriented.Size = new System.Drawing.Size(129, 34);
            this.gen_not_oriented.TabIndex = 16;
            this.gen_not_oriented.Text = "Generate not oriented graph";
            this.gen_not_oriented.UseVisualStyleBackColor = true;
            this.gen_not_oriented.Click += new System.EventHandler(this.gen_not_oriented_Click);
            // 
            // Graph_delete
            // 
            this.Graph_delete.Location = new System.Drawing.Point(1162, 231);
            this.Graph_delete.Name = "Graph_delete";
            this.Graph_delete.Size = new System.Drawing.Size(85, 26);
            this.Graph_delete.TabIndex = 17;
            this.Graph_delete.Text = "Graph Delete";
            this.Graph_delete.UseVisualStyleBackColor = true;
            this.Graph_delete.Click += new System.EventHandler(this.Graph_delete_Click);
            // 
            // Graph_clear
            // 
            this.Graph_clear.Location = new System.Drawing.Point(1253, 231);
            this.Graph_clear.Name = "Graph_clear";
            this.Graph_clear.Size = new System.Drawing.Size(89, 26);
            this.Graph_clear.TabIndex = 18;
            this.Graph_clear.Text = "Graph Clear";
            this.Graph_clear.UseVisualStyleBackColor = true;
            this.Graph_clear.Click += new System.EventHandler(this.Graph_clear_Click);
            // 
            // Information
            // 
            this.Information.AutoSize = true;
            this.Information.Location = new System.Drawing.Point(1162, 489);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(59, 13);
            this.Information.TabIndex = 19;
            this.Information.Text = "Information";
            this.Information.Visible = false;
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Azure;
            this.simpleOpenGlControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleOpenGlControl1.BackgroundImage")));
            this.simpleOpenGlControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(1156, 704);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.VSync = false;
            this.simpleOpenGlControl1.Load += new System.EventHandler(this.simpleOpenGlControl1_Load);
            this.simpleOpenGlControl1.Click += new System.EventHandler(this.simpleOpenGlControl1_Click);
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            this.simpleOpenGlControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenGlControl1_KeyDown);
            this.simpleOpenGlControl1.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
            // 
            // makeGraph
            // 
            this.makeGraph.Location = new System.Drawing.Point(1165, 205);
            this.makeGraph.Name = "makeGraph";
            this.makeGraph.Size = new System.Drawing.Size(173, 20);
            this.makeGraph.TabIndex = 20;
            this.makeGraph.Text = "Make Graph";
            this.makeGraph.UseVisualStyleBackColor = true;
            this.makeGraph.Click += new System.EventHandler(this.makeGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 710);
            this.Controls.Add(this.makeGraph);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.Graph_clear);
            this.Controls.Add(this.Graph_delete);
            this.Controls.Add(this.gen_not_oriented);
            this.Controls.Add(this.EdmondsKarp);
            this.Controls.Add(this.FordFalkerson);
            this.Controls.Add(this.Prim);
            this.Controls.Add(this.Johnson);
            this.Controls.Add(this.FlojdVorshell);
            this.Controls.Add(this.Dejkstra);
            this.Controls.Add(this.BellmanFord);
            this.Controls.Add(this.Kruskal);
            this.Controls.Add(this.BFS);
            this.Controls.Add(this.DFS);
            this.Controls.Add(this.Algorithms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChoosingAction);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторна робота 5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControl simpleOpenGlControl1;
        public MyControl SimpleOpenGlControl1
        {
            get
            {
                return simpleOpenGlControl1;
            }
            set
            {
                simpleOpenGlControl1 = value;
            }
        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ChoosingAction;
        private Label label1;
        private Button Algorithms;
        private Button DFS;
        private Timer timer1;
        private Button BFS;
        private Button Kruskal;
        private Button BellmanFord;
        private Button Dejkstra;
        private Button FlojdVorshell;
        private Button Johnson;
        private Button Prim;
        private Button FordFalkerson;
        private Button EdmondsKarp;
        private Button gen_not_oriented;
        private Button Graph_delete;
        private Button Graph_clear;
        private Label Information;
        private Button makeGraph;
    
        public System.Windows.Forms.ComboBox ChoosedAction
        {
            get
            {
                return ChoosingAction;
            }
            set
            {
                ChoosingAction = value;
            }
        }
    }

    public class MyControl : Tao.Platform.Windows.SimpleOpenGlControl
    {
        public Graph graph = new Graph();
        public MyControl() : base() { }
    }
}

