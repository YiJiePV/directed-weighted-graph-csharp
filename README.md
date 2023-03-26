# C# Graph Class Library Implementation  
## About  
Author: Karena Qian  
Date: 3/17/2023  

Short Description:  
&emsp; This is my C# implementation of a directed weighted graph class library.  
&emsp; I implemented my graph class using an adjacency list and implemented several functionalities to modify, view, and analyze it, including vertex insertion, breadth first search, and Dijkstra's algorithm.  
&emsp; I've also included a client program in Program.cs that create a command-line menu with options that allows a user to create, modify, and analyze directed weighted graphs

Graph Class Features:
- Vertex and edge insertions
- Vertex and edge removals
- Vertex and edge getters
- Getters for retrieving:
  - All vertices
  - All edges
  - All incoming edges
  - All outgoing edges
  - All neighboring vertices of a vertex
  - All incoming edges incident to a vertex
  - All outgoing edges incident to a vertex
- Find for Vertex and edge
- Getter for size of graph
- Breadth First Search from a vertex
- Depth First Search from a vertex
- Dijkstra's Algorithm path-finding from a vertex
- Find Shortest Path from one vertex to another
- Graph clearing
- Print for outputing graph to the console/command line
> More information can be found in Graph.cs  

Tools:
- Visual Studio Community 2019 IDE
- Microsoft (R) Visual C# Compiler version 4.8.4084.0
- Visual Studio Code (for testing)
- Command Line (for testing)
- WSL Linux Terminal (for testing)  

Imported Libraries:
- C#'s System
  - Input/Output
- C#'s System.Collections.Generic
  - List<T>
  - Dictionary<TKey, TValue>
  - LinkedList<T>
  - Queue<T>
  - Stack<T>
- C#'s System.Linq   

## Running the Program
Visual Studio (particularly Visual Studio 2019 Community)
- Clone the repo into a protected directory
- Make sure you have .NET desktop development, ASP.NET and web development, and Azure development features downloaded
- Open the .sln file in Visual Studio
- Run the program directly in the IDE

Command Line
- Make sure you have the Microsoft (R) Visual C# Compiler installed and inside your Enviromental Variables
  - You can test by typing ` csc ` into a new command line terminal
- Clone the repo into a protected directory and enter that repo in a command line terminal
- Use the command ` csc Program.cs Graph.cs Edge.cs Vertex.cs VertexIntPair.cs PriorityQueue.cs ` to build the program and create an executable
  - the executable should be called ` Program.exe `
- Now just type ` Program.exe ` to run the program  
> Reference: https://www.geeksforgeeks.org/how-to-execute-c-sharp-program-on-cmd-command-line/

Linux (I used WSL since Docker doesn't work well on my machine)
- Make sure to update your Linux using ` sudo apt update `
- Install ` mono-complete ` with the command ` sudo apt install mono-complete `
- Now build the program with the command ` mcs -out:<name>.exe Program.cs Graph.cs Edge.cs Vertex.cs VertexIntPair.cs PriorityQueue.cs `
  - you can replace ` <name> ` with any name you want
- Now type ` mono <name>.exe ` to run the program
