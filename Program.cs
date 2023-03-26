/// Program
/// Client Menu Program displaying all the features of the graph class
/// Author: Karena Qian
/// Last Edited: 3/17/2023

using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphImpl
{
    class Program
    {
        static void Main(string[] args)
        {
            //Graph Menu
            bool isQuit = false;
            Graph g = null;
            List<Vertex> keyList = new List<Vertex>(); //vertices of graph (accessing vertices of graph won't work without this list unfortunately)
            Console.WriteLine("Welcome to the Graph Menu, where you can create, manipulate, and analyze your very own directed weighted graph!\n");
            while (!isQuit)
            {
                //Display current graph
                Console.WriteLine("Current graph:");
                if(g == null)
                {
                    Console.WriteLine("no graph yet");
                }
                else
                {
                    g.Print();
                }

                //Display menu
                Console.WriteLine("\nHere are your options:");
                Console.WriteLine("1. Create a new graph");
                Console.WriteLine("2. Insert to graph");
                Console.WriteLine("3. Remove from graph");
                Console.WriteLine("4. Find item in graph");
                Console.WriteLine("5. View vertices of graph");
                Console.WriteLine("6. View edges of graph");
                Console.WriteLine("7. View neighbors of a vertex");
                Console.WriteLine("8. View incident edges of a vertex");
                Console.WriteLine("9. Do BFS on graph");
                Console.WriteLine("10. Do DFS on graph");
                Console.WriteLine("11. Do Dijkstra on graph");
                Console.WriteLine("12. Find shortest path between vertices");
                Console.WriteLine("13. Empty the graph");
                Console.WriteLine("14. Exit menu");

                //get input
                string input = Console.ReadLine();

                //do requested functionality
                switch (input)
                {
                    case "1":
                        ///Create a new graph
                        g = new Graph();
                        //Insert SubMenu
                        InsertMenu(ref g, ref keyList);
                        break;
                    case "2":
                        ///Insert to graph
                        if(g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before inserting");
                            Console.WriteLine("(Press ENTER to continue)\n");
                            Console.ReadLine();
                        }
                        else
                        {
                            //Insert SubMenu
                            InsertMenu(ref g, ref keyList);
                        }
                        break;
                    case "3":
                        ///Remove from graph
                        if(g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before removing");
                            Console.WriteLine("(Press ENTER to continue)\n");
                            Console.ReadLine();
                        }
                        else
                        {
                            //Remove SubMenu
                            ///Remove Options:
                            ///     Vertices
                            ///     Edges
                            bool done = false;
                            while (!done)
                            {
                                Console.WriteLine("What would you like to remove:");
                                Console.WriteLine("1. a vertex");
                                Console.WriteLine("2. an edge");
                                Console.WriteLine("3. view graph");
                                Console.WriteLine("4. nothing please");

                                //get input
                                string removeInput = Console.ReadLine();

                                //remove according to user input
                                switch (removeInput)
                                {
                                    case "1":
                                        //remove a vertex
                                        Console.WriteLine("Please enter the vertex you want to remove:");
                                        string vertex = Console.ReadLine();
                                        bool isRemoved = false;
                                        for (int i = 0; i < keyList.Count(); i++)
                                        {
                                            if (keyList[i].GetValue().Equals(vertex))
                                            {
                                                isRemoved = g.RemoveVertex(keyList[i]);
                                                keyList.RemoveAt(i);
                                                break;
                                            }
                                        }
                                        if (!isRemoved)
                                        {
                                            Console.WriteLine("Vertex not removed successively. Please select another option....");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Vertex removed successively.");
                                        }
                                        break;
                                    case "2":
                                        //remove an edge
                                        Console.WriteLine("Please enter the starting vertex of edge you want to remove:");
                                        string v1 = Console.ReadLine();
                                        Vertex vertex1 = null;
                                        for (int i = 0; i < keyList.Count(); i++)
                                        {
                                            if (keyList[i].GetValue().Equals(v1))
                                            {
                                                vertex1 = keyList[i];
                                                break;
                                            }
                                        }

                                        Console.WriteLine("Please enter the ending vertex of edge you want to remove:");
                                        string v2 = Console.ReadLine();
                                        Vertex vertex2 = null;
                                        for (int i = 0; i < keyList.Count(); i++)
                                        {
                                            if (keyList[i].GetValue().Equals(v2))
                                            {
                                                vertex2 = keyList[i];
                                                break;
                                            }
                                        }

                                        bool removeEdge = g.RemoveEdge(vertex1, vertex2);
                                        if (!removeEdge)
                                        {
                                            Console.WriteLine("Edge not removed successively. Please select another option....");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Edge removed successively.");
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine();
                                        g.Print();
                                        Console.WriteLine();
                                        break;
                                    case "4":
                                        Console.WriteLine("Removal process exiting...");
                                        done = true;
                                        break;
                                    default:
                                        Console.WriteLine("ERROR: Command not recognized");
                                        break;
                                }
                                Console.WriteLine("(Press ENTER to continue)\n");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "4":
                        ///Find item in graph
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before finding");
                        }
                        else
                        {
                            //Find SubMenu
                            ///Find Options:
                            ///     Vertex
                            ///     Edge (outgoing only)
                            Console.WriteLine("What would you like to find:");
                            Console.WriteLine("1. a vertex");
                            Console.WriteLine("2. an edge (outgoing only)");
                            Console.WriteLine("3. nothing");

                            //get input
                            string findInput = Console.ReadLine();

                            //find according to user input
                            switch (findInput)
                            {
                                case "1":
                                    //find a vertex
                                    Console.WriteLine("Please input the value of the vertex you want to find:");
                                    string userVertex = Console.ReadLine();
                                    bool isFound = false;
                                    for (int i = 0; i < keyList.Count(); i++)
                                    {
                                        if (keyList[i].GetValue().Equals(userVertex))
                                        {
                                            isFound = g.FindVertex(keyList[i]);
                                            break;
                                        }
                                    }
                                    if (!isFound)
                                    {
                                        Console.WriteLine("Vertex was not found in graph.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vertex was found in graph.");
                                    }
                                    break;
                                case "2":
                                    //find an edge
                                    Console.WriteLine("Please input the starting vertex of edge you want to find:");
                                    string v1 = Console.ReadLine();
                                    Vertex vertex1 = null;
                                    for (int i = 0; i < keyList.Count(); i++)
                                    {
                                        if (keyList[i].GetValue().Equals(v1))
                                        {
                                            vertex1 = keyList[i];
                                            break;
                                        }
                                    }

                                    Console.WriteLine("Please input the ending vertex of edge you want to find:");
                                    string v2 = Console.ReadLine();
                                    Vertex vertex2 = null;
                                    for (int i = 0; i < keyList.Count(); i++)
                                    {
                                        if (keyList[i].GetValue().Equals(v2))
                                        {
                                            vertex2 = keyList[i];
                                            break;
                                        }
                                    }

                                    bool findEdge = g.FindEdge(vertex1, vertex2);
                                    if (!findEdge)
                                    {
                                        Console.WriteLine("Edge was not found in graph.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Edge was found in graph.");
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("Find aborted");
                                    break;
                                default:
                                    Console.WriteLine("ERROR: Command not recognized");
                                    break;
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "5":
                        ///View vertices (can only view all vertices)
                        if(g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before viewing");
                        }
                        else
                        {
                            List<Vertex> vertices = g.GetAllVertices();
                            Console.WriteLine("Vertices of the graph");
                            foreach (Vertex v in vertices)
                            {
                                v.Print();
                                Console.WriteLine("\n---------------------");
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "6":
                        ///View edges
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before viewing");
                        }
                        else
                        {
                            //Edge SubMenu
                            ///Edge Options:
                            ///     All edges
                            ///     Outgoing edges
                            ///     Incoming edges
                            Console.WriteLine("What edges would you like to see:");
                            Console.WriteLine("1. ALL of them");
                            Console.WriteLine("2. outgoing only");
                            Console.WriteLine("3. incoming only");
                            Console.WriteLine("4. nevermind");

                            //get input
                            string viewEdgeInput = Console.ReadLine();

                            List<Edge> edges = null;
                            bool exit = false;
                            //view according to user input
                            switch (viewEdgeInput)
                            {
                                case "1":
                                    //all edges
                                    edges = g.GetAllEdges();
                                    break;
                                case "2":
                                    //outgoing edges
                                    edges = g.GetOutgoingEdges();
                                    break;
                                case "3":
                                    //incoming edges
                                    edges = g.GetIncomingEdges();
                                    break;
                                case "4":
                                    Console.WriteLine("Edge-Viewing successively cancelled");
                                    exit = true;
                                    break;
                                default:
                                    Console.WriteLine("ERROR: Command not recognized");
                                    exit = true;
                                    break;
                            }
                            if (!exit)
                            {
                                foreach (Edge e in edges)
                                {
                                    e.Print();
                                    Console.WriteLine("\n-----------------------------------------------");
                                }
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "7":
                        ///View neighbors of a vertex
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before viewing");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a vertex to get neighbors for:");
                            string vrtx = Console.ReadLine();
                            Vertex node = null;
                            
                            for (int i = 0; i < keyList.Count(); i++)
                            {
                                if (keyList[i].GetValue().Equals(vrtx))
                                {
                                    node = keyList[i];
                                    break;
                                }
                            }
                            if (node == null)
                            {
                                Console.WriteLine("Invalid vertex/not found in graph");
                            }
                            else
                            {
                                List<Vertex> neighbors = g.GetNeighbors(node);
                                Console.WriteLine("Neighbors of vertex " + node.GetValue() + ":");
                                foreach(Vertex v in neighbors)
                                {
                                    v.Print();
                                    Console.WriteLine("\n---------------------");
                                }
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "8":
                        ///View incident edges of a vertex
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before viewing");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a vertex to get incident edges for:");
                            string vrtx = Console.ReadLine();
                            Vertex node = null;

                            for (int i = 0; i < keyList.Count(); i++)
                            {
                                if (keyList[i].GetValue().Equals(vrtx))
                                {
                                    node = keyList[i];
                                    break;
                                }
                            }
                            if (node == null)
                            {
                                Console.WriteLine("Invalid vertex/not found in graph");
                            }
                            else
                            {
                                //Incident Edges SubMenu
                                ///Incident Options:
                                ///     incoming
                                ///     outgoing
                                Console.WriteLine("What incident edges would you like to find:");
                                Console.WriteLine("1. incoming");
                                Console.WriteLine("2. outgoing");
                                Console.WriteLine("3. I quit");

                                //get input
                                string incidentInput = Console.ReadLine();


                                List<Edge> incidentEdges = null;
                                bool exited = false;
                                //find according to user input
                                switch (incidentInput)
                                {
                                    case "1":
                                        //view incoming
                                        incidentEdges = g.GetIncidentIncomingEdges(node);
                                        break;
                                    case "2":
                                        //view outgoing
                                        incidentEdges = g.GetIncidentOutgoingEdges(node);
                                        break;
                                    case "3":
                                        Console.WriteLine("Incident viewing has been exited");
                                        exited = true;
                                        break;
                                    default:
                                        Console.WriteLine("ERROR: Command not recognized");
                                        exited = true;
                                        break;
                                }
                                if (!exited)
                                {
                                    Console.WriteLine("Incident edges of vertex " + node.GetValue() + ":");
                                    foreach (Edge e in incidentEdges)
                                    {
                                        e.Print();
                                        Console.WriteLine("\n---------------------------------------------");
                                    }
                                }
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "9":
                        ///Do BFS on graph
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before doing BFS\n");
                        }
                        else
                        {
                            Console.WriteLine("Please enter the starting vertex:");
                            string vrtx = Console.ReadLine();
                            Vertex node = null;

                            for (int i = 0; i < keyList.Count(); i++)
                            {
                                if (keyList[i].GetValue().Equals(vrtx))
                                {
                                    node = keyList[i];
                                    break;
                                }
                            }
                            if (node == null)
                            {
                                Console.WriteLine("Invalid vertex/not found in graph\n");
                            }
                            else
                            {
                                List<Edge> bfs = g.BFS(node);
                                Console.WriteLine("BFS graph traversal starting from " + node.GetValue() + ":");
                                foreach (Edge e in bfs)
                                {
                                    e.Print();
                                    Console.WriteLine("\n----------------------------------------------");
                                }
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "10":
                        ///Do DFS on graph
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before doing DFS\n");
                        }
                        else
                        {
                            Console.WriteLine("Please enter the starting vertex:");
                            string vrtx = Console.ReadLine();
                            Vertex node = null;

                            for (int i = 0; i < keyList.Count(); i++)
                            {
                                if (keyList[i].GetValue().Equals(vrtx))
                                {
                                    node = keyList[i];
                                    break;
                                }
                            }
                            if (node == null)
                            {
                                Console.WriteLine("Invalid vertex/not found in graph\n");
                            }
                            else
                            {
                                List<Edge> dfs = g.DFS(node);
                                Console.WriteLine("DFS graph traversal starting from " + node.GetValue() + ":");
                                foreach (Edge e in dfs)
                                {
                                    e.Print();
                                    Console.WriteLine("\n---------------------------------------------");
                                }
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "11":
                        ///Do Dijkstra on graph
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before doing Dijkstra\n");
                        }
                        else
                        {
                            Console.WriteLine("Please enter the starting vertex:");
                            string vrtx = Console.ReadLine();
                            Vertex node = null;

                            for (int i = 0; i < keyList.Count(); i++)
                            {
                                if (keyList[i].GetValue().Equals(vrtx))
                                {
                                    node = keyList[i];
                                    break;
                                }
                            }
                            if (node == null)
                            {
                                Console.WriteLine("Invalid vertex/not found in graph\n");
                            }
                            else
                            {
                                Dictionary<Vertex, Vertex> dijk = g.Dijkstra(node);
                                Console.WriteLine("Vertices and their best predessessors from Dijkstra's shortest paths from node " + node.GetValue() + ":");
                                foreach (KeyValuePair<Vertex, Vertex> p in dijk)
                                {
                                    Console.WriteLine(p.Key.ToString() + " preceeded by " + p.Value.ToString());
                                    Console.WriteLine("\n--------------------------------------------");
                                }
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "12":
                        ///Find shortest path between vertices
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Please create graph before doing path finding\n");
                        }
                        else
                        {
                            Console.WriteLine("Please input the starting vertex of path you want to find:");
                            string v1 = Console.ReadLine();
                            Vertex vertex1 = null;
                            for (int i = 0; i < keyList.Count(); i++)
                            {
                                if (keyList[i].GetValue().Equals(v1))
                                {
                                    vertex1 = keyList[i];
                                    break;
                                }
                            }

                            Console.WriteLine("Please input the ending vertex of path you want to find:");
                            string v2 = Console.ReadLine();
                            Vertex vertex2 = null;
                            for (int i = 0; i < keyList.Count(); i++)
                            {
                                if (keyList[i].GetValue().Equals(v2))
                                {
                                    vertex2 = keyList[i];
                                    break;
                                }
                            }

                            if (vertex1 == null || vertex2 == null)
                            {
                                Console.WriteLine("Invalid vertices/not found in graph\n");
                            }
                            else
                            {
                                List<Vertex> path = g.FindPath(vertex1, vertex2);
                                Console.WriteLine("THe shortest path (node to node) from node " + vertex1.GetValue() + " to " + vertex2.GetValue() + " is:");
                                if (path == null)
                                {
                                    Console.WriteLine("Path does not exist");
                                }
                                else
                                {
                                    foreach (Vertex n in path)
                                    {
                                        n.Print();
                                        Console.WriteLine("\n---------------------");
                                    }
                                }
                            }
                        }
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                    case "13":
                        ///Clear graph
                        if (g == null)
                        {
                            Console.WriteLine("ERROR: Graph not created yet. Cannot clear a non-existant graph");
                            Console.WriteLine("(Press ENTER to continue)\n");
                            Console.ReadLine();
                        }
                        else
                        {
                            g.Clear();
                            keyList.Clear();
                        }
                        break;
                    case "14":
                        isQuit = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Command not recognized");
                        Console.WriteLine("(Press ENTER to continue)\n");
                        Console.ReadLine();
                        break;
                }
            }
            Console.WriteLine("\nThank you so much for visiting the Graph Menu! We hope to see you again soon! (Press ENTER to exit)");
            Console.ReadLine(); //to pause the execution so console does not close right after print
        }

        /// InsertMenu
        /// Runs a menu for inserting an element into a graph
        /// Insert Options:
        ///     Vertices
        ///     Edges
        /// Params: g (graph to be modified)
        /// Returns: nothing
        static void InsertMenu(ref Graph g, ref List<Vertex> keyList)
        {
            bool done = false;
            while (!done)
            {
                ///Options:
                Console.WriteLine("What would you like to insert:");
                Console.WriteLine("1. a vertex");
                Console.WriteLine("2. an edge");
                Console.WriteLine("3. view graph");
                Console.WriteLine("4. nothing please");

                //get input
                string insertInput = Console.ReadLine();

                //insert according to user input
                switch (insertInput)
                {
                    case "1":
                        //a vertex
                        Console.WriteLine("Please input the value of your new vertex:");
                        string value = Console.ReadLine();
                        Vertex v = new Vertex(value);
                        
                        bool isInserted = g.InsertVertex(v);
                        if (!isInserted)
                        {
                            Console.WriteLine("Vertex insertion unsuccessful. Please select an option again....");
                        }
                        else
                        {
                            keyList.Add(v);
                            Console.WriteLine("Vertex insertion successful.");
                        }

                        break;
                    case "2":
                        //an edge
                        Console.WriteLine("Please give the starting vertex of your new edge:");
                        string v1 = Console.ReadLine();
                        Vertex vertex1 = null;
                        for (int i = 0; i < keyList.Count(); i++)
                        {
                            if (keyList[i].GetValue().Equals(v1))
                            {
                                vertex1 = keyList[i];
                                break;
                            }
                        }

                        Console.WriteLine("Please give the ending vertex of your new edge:");
                        string v2 = Console.ReadLine();
                        Vertex vertex2 = null;
                        for (int i = 0; i < keyList.Count(); i++)
                        {
                            if (keyList[i].GetValue().Equals(v2))
                            {
                                vertex2 = keyList[i];
                                break;
                            }
                        }

                        Console.WriteLine("Please give the weight of your new edge:");
                        int w;
                        bool isInt = Int32.TryParse(Console.ReadLine(), out w);
                        while (!isInt)
                        {
                            Console.WriteLine("That isn't a number! Please try again....\n");
                            Console.WriteLine("Please give the weight of your new edge:");
                            isInt = Int32.TryParse(Console.ReadLine(), out w);
                        }

                        bool insertedEdge = g.InsertEdge(vertex1, vertex2, w);
                        if (!insertedEdge)
                        {
                            Console.WriteLine("Edge insertion unsuccessful. Please select an option again....");
                        }
                        else
                        {
                            Console.WriteLine("Edge insertion successful.");

                        }

                        break;
                    case "3":
                        Console.WriteLine();
                        g.Print();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Insert session ending....");
                        done = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Command not recognized");
                        break;
                }
                Console.WriteLine("(Press ENTER to continue)\n");
                Console.ReadLine();
            }
        }
    }
}
