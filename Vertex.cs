/// Vertex
/// C# Object representing a single vertex of a Directed Weighted graph data structure
/// Author: Karena Qian
/// Last Edited: 3/17/2023

using System;

namespace GraphImpl
{
	public class Vertex : IComparable<Vertex>
	{
		private string value;

		/// Constructor
		/// Non empty constructor (empty constructor not allowed)
		/// Params: value (to set this Vertex's value to)
		/// Returns: none
		public Vertex(string value)
		{
			this.value = value;
		}

		/// Clone
		/// Creates a deep copy of this vertex
		/// Params: nothing
		/// Returns: deep copy of this vertex
		public Vertex Clone()
        {
			Vertex neo = new Vertex(this.value);
			return neo;
        }

		/// GetValue
		/// Gets value of Vertex
		/// Params: none
		/// Returns: value of this Vertex
		public string GetValue()
		{
			return this.value;
		}

		/// SetValue
		/// Sets value of Vertex
		/// Param: value (to set this Vertex's value to)
		/// Returns: none
		public void SetValue(string value)
		{
			this.value = value;
		}

		/// CompareTo
		/// Compares another vertex with this vertex
		/// Param: v (Vertex to be compared to with this)
		/// Returns: an integer (< 0 if less then, > 0 if greater than, 0 if equal)
		public int CompareTo(Vertex v)
        {
			return this.value.CompareTo(v.GetValue());
        }

		/// Equals
		/// Equates another vertex with this vertex
		/// Params: v (Vertex to be compared with this)
		/// Returns: true if equal, false otherwise
		public bool Equals(Vertex v)
        {
            if (v.GetValue().Equals(this.value))
            {
				return true;
            }
			return false;
        }

		/// Print
		/// Outputs the vertex in the console
		/// Params: none
		/// Returns: none
		public void Print()
		{
			Console.Write("Vertex: " + this.value);
		}

		/// ToString
		/// Returns string representation of Vertex
		/// Params: none
		/// Returns: string
		override public string ToString()
        {
			return "Vertex: " + this.value;

		}
	}
}
