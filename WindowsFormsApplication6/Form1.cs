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
using System.Threading;

namespace WFA6
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        private int selected_vertex1 = -1;
        public Dialog window = new Dialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.SkyBlue);
            SetupViewport();
            this.SimpleOpenGlControl1.graph.Max_W = SimpleOpenGlControl1.Width;
            this.SimpleOpenGlControl1.graph.Max_H = SimpleOpenGlControl1.Height;
            label1.Visible = false;
            Application.Idle += Application_Idle;
        }

        private void SetupViewport()
        {
            int w = this.simpleOpenGlControl1.Width;
            int h = this.simpleOpenGlControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        void Application_Idle(object sender, EventArgs e)
        {
            simpleOpenGlControl1.Invalidate();
        }
        
        private void Render()
         {
             GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
             GL.MatrixMode(MatrixMode.Modelview);
             GL.LoadIdentity();
             this.SimpleOpenGlControl1.graph.Draw();
             GL.Flush();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetupViewport();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            simpleOpenGlControl1.Width = this.Size.Width - 200;
            simpleOpenGlControl1.Height = this.Size.Height - 40;
            SetupViewport();
            simpleOpenGlControl1.Invalidate();
        }

        private void Gen_Rand_Click(object sender, EventArgs e)
        {
            this.SimpleOpenGlControl1.graph.Delete();
            this.SimpleOpenGlControl1.graph.gen_rand();
            window.Info.Text = "Enter here";
            Information.Text = "Information\n";
            label1.Visible = false;
        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void simpleOpenGlControl1_Click(object sender, EventArgs e)
        {
            switch(ChoosingAction.Text)
            {
                case "Add Vertex":
                    if (Cursor.Position.X >= 18 && Cursor.Position.X < simpleOpenGlControl1.Width - 5 &&
                        Cursor.Position.Y >= 20 && Cursor.Position.Y < simpleOpenGlControl1.Height + 10)
                    {
                        this.SimpleOpenGlControl1.graph.AddVertex(Cursor.Position.X - 8, -Cursor.Position.Y + Size.Height - 8);
                    }
                    break;
                case "Add Arc":
                        if (selected_vertex1 == -1)
                        {
                            selected_vertex1 = this.SimpleOpenGlControl1.graph.VertexNumber(Cursor.Position.X - 8, -Cursor.Position.Y + Size.Height - 8);
                            if (selected_vertex1 != -1)
                                this.SimpleOpenGlControl1.graph.Select_Vertex(selected_vertex1);
                        }
                        else
                        {
                            int selected_vertex2 = this.SimpleOpenGlControl1.graph.VertexNumber(Cursor.Position.X - 8, -Cursor.Position.Y + Size.Height - 8);
                            if (selected_vertex2 == -1)
                            {
                                this.SimpleOpenGlControl1.graph.Unselect_Vertex(selected_vertex1);
                                selected_vertex1 = -1;
                            }
                            else
                            {
                                window.Info.Text = "Enter here";
                                window.Info.Visible = true;
                                window.Label1.Visible = true;
                                window.Submit.Visible = true;
                                window.Source.Visible = false;
                                window.Flow.Visible = false;
                                window.ShowDialog();
                                this.SimpleOpenGlControl1.graph.AddArc(selected_vertex1, selected_vertex2, Convert.ToInt32(window.Info.Text));
                                this.SimpleOpenGlControl1.graph.Unselect_Vertex(selected_vertex1);
                                selected_vertex1 = -1;
                            }
                        }
                    break;
                case "Add Edge":
                        if (selected_vertex1 == -1)
                        {
                            selected_vertex1 = this.SimpleOpenGlControl1.graph.VertexNumber(Cursor.Position.X - 8, -Cursor.Position.Y + Size.Height - 8);
                            if (selected_vertex1 != -1)
                                this.SimpleOpenGlControl1.graph.Select_Vertex(selected_vertex1);
                        }
                        else
                        {
                            int selected_vertex2 = this.SimpleOpenGlControl1.graph.VertexNumber(Cursor.Position.X - 8, -Cursor.Position.Y + Size.Height - 8);
                            if (selected_vertex2 == -1)
                            {
                                this.SimpleOpenGlControl1.graph.Unselect_Vertex(selected_vertex1);
                                selected_vertex1 = -1;
                            }
                            else
                            {
                                window.Source.Visible = false;
                                window.Flow.Visible = false;
                                window.Info.Text = "Enter here";
                                window.ShowDialog();
                                this.SimpleOpenGlControl1.graph.AddEdge(selected_vertex1, selected_vertex2, Convert.ToInt32(window.Info.Text));
                                this.SimpleOpenGlControl1.graph.Unselect_Vertex(selected_vertex1);
                                selected_vertex1 = -1;
                            }
                        }
                    break;
                case "Information":
                       {
                           label1.Visible = true;
                           if (selected_vertex1 == -1)
                           {
                               selected_vertex1 = this.SimpleOpenGlControl1.graph.VertexNumber(Cursor.Position.X - 8, -Cursor.Position.Y + Size.Height - 8);
                               SimpleOpenGlControl1.graph.Select_Vertex(selected_vertex1);
                               label1.Text = "Infomation:\n" + "Vertex from number:   "
                                       + selected_vertex1.ToString() + "\nChoose Vertex to";
                           }
                           else
                           {
                               int selected_vertex2 = this.SimpleOpenGlControl1.graph.VertexNumber(Cursor.Position.X - 8, -Cursor.Position.Y + Size.Height - 8);
                               SimpleOpenGlControl1.graph.Select_Vertex(selected_vertex2);
                               if (selected_vertex2 == -1) label1.Text = "Select vertex to";
                               else
                               {
                                   label1.Text = "Infomation:\n" + "Vertex from number:   "
                                       + selected_vertex1.ToString() + ";\n" + "Vertex to number:    "
                                       + selected_vertex2.ToString() + ";\n" + "Weight of edge:  ";
                                   if (this.SimpleOpenGlControl1.graph.EdgeWeight(selected_vertex1, selected_vertex2) != int.MinValue)
                                       label1.Text = label1.Text + this.SimpleOpenGlControl1.graph.EdgeWeight(selected_vertex1, selected_vertex2);
                                   else
                                       label1.Text = label1.Text + "--";
                                   SimpleOpenGlControl1.graph.Unselect_Vertex(selected_vertex1);
                                   SimpleOpenGlControl1.graph.Unselect_Vertex(selected_vertex2);
                                   selected_vertex1 = -1;
                                   selected_vertex2 = -1;
                               }
                           }
                       }
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected_vertex1 != -1)
            {
                this.SimpleOpenGlControl1.graph.Unselect_Vertex(selected_vertex1);
                selected_vertex1 = -1;
            }
            if (ChoosingAction.Text == "Add Vertex")
                label1.Visible = false;
            if (ChoosingAction.Text == "Add Edge")
            {
                label1.Visible = false;
                window.Label1.Visible = true;
                window.Label2.Visible = false;
                window.Submit.Visible = true;
                window.Info.Visible = true;
            }
            if (ChoosingAction.Text == "Add Arc")
            {
                label1.Visible = false;
                window.Label1.Visible = true;
                window.Label2.Visible = false;
                window.Submit.Visible = true;
                window.Info.Visible = true;
            }
            if (ChoosingAction.Text == "Information")
                label1.Visible = true;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            ChoosingAction.Text = "Choose Action";
        }

        private void Algorithms_Click(object sender, EventArgs e)
        {
            DFS.Visible = true;
            BFS.Visible = true;
            Kruskal.Visible = true;
            Dejkstra.Visible = true;
            BellmanFord.Visible = true;
            FlojdVorshell.Visible = true;
            Prim.Visible = true;
            Johnson.Visible = true;
            FordFalkerson.Visible = true;
            EdmondsKarp.Visible = true;
        }

        private void DFS_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            label1.Visible = false;
            Information.Visible = false;
            Queue<Edge> queue = SimpleOpenGlControl1.graph.DFS();
            while (queue.Count() != 0)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                this.SimpleOpenGlControl1.Invalidate();
                Edge edge = queue.Dequeue();
                SimpleOpenGlControl1.graph.Highlight_Vertex(edge.fromV);
                SimpleOpenGlControl1.graph.Highlight_Vertex(edge.toV);
                SimpleOpenGlControl1.graph.Result_Matrix[edge.fromV][edge.toV] = SimpleOpenGlControl1.graph.Matrix[edge.fromV][edge.toV];
            }
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void BFS_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            label1.Visible = false;
            Information.Visible = false;
            Queue<Edge> queue = SimpleOpenGlControl1.graph.BFS();
            while (queue.Count() != 0)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                this.SimpleOpenGlControl1.Invalidate();
                Edge edge = queue.Dequeue();
                SimpleOpenGlControl1.graph.Highlight_Vertex(edge.fromV);
                SimpleOpenGlControl1.graph.Highlight_Vertex(edge.toV);
                SimpleOpenGlControl1.graph.Result_Matrix[edge.fromV][edge.toV] = SimpleOpenGlControl1.graph.Matrix[edge.fromV][edge.toV];
            }
            label1.Visible = false;
            Information.Visible = false;
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void Kruskal_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            SimpleOpenGlControl1.graph.Kruskal();
            label1.Visible = false;
            Information.Visible = false;
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void Dejkstra_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            Information.Text = "Information\n";
            window.Label2.Visible = true;
            window.Label1.Visible = false;
            window.Submit.Visible = true;
            window.Info.Visible = true;
            Information.Visible = true;
            label1.Visible = false;
            window.Source.Visible = false;
            window.Flow.Visible = false;
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            List<int> distance = new List<int>(SimpleOpenGlControl1.graph.Dejkstra(Convert.ToInt32(window.Info.Text)));
            Information.Text += "\nShortest ways from vertex number " + window.Info.Text + " :\n";
            for (int i = 0; i < distance.Count(); ++i)
            {
                if (i != Convert.ToInt32(window.Info.Text))
                {
                    Information.Text += "(" + window.Info.Text + "," + Convert.ToString(i) + ")      ";
                    if (distance[i] != int.MaxValue)
                        Information.Text += Convert.ToString(distance[i]);
                    else
                        Information.Text += "--";
                    Information.Text += "\n";
                }
            }
            window.Info.Text = "Enter here";
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void BellmanFord_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            Information.Text = "Information\n";
            window.Info.Text = "Enter here";
            bool isNegativeCycle = false;
            window.Label2.Visible = true;
            window.Label1.Visible = false;
            window.Submit.Visible = true;
            window.Info.Visible = true;
            Information.Visible = true;
            label1.Visible = false;
            window.Source.Visible = false;
            window.Flow.Visible = false;
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            List<int> distance = new List<int>(SimpleOpenGlControl1.graph.BellmanFord(Convert.ToInt32(window.Info.Text), ref isNegativeCycle));
            if (!isNegativeCycle)
            {
                Information.Text += "\nShortest ways from vertex number " + window.Info.Text + " :\n";
                for (int i = 0; i < distance.Count(); ++i)
                {
                    if (i != Convert.ToInt32(window.Info.Text))
                    {
                        Information.Text += "(" + window.Info.Text + "," + Convert.ToString(i) + ")      ";
                        if (distance[i] != int.MaxValue)
                            Information.Text += Convert.ToString(distance[i]);
                        else
                            Information.Text += "--";
                        Information.Text += "\n";
                    }
                }
            }
            else
            {
                Information.Text = "There is Negative Cycle in graph : \n";
                for (int i = 0; i < distance.Count()-1; ++i)
                    Information.Text += "(" + Convert.ToString(distance[i]) + "," + Convert.ToString(distance[i+1]) + "),\n";
            }
            window.Info.Text = "Enter here";
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void FlojdVorshell_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            Information.Text = "Information\n";
            window.Label2.Visible = true;
            window.Label1.Visible = false;
            window.Submit.Visible = true;
            window.Info.Visible = true;
            Information.Visible = true;
            label1.Visible = false;
            window.Source.Visible = false;
            window.Flow.Visible = false;
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            List<int> distance = new List<int>(SimpleOpenGlControl1.graph.Flojd_Vorshell(Convert.ToInt32(window.Info.Text)));
            for (int i = 0; i < distance.Count(); ++i)
                if (distance[i]!=int.MaxValue) simpleOpenGlControl1.graph.Highlight_Vertex(i);
            Information.Text += "\nShortest ways from vertex number " + window.Info.Text + " :\n";
            for (int i = 0; i < distance.Count(); ++i)
            {
                if (i != Convert.ToInt32(window.Info.Text))
                {
                    Information.Text += "(" + window.Info.Text + "," + Convert.ToString(i) + ")      ";
                    if (distance[i] != int.MaxValue)
                        Information.Text += Convert.ToString(distance[i]);
                    else
                        Information.Text += "--";
                    Information.Text += "\n";
                }
            }
            window.Info.Text = "Enter here";
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void Prim_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            SimpleOpenGlControl1.graph.Prim();
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void Johnson_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            Information.Text = "Information\n";
            window.Label2.Visible = true;
            window.Label1.Visible = false;
            window.Submit.Visible = true;
            window.Info.Visible = true;
            Information.Visible = true;
            label1.Visible = false;
            window.Source.Visible = false;
            window.Flow.Visible = false;
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            List<int> distance = new List<int>(SimpleOpenGlControl1.graph.Johnson(Convert.ToInt32(window.Info.Text)));
            Information.Text += "\nShortest ways from vertex number " + window.Info.Text + " :\n";
            for (int i = 0; i < distance.Count(); ++i)
            {
                if (i != Convert.ToInt32(window.Info.Text))
                {
                    Information.Text += "(" + window.Info.Text + "," + Convert.ToString(i) + ")      ";
                    if (distance[i] != int.MaxValue)
                        Information.Text += Convert.ToString(distance[i]);
                    else
                        Information.Text += "--";
                    Information.Text += "\n";
                }
            }
            window.Info.Text = "Enter here";
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void FordFalkerson_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            Information.Text = "Information\n";
            window.Label2.Visible = false;
            window.Label1.Visible = false;
            window.Submit.Visible = true;
            window.Info.Visible = true;
            Information.Visible = true;
            label1.Visible = false;
            window.Source.Visible = true;
            window.Flow.Visible = false;
            int source=-1;
            int flow=-1;
            window.Info.Text = "Enter here";
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            else source = Convert.ToInt32(window.Info.Text);
            window.Info.Text = "Enter here";
            window.Source.Visible = false;
            window.Flow.Visible = true;
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            else flow = Convert.ToInt32(window.Info.Text);
            if (source == -1 || flow == -1) return;
            int maxFlow = SimpleOpenGlControl1.graph.FordFalkerson(source, flow);
            Information.Text = "Maximal Flow = " + Convert.ToString(maxFlow);

            window.Info.Text = "Enter here";
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void EdmondsKarp_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            Information.Text = "Information\n";
            window.Label2.Visible = false;
            window.Label1.Visible = false;
            window.Submit.Visible = true;
            window.Info.Visible = true;
            Information.Visible = true;
            label1.Visible = false;
            window.Source.Visible = true;
            window.Flow.Visible = false;
            int source = -1;
            int flow = -1;
            window.Info.Text = "Enter here";
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            else source = Convert.ToInt32(window.Info.Text);
            window.Info.Text = "Enter here";
            window.Source.Visible = false;
            window.Flow.Visible = true;
            window.ShowDialog();
            if (Convert.ToInt32(window.Info.Text) < 0 || Convert.ToInt32(window.Info.Text) > SimpleOpenGlControl1.graph.Points.Count())
                Information.Text = "You Enter wrong number of vertex";
            else flow = Convert.ToInt32(window.Info.Text);
            if (source == -1 || flow == -1) return;
            int maxFlow = SimpleOpenGlControl1.graph.EdmondsKarp(source, flow);
            Information.Text = "Maximal Flow = " + Convert.ToString(maxFlow);

            window.Info.Text = "Enter here";
            DFS.Visible = false;
            BFS.Visible = false;
            Kruskal.Visible = false;
            Dejkstra.Visible = false;
            BellmanFord.Visible = false;
            FlojdVorshell.Visible = false;
            Prim.Visible = false;
            Johnson.Visible = false;
            FordFalkerson.Visible = false;
            EdmondsKarp.Visible = false;
        }

        private void gen_not_oriented_Click(object sender, EventArgs e)
        {
            this.SimpleOpenGlControl1.graph.Delete();
            this.SimpleOpenGlControl1.graph.gen_not_oriented();
            window.Info.Text = "Enter here";
            Information.Text = "Information\n";
            label1.Visible = false;
            Information.Visible = false;
        }

        private void Graph_delete_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Delete();
            Information.Visible = false;
            label1.Visible = false;
        }

        private void Graph_clear_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.Clear();
            Information.Visible = false;
            label1.Visible = false;
        }

        private void makeGraph_Click(object sender, EventArgs e)
        {
            SimpleOpenGlControl1.graph.makeGraph();
        }
    }
}
