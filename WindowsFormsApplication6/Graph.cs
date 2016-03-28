using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

namespace WFA6
{
    public class Point
    {
        public static float radius = 10f;
        private double x;
        private double y;
        private int number;
        private bool selected;
        private bool highlighted;
//------------------------------------------------------------------------------------
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }
        public bool Highlighted
        {
            get
            {
                return highlighted;
            }
            set
            {
                highlighted = value;
            }
        }
        public Point() { }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            number = p.number;
            //selected = p.selected;
        }
        public Point(double _x, double _y, int _number)
        {
            x = _x;
            y = _y;
            number = _number;
            //selected = false;
        }
        public double X
        {
            get
            {
                return x;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
        }
        public static float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public bool overlap(double xCoordinate, double yCoordinate)
        {
            return (xCoordinate < x + radius + radius) && (yCoordinate < y + radius + radius)
                && (xCoordinate > x - radius - radius) && (yCoordinate > y - radius - radius);
        }
        public void Draw()
        {
            GL.Color3(Color.Gold);
            if (selected == true) GL.Color3(Color.OrangeRed);
            if (highlighted == true) GL.Color3(Color.DarkGreen);
            GL.Begin(BeginMode.TriangleFan);
            GL.Vertex2(x, y);
            for (double i = 0d; i < 6.3d; i += 0.05)
                GL.Vertex2(Math.Cos(i) * radius + x, Math.Sin(i) * radius + y);
            GL.End();
        }
        public bool InPoint(double xCoord, double yCoord)
        {
            return (xCoord < x + radius) && (yCoord < y + radius)
                && (xCoord > x - radius) && (yCoord > y - radius);
        }
    }
//===================================================================================
    public class Edge
    {
        public int fromV;
        public int toV;
        public int weight;
        public Edge() { }
        public Edge(Edge e)
        {
            fromV = e.fromV;
            toV = e.toV;
            weight = e.weight;
        }
        public Edge(int fromVertex, int toVertex, int Weight)
        {
            fromV = fromVertex;
            toV = toVertex;
            weight = Weight;
        }
    }
//===================================================================================
    public class Graph
    {
        private List<Point> points;

        private List<List<int>> matrix;

        private List<List<int>> result_matrix;

        private double max_w;

        private double max_h;
//-----------------------------------------------------------------------------------
        public double Max_W
        {
            get
            {
                return max_w;
            }
            set
            {
                max_w = value;
            }
        }

        public double Max_H
        {
            get
            {
                return max_h;
            }
            set
            {
                max_h = value;
            }
        }

        public List<List<int>> Result_Matrix
        {
            get
            {
                return result_matrix;
            }
            set
            {
                result_matrix = value;
            }
        }

        public List<List<int>> Matrix
        {
            get
            {
                return matrix;
            }
        }

        public List<Point> Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        public Graph()
        {
            points = new List<Point>();
            matrix = new List<List<int>>();
            result_matrix = new List<List<int>>();
        }

        public Graph(Graph G)
        {
            points = new List<Point>(G.points);
            matrix = new List<List<int>>(G.matrix);
            result_matrix = new List<List<int>>(G.result_matrix);
        }

        public void makeGraph()
        {
            double x = 0;
            double y = 0;
            x = 100;
            y = Max_H / 2;
            AddVertex(x, y);
            x = 400;
            y = Max_H - 100;
            AddVertex(x, y);
            y = Max_H / 2;
            AddVertex(x, y);
            y = 100;
            AddVertex(x, y);
            x = 700;
            y = Max_H - 100;
            AddVertex(x, y);
            y = Max_H / 2;
            AddVertex(x, y);
            y = 100;
            AddVertex(x, y);
            x = 1000;
            y = Max_H / 2;
            AddVertex(x, y);
            AddEdge(0, 1, 3);
            AddEdge(0, 2, 4);
            AddEdge(0, 3, 5);
            AddEdge(1, 4, 2);
            AddEdge(1, 5, 1);
            AddEdge(1, 6, 1);
            AddEdge(2, 5, 2);
            AddEdge(2, 6, 2);
            AddEdge(3, 4, 2);
            AddEdge(3, 5, 3);
            AddEdge(4, 7, 6);
            AddEdge(5, 7, 2);
            AddEdge(6, 7, 5);
        }

        public void AddVertex(double xCoord, double yCoord)
        {
            if (xCoord < max_w - Point.radius && yCoord < max_h - 10)
            {
                Point p = new Point(xCoord, yCoord, points.Count());
                for (int i = 0; i < points.Count(); ++i)
                    if (points[i].overlap(xCoord, yCoord)) return;
                points.Add(p);
                for (int i = 0; i < matrix.Count(); ++i)
                {
                    matrix[i].Add(int.MaxValue);
                    result_matrix[i].Add(int.MaxValue);
                }
                List<int> row1 = new List<int>();
                List<int> row2 = new List<int>();
                for (int i = 0; i < matrix.Count(); ++i)
                {
                    row1.Add(int.MaxValue);
                    row2.Add(int.MaxValue);
                }
                row1.Add(0);
                row2.Add(0);
                matrix.Add(row1);
                result_matrix.Add(row2);
            }
            else return;
        }

        public void AddArc(int from, int to, int value)
        {
            if (from < matrix.Count() && to < matrix.Count() && from != to)
                matrix[from][to] = value;
        }

        public void AddEdge(int vertex1, int vertex2, int value)
        {
            if (vertex1 < matrix.Count() && vertex2 < matrix.Count() && vertex1 != vertex2)
            {
                matrix[vertex1][vertex2] = value;
                matrix[vertex2][vertex1] = value;
            }
        }

        public void gen_rand()
        {
            System.Random rand = new System.Random();
            int points_number = rand.Next(1, 8);
            int edges_number = rand.Next(15);
            for (int i = 0; i < points_number; ++i)
                AddVertex(rand.Next(Convert.ToInt32(Point.radius), Convert.ToInt32(max_w)), rand.Next(Convert.ToInt32(Point.radius), Convert.ToInt32(max_h)));
            for (int i = 0; i < edges_number; ++i)
                AddArc(rand.Next(0, points_number - 1), rand.Next(0, points_number - 1), rand.Next(0, 100));
        }

        public void Draw()
        {
            GL.LineWidth(3f);
            for (int i = 0; i < matrix.Count(); ++i)
                for (int j = 0; j < matrix.Count(); ++j)
                    if (matrix[i][j] != int.MaxValue && i != j)
                        if (matrix[i][j] == matrix[j][i])
                        {
                            GL.Begin(BeginMode.Lines);
                            GL.Color3(Color.Blue);
                            GL.Vertex2(points[i].X, points[i].Y);
                            GL.Vertex2(points[j].X, points[j].Y);
                            GL.End();
                        }
                        else
                        {
                            GL.Begin(BeginMode.Lines);
                            GL.Color3(Color.Blue);
                            GL.Vertex2(points[i].X, points[i].Y);
                            GL.Vertex2(points[j].X, points[j].Y);
                            GL.End();
                            //draw arrow
                            double l = Math.Sqrt((points[j].X - points[i].X) * (points[j].X - points[i].X) +
                                (points[j].Y - points[i].Y) * (points[j].Y - points[i].Y));
                            l = l / Point.Radius;
                            double x, y;
                            x = (l * points[j].X + points[i].X) / (l + 1);
                            y = (l * points[j].Y + points[i].Y) / (l + 1);
                            double x1 = (x - points[j].X) - (y - points[j].Y), y1 = (y - points[j].Y) + (x - points[j].X),
                                x2 = (x - points[j].X) + (y - points[j].Y), y2 = (y - points[j].Y) - (x - points[j].X);
                            GL.Begin(BeginMode.Triangles);
                            GL.Vertex2(x, y);
                            GL.Vertex2(x + 1 * x1, y + 1 * y1);
                            GL.Vertex2(x + 1 * x2, y + 1 * y2);
                            GL.End();
                        }
            GL.LineWidth(5f);
            GL.Color3(Color.Red);
            GL.Begin(BeginMode.Lines);
            for (int i = 0; i < result_matrix.Count(); ++i)
                for (int j = 0; j < result_matrix.Count(); ++j)
                    if (result_matrix[i][j] != int.MaxValue && result_matrix[i][j] >0 && i != j)
                        if (result_matrix[i][j] == result_matrix[j][i])
                        {
                            GL.Begin(BeginMode.Lines);
                            GL.Color3(Color.Chocolate);
                            GL.Vertex2(points[i].X, points[i].Y);
                            GL.Vertex2(points[j].X, points[j].Y);
                            GL.End();
                        }
                        else
                        {
                            GL.Begin(BeginMode.Lines);
                            GL.Color3(Color.Chocolate);
                            GL.Vertex2(points[i].X, points[i].Y);
                            GL.Vertex2(points[j].X, points[j].Y);
                            GL.End();
                            //draw arrow
                            double l = Math.Sqrt((points[j].X - points[i].X) * (points[j].X - points[i].X) +
                                (points[j].Y - points[i].Y) * (points[j].Y - points[i].Y));
                            l = l / Point.Radius;
                            double x, y;
                            x = (l * points[j].X + points[i].X) / (l + 1);
                            y = (l * points[j].Y + points[i].Y) / (l + 1);
                            double x1 = (x - points[j].X) - (y - points[j].Y), y1 = (y - points[j].Y) + (x - points[j].X),
                                x2 = (x - points[j].X) + (y - points[j].Y), y2 = (y - points[j].Y) - (x - points[j].X);
                            GL.Begin(BeginMode.Triangles);
                            GL.Vertex2(x, y);
                            GL.Vertex2(x + 1 * x1, y + 1 * y1);
                            GL.Vertex2(x + 1 * x2, y + 1 * y2);
                            GL.End();
                        }
            GL.End();
            for (int i = 0; i < points.Count(); ++i)
                points[i].Draw();
        }

        public void Select_Vertex(int number_of_vertex)
        {
            if (number_of_vertex < 0 || number_of_vertex >= points.Count()) return;
            points[number_of_vertex].Selected = true;
        }

        public void Highlight_Vertex(int number_of_vertex)
        {
            if (number_of_vertex < 0 || number_of_vertex >= points.Count()) return;
            points[number_of_vertex].Highlighted = true;
        }

        public void Unhighlight_Vertex(int number_of_vertex)
        {
            if (number_of_vertex < 0 || number_of_vertex >= points.Count()) return;
            points[number_of_vertex].Highlighted = false;
        }

        public void Unselect_Vertex(int number_of_vertex)
        {
            if (number_of_vertex < 0 || number_of_vertex >= points.Count()) return;
            points[number_of_vertex].Selected = false;
        }

        public int VertexNumber(double xCoord, double yCoord)
        {
            for (int i = 0; i < points.Count(); ++i)
                if (points[i].InPoint(xCoord, yCoord)) return i;
            return -1;
        }

        public int EdgeWeight(int fromVertex, int toVertex)
        {
            if (matrix[fromVertex][toVertex] != int.MaxValue) return matrix[fromVertex][toVertex];
            else return int.MinValue;
        }

        public void Delete()
        {
            points.Clear();
            matrix.Clear();
            result_matrix.Clear();
        }

        public void Clear()
        {
            for (int i = 0; i < result_matrix.Count(); ++i)
                for (int j = 0; j < result_matrix.Count(); ++j)
                    result_matrix[i][j] = int.MaxValue;
            for (int i = 0; i < points.Count(); ++i)
                points[i].Highlighted = false;
        }

        public Queue<Edge> DFS()
        {
            Queue<Edge> queue = new Queue<Edge>();
            Stack<int> stack_of_vertexes = new Stack<int>();
            List<int> parents = new List<int>();
            for (int i = 0; i < points.Count(); ++i)
                parents.Add(-1);
            List<bool> visited = new List<bool>(points.Count());
            for (int i = 0; i < points.Count(); ++i)
                visited.Add(false);
            stack_of_vertexes.Push(0);
            int vertex = 0;
            while (stack_of_vertexes.Count() != 0 && visited.Contains(false))
            {
                vertex = stack_of_vertexes.Pop();
                visited[vertex] = true;
                if (parents[vertex]!=-1) queue.Enqueue(new Edge(parents[vertex], vertex, matrix[parents[vertex]][vertex]));
                int i=0;
                for (; i < matrix.Count(); ++i)
                {
                    if (matrix[vertex][i] != int.MaxValue && vertex != i && !visited[i])
                    {
                        stack_of_vertexes.Push(i);
                        parents[i] = vertex;
                    }
                }
            }
            return queue;
        }

        public Queue<Edge> BFS()
        {
            Queue<Edge> queue = new Queue<Edge>();
            Queue<int> list = new Queue<int>();
            List<bool> visited = new List<bool>(points.Count());
            for (int i = 0; i < points.Count(); ++i)
                visited.Add(false);
            list.Enqueue(0);
            int vertex = 0;
            while (list.Count() != 0)
            {
                vertex = list.Dequeue();
                visited[vertex] = true;
                for (int i = 0; i < matrix.Count(); ++i)
                {
                    if (matrix[vertex][i] != int.MaxValue && vertex != i && !visited[i])
                    {
                        list.Enqueue(i);
                        queue.Enqueue(new Edge(vertex, i, matrix[vertex][i]));
                        visited[i] = true;
                    }
                }
            }
            return queue;
        }

        public List<int> BFS(int fromV)
        {
            List<int> list = new List<int>();
            Queue<int> queue = new Queue<int>();
            List<bool> visited = new List<bool>(points.Count());
            for (int i = 0; i < points.Count(); ++i)
                visited.Add(false);
            queue.Enqueue(fromV);
            int vertex = 0;
            while (queue.Count() != 0 || visited.Contains(false))
            {
                vertex = queue.Dequeue();
                if (!visited[vertex]) list.Add(vertex);
                visited[vertex] = true;
                for (int i = 0; i < matrix.Count(); ++i)
                {
                    if (matrix[vertex][i] != int.MaxValue && vertex != i && !visited[i])
                        queue.Enqueue(i);
                }
            }
            return list;
        }

        public void Kruskal()
        {
            List<Edge> E = new List<Edge>();
            for (int i = 0; i < matrix.Count(); ++i)
            {
                for (int j = 0; j < matrix.Count(); ++j)
                {
                    if (i != j && matrix[i][j] != int.MaxValue)
                    {
                        Edge e = new Edge(i, j, Matrix[i][j]);
                        if (E.Count() == 0) E.Add(e);
                        else
                        {
                            int k = 0;
                            for (; k < E.Count(); ++k)
                                if (e.weight < E[k].weight)
                                {
                                    E.Insert(k, e);
                                    break;
                                }
                            if (k == E.Count()) E.Add(e);
                        }
                    }
                }
            }
            List<List<int>> V = new List<List<int>>();
            for (int i = 0; i < points.Count(); ++i)
            {
                List<int> P = new List<int>();
                P.Add(points[i].Number);
                V.Add(P);
            }
            Queue<Edge> queue = new Queue<Edge>();
            for (int i = 0; i < E.Count(); ++i)
            {
                Edge edge = new Edge(E[i]);
                queue.Enqueue(edge);
            }
            while (V.Count() > 1 && queue.Count() != 0)
            {
                Edge next = new Edge(queue.Dequeue());
                for (int i = 0; i < V.Count(); ++i)
                {
                    if ((V[i].Contains(next.fromV) && !V[i].Contains(next.toV)) ||
                        (!V[i].Contains(next.fromV) && V[i].Contains(next.toV)))
                    {
                        for (int j = 0; j < V.Count(); ++j)
                        {
                            if (i!=j && ((V[j].Contains(next.fromV) && !V[j].Contains(next.toV)) ||
                                (!V[j].Contains(next.fromV) && V[j].Contains(next.toV))))
                            {
                                V[i].AddRange(V[j]);
                                V.RemoveAt(j);
                                result_matrix[next.fromV][next.toV] = next.weight;
                                result_matrix[next.toV][next.fromV] = next.weight;
                            }
                        }
                    }
                }
            }
        }

        public void Prim()
        {
            List<int> visited_vertexes = new List<int>();
            List<bool> used = new List<bool>();
            for (int i = 0; i < points.Count(); ++i)
                used.Add(false);
            visited_vertexes.Add(0);
            int min_weight = int.MaxValue;
            do
            {
                int from = -1;
                int to = -1;
                int next = -1;
                min_weight = int.MaxValue;
                for (int i = 0; i < visited_vertexes.Count(); ++i)
                {
                    for (int j = 0; j < matrix.Count(); ++j)
                    {
                        if (visited_vertexes[i] != j && matrix[visited_vertexes[i]][j] < min_weight && !used[j])
                        {
                            from = visited_vertexes[i];
                            to = j;
                            next = j;
                            min_weight = matrix[visited_vertexes[i]][j];
                        }
                        if (visited_vertexes[i] != j && matrix[j][visited_vertexes[i]] < min_weight && !used[j])
                        {
                            to = visited_vertexes[i];
                            from = j;
                            next = j;
                            min_weight = matrix[j][visited_vertexes[i]];
                        }
                    }
                }
                if (min_weight != int.MaxValue)
                {
                    result_matrix[from][to] = min_weight;
                    result_matrix[to][from] = min_weight;
                    used[next] = true;
                    visited_vertexes.Add(next);
                }
            }
            while (min_weight != int.MaxValue);
        }

        public List<int> BellmanFord(int fromVertex, ref bool isNegativeCycle)
        {
            List<Edge> E = new List<Edge>();
            for (int i = 0; i < matrix.Count(); ++i)
                for (int j = 0; j < matrix.Count(); ++j)
                    if (matrix[i][j] != int.MaxValue && i != j)
                    {
                        Edge e = new Edge(i, j, Matrix[i][j]);
                        E.Add(e);
                    }

            List<int> distance = new List<int>();
            if (fromVertex < 0 || fromVertex > points.Count()) return distance;
            for (int i = 0; i < matrix.Count(); ++i)
                distance.Add(int.MaxValue);
            distance[fromVertex] = 0;
            List<int> parents = new List<int>(matrix.Count());
            for (int i = 0; i < matrix.Count(); ++i)
                parents.Add(-1);
            int x = -1;

            for (int i = 0; i < matrix.Count(); ++i)
            {
                x = -1;
                for (int j = 0; j < E.Count(); ++j)
                {
                    if (distance[E[j].fromV] < int.MaxValue)
                        if (distance[E[j].toV] > distance[E[j].fromV] + E[j].weight)
                        {
                            //треба запобігти переповненню у випадку від'ємного циклу
                            if (distance[E[j].fromV] > -100000000)
                                distance[E[j].toV] = distance[E[j].fromV] + E[j].weight;
                            else distance[E[j].toV] = int.MinValue;
                            parents[E[j].toV] = E[j].fromV;
                            x = E[j].toV;
                        }
                }
            }

            for (int i = 1; i < parents.Count(); ++i)
                if (parents[i] != -1) result_matrix[parents[i]][i] = matrix[parents[i]][i];

            if (x == -1) return distance;
            else
            {
                int y = x;
                for (int i = 0; i < matrix.Count(); ++i)
                    y = parents[y];
                List<int> way = new List<int>();
                for (int cur = y; ; cur = parents[cur])
                {
                    way.Add(cur);
                    if (cur == y && way.Count() > 1) break;
                }
                way.Reverse(0, way.Count());
                isNegativeCycle = true;
                for (int i = 0; i < way.Count() - 1; ++i)
                    result_matrix[way[i]][way[i + 1]] = matrix[way[i]][way[i + 1]];
                return way;
            }
        }

        public List<int> Dejkstra(int fromVertex)
        {
            int N = points.Count();
            if (fromVertex < 0 || fromVertex > N || N == 0) return new List<int>();
            List<int> distance = new List<int>();
            for (int i = 0; i < N; ++i)
                distance.Add(int.MaxValue);
            distance[fromVertex] = 0;
            List<bool> visited = new List<bool>();
            List<int> parents = new List<int>(matrix.Count());
            for (int i = 0; i < matrix.Count(); ++i)
                parents.Add(-1);
            for (int i = 0; i < N; ++i)
                visited.Add(false);
            int prevVertex = fromVertex;
            int nextVertex = fromVertex;
            while (visited.Contains(false))
            {
                int min_distance = int.MaxValue;
                for (int i = 0; i < N; ++i)
                    if (!visited[i] && min_distance > distance[i])
                    {
                        nextVertex = i;
                        min_distance = distance[i];
                    }
                if (min_distance == int.MaxValue) break;
                visited[nextVertex] = true;
                for (int j = 0; j < N; ++j)
                    if (!visited[j] && matrix[nextVertex][j] != int.MaxValue)
                        if (distance[j] > distance[nextVertex] + matrix[nextVertex][j])
                        {
                            distance[j] = distance[nextVertex] + matrix[nextVertex][j];
                            parents[j] = nextVertex;
                        }
            }
            for (int i = 1; i < parents.Count(); ++i)
                if (parents[i] != -1) result_matrix[parents[i]][i] = matrix[parents[i]][i];
            return distance;
        }

        public List<int> Flojd_Vorshell(int fromVertex)
        {
            int N = points.Count();
            if (fromVertex < 0 || fromVertex > N || N == 0) return new List<int>();
            List<List<int>> distance_matrix = new List<List<int>>();
            for (int i = 0; i < N; ++i)
                distance_matrix.Add(new List<int>(matrix[i]));
            for (int k = 0; k < N; ++k)
                for (int i = 0; i < N; ++i)
                    for (int j = 0; j < N; ++j)
                        if (distance_matrix[i][k] != int.MaxValue && distance_matrix[k][j] != int.MaxValue)
                            distance_matrix[i][j] = System.Math.Min(distance_matrix[i][j], distance_matrix[i][k] + distance_matrix[k][j]);
            return distance_matrix[fromVertex];
        }

        public List<int> Johnson(int fromVertex)
        {
            int N = points.Count();
            if (fromVertex < 0 || fromVertex > N || N == 0) return new List<int>();
            List<Point> temp = new List<Point>(points);
            List<List<int>> oldMatrix = new List<List<int>>();
            for (int i = 0; i < N; ++i)
                oldMatrix.Add(new List<int>(matrix[i]));
            Point p = new Point(-1, -1, temp.Count());
            points.Add(p);
            matrix.Add(new List<int>());
            result_matrix.Add(new List<int>());
            for (int i = 0; i < matrix.Count(); ++i)
            {
                matrix[i].Add(0);
                result_matrix[i].Add(0);
                matrix[N].Add(0);
                result_matrix[N].Add(0);
            }
            matrix[N].Add(0);
            result_matrix[N].Add(0);

            bool isNegativeCycle=false;
            List<int> h = BellmanFord(N, ref isNegativeCycle);
            if (h.Count() == 0 || isNegativeCycle) return h;
            for (int i = 0; i <= N; ++i)
                for (int j = 0; j <= N; ++j)
                    matrix[i][j] = matrix[i][j] + h[i] - h[j];
            points.Remove(p);
            matrix.RemoveAt(N);
            result_matrix.RemoveAt(N);
            for (int i = 0; i < N; ++i)
            {
                matrix[i].RemoveAt(N);
                result_matrix[i].RemoveAt(N);
            }
            List<int> result = Dejkstra(fromVertex);
            matrix = oldMatrix;
            return result;
        }

        public void gen_not_oriented()
        {
            System.Random rand = new System.Random();
            int points_number = rand.Next(1, 8);
            int edges_number = rand.Next(15);
            for (int i = 0; i < points_number; ++i)
                AddVertex(rand.Next(Convert.ToInt32(Point.radius), Convert.ToInt32(max_w)), rand.Next(Convert.ToInt32(Point.radius), Convert.ToInt32(max_h)));
            for (int i = 0; i < edges_number; ++i)
            {
                int num1 = rand.Next(0, points_number - 1);
                int num2 = rand.Next(0, points_number - 1);
                int weight = rand.Next(0, 100);
                AddArc(num1, num2, weight);
                AddArc(num2, num1, weight);
            }
        }

        private List<int> ShortestWay(List<List<int>> matr, int from, int to)
        {
            int N = matr.Count();
            if (N == 0 || from < 0 || from > N || to < 0 || to > N) return new List<int>();
            Queue<int> bfs = new Queue<int>();
            List<bool> visited = new List<bool>();
            List<int> parents = new List<int>();
            for (int i = 0; i < N; ++i)
            {
                visited.Add(false);
                parents.Add(-1);
            }
            visited[from] = true;
            bfs.Enqueue(from);
            while (bfs.Count() != 0)
            {
                int vertex = bfs.Dequeue();
                for (int i = 0; i < matrix.Count(); ++i)
                {
                    if (matr[vertex][i] != int.MaxValue && i != vertex && !visited[i])
                    {
                        visited[i] = true;
                        parents[i] = vertex;
                        bfs.Enqueue(i);
                        if (i == to) break;
                    }
                }
                if (bfs.Contains(to)) break;
            }
            List<int> way = new List<int>();
            if (bfs.Count() == 0) return way;
            int next = to;
            while (next != -1)
            {
                way.Add(next);
                next = parents[next];
            }
            way.Reverse();
            return way;
        }

        public int FordFalkerson(int source, int flow)
        {
            int N = points.Count();
            if (N == 0 || source < 0 || source > N || flow < 0 || flow > N) return -1;
            result_matrix.Clear();
            for (int i = 0; i < N; ++i)
            {
                result_matrix.Add(new List<int>());
                for (int j = 0; j < N; ++j)
                    result_matrix[i].Add(0);
            }

            List<List<int>> auxiliaryMatrix = new List<List<int>>();//інший допоміжний граф
            for (int i = 0; i < N; ++i)
            {
                auxiliaryMatrix.Add(new List<int>());
                for (int j = 0; j < N; ++j)
                    auxiliaryMatrix[i].Add(matrix[i][j]);
            }

            int maxFlow = 0;
            List<int> way = ShortestWay(auxiliaryMatrix, source, flow);
            while (way.Count() > 1)
            {
                int Cmin = auxiliaryMatrix[way[0]][way[1]];
                for (int i = 2; i < way.Count(); ++i)
                    if (Cmin > auxiliaryMatrix[way[i - 1]][way[i]])
                        Cmin = auxiliaryMatrix[way[i - 1]][way[i]];
                maxFlow += Cmin;
                for (int i = 1; i < way.Count(); ++i)
                {
                    auxiliaryMatrix[way[i - 1]][way[i]] -= Cmin;
                    auxiliaryMatrix[way[i]][way[i - 1]] += Cmin;
                    result_matrix[way[i - 1]][way[i]] += Cmin;
                    result_matrix[way[i]][way[i - 1]] -= Cmin;
                    if (auxiliaryMatrix[way[i - 1]][way[i]] <= 0)
                        auxiliaryMatrix[way[i - 1]][way[i]] = int.MaxValue;
                }
                way = ShortestWay(auxiliaryMatrix, source, flow);
            }
            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                    if (i != j && result_matrix[i][j] == 0)
                        result_matrix[i][j] = int.MaxValue;
            return maxFlow;
        }

        public int EdmondsKarp(int source, int flow)
        {
            int N = points.Count();
            if (N == 0 || source < 0 || source > N || flow < 0 || flow > N) return -1;
            result_matrix.Clear();
            for (int i = 0; i < N; ++i)
            {
                result_matrix.Add(new List<int>());
                for (int j = 0; j < N; ++j)
                    result_matrix[i].Add(0);
            }

            List<List<int>> auxiliaryMatrix = new List<List<int>>();//інший допоміжний граф
            for (int i = 0; i < N; ++i)
            {
                auxiliaryMatrix.Add(new List<int>());
                for (int j = 0; j < N; ++j)
                    auxiliaryMatrix[i].Add(matrix[i][j]);
            }

            int maxFlow = 0;
            List<int> way = ShortestWay(auxiliaryMatrix, source, flow);
            while (way.Count() > 1)
            {
                int Cmin = auxiliaryMatrix[way[0]][way[1]];
                for (int i = 2; i < way.Count(); ++i)
                    if (Cmin > auxiliaryMatrix[way[i - 1]][way[i]])
                        Cmin = auxiliaryMatrix[way[i - 1]][way[i]];
                maxFlow += Cmin;
                for (int i = 1; i < way.Count(); ++i)
                {
                    auxiliaryMatrix[way[i - 1]][way[i]] -= Cmin;
                    auxiliaryMatrix[way[i]][way[i - 1]] += Cmin;
                    result_matrix[way[i - 1]][way[i]] += Cmin;
                    result_matrix[way[i]][way[i - 1]] -= Cmin;
                    if (auxiliaryMatrix[way[i - 1]][way[i]] <= 0)
                        auxiliaryMatrix[way[i - 1]][way[i]] = int.MaxValue;
                }
                way = ShortestWay(auxiliaryMatrix, source, flow);
            }
            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                    if (i != j && result_matrix[i][j] == 0)
                        result_matrix[i][j] = int.MaxValue;
            return maxFlow;
        }
    }
}
