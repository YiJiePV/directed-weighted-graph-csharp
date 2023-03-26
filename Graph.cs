/// Graph
/// C# Implementation of a Directed Weighted graph data structure using an adjacency list
/// Author: Karena Qian
/// Last Edited: 3/17/2023

using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphImpl
{
    public class Graph
    {
        Dictionary<Vertex, List<Edge>> graph;

        /// Constructor
        /// Empty constructor initializes the graph to a new Dictionary
        /// Params: none
        /// Returns: none
        public Graph()
        {
            this.graph = new Dictionary<Vertex, List<Edge>>();
        }

        /// InsertVertex
        /// Inserts a new Vertex with a empty list of Edges in the graph (no duplicates)
        /// Params: v (Vertex to be added)
        /// Returns: true if Vertex v is successfully added, false otherwise
        public bool InsertVertex(Vertex v)
        {
            if(v == null)
            {
                return false;
            }
            foreach(Vertex n in this.graph.Keys)
            {
                if (n.Equals(v))
                {
                    return false;
                }
            }
            List<Edge> e = new List<Edge>();
            this.graph.Add(v, e);
            return true;
        }

        /// InsertEdge
        /// Adds a new outgoing Edge between 2 Vertices into graph (order-sensitive) OR changes weight if duplicate found
        /// Params:
        ///     v (1st Vertex for added Edge)
        ///     w (2nd Vertex for added Edge)
        /// Returns: true if Edge is successfully added/weight successfully changed, false otherwise
        public bool InsertEdge(Vertex v, Vertex w, int weight)
        {
            if(v == null || w == null || !this.graph.ContainsKey(v) || !this.graph.ContainsKey(w))
            {
                return false;
            }
            Edge e = new Edge(v, w, weight, false);
            Edge f = new Edge(w, v, weight, true);
            bool outGoing = false;
            bool inComing = false;
            //check for v----->w
            foreach(Edge n in this.graph[v])
            {
                if (n.EqualsNoWeight(e.GetVertex1(), e.GetVertex2(), e.GetStatus())) //checks for duplicate
                {
                    n.SetWeight(weight);
                    outGoing = true;
                }
            }
            //check for w<-----v
            foreach(Edge n in this.graph[w])
            {
                if (n.EqualsNoWeight(f.GetVertex1(), f.GetVertex2(), f.GetStatus())) //checks for duplicate
                {
                    n.SetWeight(weight);
                    inComing = true;
                }
            }
            if(outGoing && inComing)
            {
                return true;
            }
            else if (outGoing)
            {
                this.graph[w].Add(f);
                return true;
            }
            else if (inComing)
            {
                this.graph[v].Add(e);
                return true;
            }
            this.graph[v].Add(e);
            this.graph[w].Add(f);
            return true;
        }

        /// RemoveVertex
        /// Removes Vertex from graph:
        ///     - remove Edges connected to Vertex
        ///     - remove Vertex itself from graph
        /// Params: v (Vertex to be removed)
        /// Returns: true if Vertex is successively removed, false otherwise
        public bool RemoveVertex(Vertex v)
        {
            if (v == null || !this.graph.ContainsKey(v))
            {
                return false;
            }
            //Remove edges v---->? AND v<-----?
            int size = this.graph[v].Count();
            while (size > 0)
            {
                Vertex w = this.graph[v][size - 1].GetVertex2();
                bool isRemoved;
                if(this.graph[v][size - 1].GetStatus()) //if incoming edge
                {
                    isRemoved = this.RemoveEdge(w, v); //remove v<-----?
                }
                else
                {
                    isRemoved = this.RemoveEdge(v, w); //remove v------>?
                }
                if (!isRemoved)
                {
                    return false;
                }
                size = this.graph[v].Count();
            }
            //Remove vertex itself
            bool removeVertex = this.graph.Remove(v);
            if (!removeVertex)
            {
                return false;
            }
            return true;
        }

        /// RemoveEdge
        /// Removes outgoing Edge between v and w from graph (order-sensitive)
        /// Params:
        ///     v (1st Vertex of Edge to be removed)
        ///     w (2nd Vertex of Edge to be removed)
        /// Returns: true if Edge is successively removed, false otherwise
        public bool RemoveEdge(Vertex v, Vertex w)
        {
            if (v == null || w == null || !this.graph.ContainsKey(v) || !this.graph.ContainsKey(w))
            {
                return false;
            }
            int index = 0;
            bool outGoing = false;
            bool inComing = false;
            //remove v---->w
            foreach(Edge e in this.graph[v])
            {
                if(e.EqualsNoWeight(v, w, false))
                {
                    this.graph[v].RemoveAt(index);
                    outGoing = true;
                    break;
                }
                index++;
            }
            //remove w<----v
            index = 0;
            foreach(Edge e in this.graph[w])
            {
                if(e.EqualsNoWeight(w, v, true))
                {
                    this.graph[w].RemoveAt(index);
                    inComing = true;
                    break;
                }
                index++;
            }
            if(!outGoing || !inComing)
            {
                return false;
            }
            return true;
        }

        /// GetVertex
        /// Gives the deep copy of the vertex with value if found in graph
        /// Params: value (value of vertex to be found)
        /// Returns: vertex if found, null otherwise
        public Vertex GetVertex(string value)
        {
            foreach(Vertex v in this.graph.Keys)
            {
                if (v.GetValue().Equals(value))
                {
                    return v.Clone();
                }
            }
            return null;
        }

        /// GetEdge
        /// Gives the given outgoing directed edge (order-sensitive) if found in graph
        /// Params: 
        ///     start (starting Vertex of Edge)
        ///     end (ending Vertex of Edge)
        /// Returns: Edge (start, end) if found, null otherwise
        public Edge GetEdge(Vertex start, Vertex end)
        {
            if (!this.graph.ContainsKey(start) || !this.graph.ContainsKey(end))
            {
                return null;
            }
            foreach(Edge n in graph[start])
            {
                if (n.EqualsNoWeight(start, end, false))
                {
                    return n;
                }
            }
            return null;
        }

        /// GetAllVertices
        /// Gives a list of all Vertices in graph
        /// Params: none
        /// Returns: list of Vertices
        public List<Vertex> GetAllVertices()
        {
            List<Vertex> keys = new List<Vertex>();
            foreach(Vertex v in this.graph.Keys)
            {
                keys.Add(v);
            }
            return keys;
        }

        /// GetAllEdges
        /// Gives a list of all Edges in graph
        /// Params: none
        /// Returns: list of Edges
        public List<Edge> GetAllEdges()
        {
            List<Edge> values = new List<Edge>();
            foreach(List<Edge> l in this.graph.Values)
            {
                foreach(Edge e in l)
                {
                    values.Add(e);
                }
            }
            return values;
        }

        /// GetIncomingEdges
        /// Gives a list of all incoming Edges in graph
        /// Params: none
        /// Returns: list of incoming Edges
        public List<Edge> GetIncomingEdges()
        {
            List<Edge> values = new List<Edge>();
            foreach(List<Edge> l in this.graph.Values)
            {
                foreach(Edge e in l)
                {
                    if (e.GetStatus())
                    {
                        values.Add(e);
                    }
                }
            }
            return values;
        }

        /// GetOutgoingEdges
        /// Gives a list of all outgoing Edges in graph
        /// Params: none
        /// Returns: list of outgoing Edges
        public List<Edge> GetOutgoingEdges()
        {
            List<Edge> values = new List<Edge>();
            foreach (List<Edge> l in this.graph.Values)
            {
                foreach (Edge e in l)
                {
                    if (!e.GetStatus())
                    {
                        values.Add(e);
                    }
                }
            }
            return values;
        }

        /// GetNeighbors
        /// Gives a list of all neighboring Vertices of a Vertex
        /// Params: v (Vertex from which find neighbors)
        /// Returns: list of Vertices
        public List<Vertex> GetNeighbors(Vertex v)
        {
            if (!this.graph.ContainsKey(v))
            {
                return null;
            }
            List<Vertex> neighbors = new List<Vertex>();
            foreach(Edge e in this.graph[v])
            {
                if (!e.GetStatus())
                {
                    neighbors.Add(e.GetVertex2());
                }
            }
            return neighbors;
        }

        /// GetIncidentEdges
        /// Gives a list of all outgoing Edges incident to a Vertex
        /// Params: v (Vertex from which find incident Edges)
        /// Returns: list of outgoing Edges
        public List<Edge> GetIncidentOutgoingEdges(Vertex v)
        {
            if (!this.graph.ContainsKey(v))
            {
                return null;
            }
            List<Edge> incidents = new List<Edge>();
            foreach(Edge e in this.graph[v]) {
                if (!e.GetStatus())
                {
                    incidents.Add(e);
                }
            }
            return incidents;
        }

        /// GetIncidentEdges
        /// Gives a list of all incoming Edges incident to a Vertex
        /// Params: v (Vertex from which find incident Edges)
        /// Returns: list of incoming Edges
        public List<Edge> GetIncidentIncomingEdges(Vertex v)
        {
            if (!this.graph.ContainsKey(v))
            {
                return null;
            }
            List<Edge> incidents = new List<Edge>();
            foreach (Edge e in this.graph[v])
            {
                if (e.GetStatus())
                {
                    incidents.Add(e);
                }
            }
            return incidents;
        }

        /// FindVertex
        /// Checks if a Vertex is in graph
        /// Params: v (Vertex to check)
        /// Returns: true if Vertex is found, false otherwise
        public bool FindVertex(Vertex v)
        {
            return this.graph.ContainsKey(v);
        }

        /// FindEdge
        /// Checks if a directed outgoing Edge (2 Vertices) is in graph (order-sensitive)
        /// Params: 
        ///     v1 (1st vertex of edge)
        ///     v2 (2nd vertex of edge)
        /// Returns: true if Edge is found in graph, false otherwise
        public bool FindEdge(Vertex v1, Vertex v2)
        {
            if (!this.graph.ContainsKey(v1) || !this.graph.ContainsKey(v2))
            {
                return false;
            }
            foreach(Edge e in this.graph[v1])
            {
                if (e.EqualsNoWeight(v1, v2, false))
                {
                    return true;
                }
            }
            return false;
        }

        /// Size
        /// Gives the size of the graph
        /// Params: none
        /// Returns: size of graph
        public int Size()
        {
            return this.graph.Count();
        }

        /// BFS
        /// Does Breadth First Search on the graph starting from a given Vertex s and returns all visited Edges
        /// Params: s (starting Vertex)
        /// Returns: List of traversed Edges in order, or null if s is not found in graph
        public List<Edge> BFS(Vertex s)
        {
            if (!this.graph.ContainsKey(s))
            {
                return null;
            }
            List<Edge> ret = new List<Edge>();
            LinkedList<Vertex> visited = new LinkedList<Vertex>();
            Queue<Vertex> vertices = new Queue<Vertex>();
            vertices.Enqueue(s);
            visited.AddLast(s);
            while(vertices.Count() != 0)
            {
                Vertex curr = vertices.Dequeue();
                foreach(Edge e in graph[curr])
                {
                    if(!visited.Contains(e.GetVertex2()) && !e.GetStatus())
                    {
                        vertices.Enqueue(e.GetVertex2());
                        visited.AddLast(e.GetVertex2());
                        ret.Add(e);
                    }
                }
            }

            return ret;
        }

        /// DFS
        /// Does Depth First Search on the graph starting from a given Vertex s and returns all visited Edges
        /// Params: s (starting Vertex)
        /// Returns: List of traversed Edges in order, or null if s is not found in graph
        public List<Edge> DFS(Vertex s)
        {
            if (!this.graph.ContainsKey(s))
            {
                return null;
            }
            List<Edge> ret = new List<Edge>();
            List<Vertex> visited = new List<Vertex>();
            Stack<Vertex> vertices = new Stack<Vertex>();
            vertices.Push(s);
            visited.Add(s);
            Edge prev = new Edge(); //for checking edge duplicates
            while (vertices.Count() != 0)
            {
                //algorithm
                Vertex curr = vertices.Pop();
                foreach (Edge e in graph[curr])
                {
                    if (!visited.Contains(e.GetVertex2()) && !e.GetStatus())
                    {
                        vertices.Push(e.GetVertex2());
                        visited.Add(e.GetVertex2());
                    }
                }
                //creating output
                if(vertices.Count() != 0)
                {
                    Edge add = this.GetEdge(curr, vertices.Peek());
                    if(add != null && !add.Equals(prev)) //check for nonexistance and duplicates
                    {
                        ret.Add(add);
                        prev = add;
                    }
                    else if(add == null)
                    {
                        prev = new Edge();
                    }
                }
                else //checking for and inserting last edge
                {
                    Vertex latest = visited.ElementAt(0);
                    foreach(Edge e in graph[curr])
                    {
                        if(visited.IndexOf(e.GetVertex2()) > visited.IndexOf(latest))
                        {
                            latest = e.GetVertex2();
                        }
                    }
                    Edge add = this.GetEdge(latest, curr);
                    if ((add != null && prev != null) && !add.Equals(prev)){ //check for duplicate and null
                        ret.Add(add);
                    }
                    
                }
            }
            return ret;
        }

        /// Dijkstra
        /// Finds shortest paths from s to every other possible node u using Dijkstra's algorithm
        /// Returns list of Vertex-Vertex pairs, each pair containing Vertex and its best previous one Vertex
        /// Params: s (starting vertex)
        /// Returns: dictionary of Vertex-Vertex pairs (Each visited Vertex paired with the best previous Vertex), or null if s is not found in graph
        public Dictionary<Vertex, Vertex> Dijkstra(Vertex s)
        {
            if (!this.graph.ContainsKey(s))
            {
                return null;
            }
            //Priority Queue stores all vertices of graph
            //sorts by shortest dist from s to Vertex u
            PriorityQueue<VertexIntPair> pq = new PriorityQueue<VertexIntPair>();
            //Unsorted list that store dist of all vertices of graph
            Dictionary<Vertex, int> d = new Dictionary<Vertex, int>();
            //stores edges that build paths for each vertex
            Dictionary<Vertex, Vertex> ret = new Dictionary<Vertex, Vertex>();
            
            //initialize with s
            d.Add(s, 0);
            pq.Enqueue(new VertexIntPair(s, 0));

            //initialize rest of d
            foreach(Vertex v in graph.Keys)
            {
                if (!v.Equals(s))
                {
                    d.Add(v, -1); //-1 == INF, not compatible with negative weights
                }
            }

            while(pq.Count() > 0){
                //get vertex u from priority queue
                VertexIntPair min = pq.Dequeue();
                Vertex u = min.GetVertex();
                //check each Vertex v adjacent to Vertex u
                foreach(Edge e in this.graph[min.GetVertex()]){
                    if (!e.GetStatus())
                    {
                        Vertex v = e.GetVertex2();
                        //new dist = d[u] + weight of (u, v)
                        int newDist = d[u] + e.GetWeight();
                        //if dist is < than d[v]
                        if(newDist < d[v] || d[v] == -1)
                        {
                            //d[v] = dist
                            d[v] = newDist;
                            pq.Enqueue(new VertexIntPair(v, newDist));
                            if (!ret.ContainsKey(v))
                            {
                                ret.Add(v, u);
                            }
                            else
                            {
                                ret[v] = u;
                            }
                        }
                    }
                }
            }

            return ret;
        }

        /// FindPath
        /// Finds the shortest path from Vertex u to Vertex v
        /// using an altered version of Dijkstra's algo
        /// Params:
        ///     u (starting Vertex)
        ///     v (ending Vertex)
        /// Returns: list of edges (gives path u-v)
        public List<Vertex> FindPath(Vertex u, Vertex v)
        {
            if (!this.graph.ContainsKey(u) || !this.graph.ContainsKey(v))
            {
                return null;
            }
            List<Vertex> ret = new List<Vertex>();
            Dictionary<Vertex, Vertex> dijk = this.Dijkstra(u);
            //initializing
            ret.Add(v);
            bool found = false;
            Vertex curr = v;
            //extract path, if one exists
            while ((!found || dijk.Count() > 0) && dijk.ContainsKey(curr))
            {
                Vertex w = dijk[curr];
                dijk.Remove(curr);
                if (w.Equals(u))
                {
                    found = true;
                }
                ret.Insert(0, w);
                curr = w;
            }
            if (!found)
            {
                return null;
            }
            return ret;
        }

        /// Clear
        /// Empties the entire graph
        /// Params: none
        /// Returns: none
        public void Clear()
        {
            this.graph.Clear();
        }

        /// Print
        /// Outputs the graph in the console as a list of vertices, each with their edges
        /// Params: none
        /// Returns: none
        public void Print()
        {
            Console.WriteLine("Graph with size " + this.graph.Count() + ":");
            foreach(KeyValuePair<Vertex, List<Edge>> p in this.graph)
            {
                //Vertex
                p.Key.Print();
                Console.WriteLine(":");
                //Edges
                for (int i = 0; i < p.Value.Count(); i++)
                {
                    p.Value[i].Print();
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

    }
    
}
