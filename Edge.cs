/// Edge
/// C# Object representing a single edge in a Directed Weighted graph data structure
/// Author: Karena Qian
/// Last Edited: 3/17/2023

using System;

namespace GraphImpl
{
	public class Edge
	{
		private Vertex vertex1; //start vertex
		private Vertex vertex2; //destination vertex
		private int weight; //value of edge
		private bool inComing; //true if incoming edge, false otherwise
		
		/// Constructor
		/// Empty constructor initializes the Edge to an Empty Edge
		/// Params: none
		/// Returns: none
		public Edge()
        {
			this.vertex1 = new Vertex("");
			this.vertex2 = new Vertex("");
			this.weight = 0;
			this.inComing = false;
        }

		/// Constructor
		/// Non empty constructor w/ values (default to outgoing edge)
		/// Params: 
		///		value1 (value of Vertex to set this Edge's vertex1 to)
		///		value2 (value of Vertex to set this Edge's vertex2 to)
		///		weight (to set this Edge's weight to)
		/// Returns: none
		public Edge(string value1, string value2, int weight)
		{
			this.vertex1 = new Vertex(value1);
			this.vertex2 = new Vertex(value2);
			this.weight = weight;
			this.inComing = false;
		}
		
		/// Constructor
		/// Non empty constructor w/ objects (default to outgoing edge)
		/// Params: 
		///		vertex1 (to set this Edge's vertex1 to)
		///		vertex2 (to set this Edge's vertex2 to)
		///		weight (to set this Edge's weight to)
		/// Returns: none
		public Edge(Vertex vertex1, Vertex vertex2, int weight)
		{
			this.vertex1 = vertex1;
			this.vertex2 = vertex2;
			this.weight = weight;
			this.inComing = false; //set to default (outgoing edge)
		}
		
		/// Constructor
		/// Non empty constructor w/ values + incoming/outgoing status
		/// Params: 
		///		value1 (value of Vertex to set this Edge's vertex1 to)
		///		value2 (value of Vertex to set this Edge's vertex2 to)
		///		weight (to set this Edge's weight to)
		///		inComing (to set this Edge's inComing to)
		/// Returns: none
		public Edge(string value1, string value2, int weight, bool inComing)
		{
			this.vertex1 = new Vertex(value1);
			this.vertex2 = new Vertex(value2);
			this.weight = weight;
			this.inComing = inComing;
		}

		/// Constructor
		/// Non empty constructor w/ objects + incoming/outgoing status
		/// Params: 
		///		vertex1 (to set this Edge's vertex1 to)
		///		vertex2 (to set this Edge's vertex2 to)
		///		weight (to set this Edge's weight to)
		///		inComing (to set this Edge's inComing to)
		/// Returns: none
		public Edge(Vertex vertex1, Vertex vertex2, int weight, bool inComing)
		{
			this.vertex1 = vertex1;
			this.vertex2 = vertex2;
			this.weight = weight;
			this.inComing = inComing;
		}

		/// GetVertex1
		/// Gets vertex1 of Edge
		/// Params: none
		/// Returns: vertex1 of this Edge
		public Vertex GetVertex1()
		{
			return this.vertex1;
		}

		/// GetVertex2
		/// Gets vertex2 of Edge
		/// Params: none
		/// Returns: vertex2 of this Edge
		public Vertex GetVertex2()
		{
			return this.vertex2;
	
		}

		/// GetWeight
		/// Gets weight of Edge
		/// Params: none
		/// Returns: weight of this Edge
		public int GetWeight()
        {
			return this.weight;
        }

		/// GetStatus
		/// Gets incoming/outgoing status (inComing) of Edge
		/// Params: none
		/// Returns: inComing of this Edge
		public bool GetStatus()
        {
			return this.inComing;
        }

		/// SetVertex1
		/// Sets vertex1 (given by vertex) of Edge
		/// Param:
		///		v (to set this Edge's vertex1 to)
		/// Returns: none
		public void SetVertex1(Vertex v)
		{
			this.vertex1 = v;
		}

		/// SetVertex2
		/// Sets vertex2 (given by vertex) of Edge
		/// Param:
		///		v (to set this Edge's vertex2 to)
		/// Returns: none
		public void SetVertex2(Vertex v)
		{
			this.vertex2 = v;
		}

		/// SetValue1
		/// Sets vertex1 (given by value) of Edge
		/// Param: 
		///		value (value of Vertex to set this Edge's vertex1 to)
		/// Returns: none
		public void SetValue1(string value)
		{
			this.vertex1 = new Vertex(value);
		}

		/// SetValue2
		/// Sets vertex2 (given by value) of Edge
		/// Param: 
		///		value (value of Vertex to set this Edge's vertex2 to)
		/// Returns: none
		public void SetValue2(string value)
		{
			this.vertex2 = new Vertex(value);
		}

		/// SetBothVertices
		/// Sets both vertices (given by vertex) of Edge
		/// Param: 
		///		v1 (to set this Edge's vertex1 to)
		///		v2 (to set this Edge's vertex2 to)
		/// Returns: none
		public void SetBothVertices(Vertex v1, Vertex v2)
		{
			this.vertex1 = v1;
			this.vertex2 = v2;
		}

		/// SetBothValues
		/// Sets both vertices (given by value) of Edge
		/// Param: 
		///		v1 (value of Vertex to set this Edge's vertex1 to)
		///		v2 (value of Vertex to set this Edge's vertex2 to)
		/// Returns: none
		public void SetBothValues(string v1, string v2)
		{
			this.vertex1 = new Vertex(v1);
			this.vertex2 = new Vertex(v2);
		}

		/// SetWeight
		/// Sets weight of Edge
		/// Param: weight (to set this Edge's weight to)
		/// Returns: none
		public void SetWeight(int weight)
        {
			this.weight = weight;
        }

		/// SetStatus
		/// Sets status (inComing) of Edge
		/// Param: inComing (to set this Edge's inComing to)
		/// Returns: none
		public void SetStatus(bool inComing)
        {
			this.inComing = inComing;
        }
		
		/// Equals
		/// Equates another edge with this edge
		/// Params: e (edge to be compared with this)
		/// Returns: true if equal, false otherwise
		public bool Equals(Edge e)
        {
			//true if e->vertex1 == vertex1 AND e->vertex2 == vertex2 AND e->weight == weight AND e->inComing == inComing
			if(e.GetVertex1().Equals(this.vertex1) && e.GetVertex2().Equals(this.vertex2) && e.GetWeight() == this.weight && e.GetStatus() == this.inComing)
            {
				return true;
            }
			return false;
        }

		/// EqualsInParts
		/// Equates another edge (2 vertices & weight & status) with this edge
		/// Params: 
		///		v1 (Vertex1 of edge to be compared with this)
		///		v2 (Vertex2 of edge to be compared with this)
		///		weight (weight of Edge to be compared with this)
		///		inComing (status of Edge to be compared with this)
		/// Returns: true if equal, false otherwise
		public bool EqualsInParts(Vertex v1, Vertex v2, int weight, bool inComing)
        {
			if(v1.Equals(this.vertex1) && v2.Equals(this.vertex2) && weight == this.weight && inComing == this.inComing)
            {
				return true;
            }
			return false;
        }

		/// EqualsVerticesOnly
		/// Equates another edge (2 vertices only) with this edge
		/// Params: 
		///		v1 (Vertex1 of edge to be compared with this)
		///		v2 (Vertex2 of edge to be compared with this)
		/// Returns: true if equal, false otherwise
		public bool EqualsVerticesOnly(Vertex v1, Vertex v2)
        {
			if (v1.Equals(this.vertex1) && v2.Equals(this.vertex2))
			{
				return true;
			}
			return false;
		}

		/// EqualsNoWeight
		/// Equates another Edge (2 vertices + status) with this edge
		/// Params: 
		///		v1 (Vertex1 of Edge to be compared with this)
		///		v2 (Vertex2 of Edge to be compared with this)
		///		inComing (status of Edge to be compared with this)
		/// Returns: true if equal, false otherwise
		public bool EqualsNoWeight(Vertex v1, Vertex v2, bool inComing)
        {
			if (v1.Equals(this.vertex1) && v2.Equals(this.vertex2) && inComing == this.inComing)
			{
				return true;
			}
			return false;
		}

		/// CompareTo
		/// Compares another edge with this by weight only
		/// Param: e (Edge to be compared to with this)
		/// Returns: an integer (< 0 if less then, > 0 if greater than, 0 if equal)
		public int CompareTo(Edge e)
        {
			if(this.weight < e.GetWeight())
            {
				return -1;
            }
			else if(this.weight > e.GetWeight())
            {
				return 1;
            }
            else
            {
				return 0;
            }
        }

		/// Print
		/// Outputs the edge in the console as a connected pair of vertices
		/// Params: none
		/// Returns: none
		public void Print()
		{
			Console.Write("Edge: ");
			this.vertex1.Print();
            if (this.inComing)
            {
				Console.Write("<--[" + this.weight + "]---");
			}
            else
            {
				Console.Write("---[" + this.weight + "]-->");
			}
			
			this.vertex2.Print();
		}

		/// ToString
		/// Returns string representation of this edge
		/// Params: none
		/// Returns: string
		override public string ToString()
        {
			string ret = "Edge: " + this.vertex1.ToString();
			if (this.inComing)
			{
				ret += "<--[" + this.weight + "]---";
			}
			else
			{
				ret += "---[" + this.weight + "]-->";
			}
			ret += this.vertex2.ToString();
			return ret;
		}
	}
}
