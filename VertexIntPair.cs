/// VertexIntPair
/// C# Pair Object that pairs a Vertex with an integer (specialized for PriorityQueue and Dijkstra's algo)
/// Author: Karena Qian
/// Last Edited: 3/17/2023

using System;

namespace GraphImpl
{
    class VertexIntPair : IComparable<VertexIntPair>
    {
        private Vertex v;
        private int dist;

        /// Constructor
		/// Empty constructor initializes the VertexIntPair to an Empty VertexIntPair
		/// Params: none
		/// Returns: none
        public VertexIntPair()
        {
            this.v = new Vertex("");
            this.dist = -1;
        }

        /// Constructor
		/// Non empty constructor with only vertex
		/// Params: v (to set this VertexIntPair's Vertex to)
		/// Returns: none
        public VertexIntPair(Vertex v)
        {
            this.v = v;
            this.dist = -1;
        }
        
        /// Constructor
		/// Non empty constructor with both vertex and int
		/// Params: 
        ///     v (to set this VertexIntPair's Vertex to)
        ///     dist (to set this VertexIntPair's dist to)
		/// Returns: none
        public VertexIntPair(Vertex v, int dist)
        {
            this.v = v;
            this.dist = dist;
        }

        /// GetVertex
		/// Gets vertex of VertexIntPair
		/// Params: none
		/// Returns: vertex of this VertexIntPair
        public Vertex GetVertex()
        {
            return this.v;
        }

        /// GetDist
		/// Gets dist of VertexIntPair
		/// Params: none
		/// Returns: dist of this VertexIntPair
        public int GetDist()
        {
            return this.dist;
        }

        /// SetVertex
		/// Sets vertex of VertexIntPair
		/// Param: v (to set this VertexIntPair's vertex to)
		/// Returns: none
        public void SetVertex(Vertex v)
        {
            this.v = v;
        }

        /// SetDist
		/// Sets dist of VertexIntPair
		/// Param: dist (to set this VertexIntPair's dist to)
		/// Returns: none
        public void SetDist(int dist)
        {
            this.dist = dist;
        }
        
        /// CompareTo
		/// Compares another VertexIntPair with this VertexIntPair by only dist value (for Dijkstra's purpose)
		/// Param: other (VertexIntPair to be compared to with this)
		/// Returns: an integer (< 0 if less then, > 0 if greater than, 0 if equal)
        public int CompareTo(VertexIntPair other)
        {
            if(this.dist < other.GetDist())
            {
                return -1;
            }
            else if(this.dist > other.GetDist())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// CompareVertex
		/// Compares another VertexIntPair with this VertexIntPair by only v Vertex
		/// Param: other (VertexIntPair to be compared to with this)
		/// Returns: an integer (< 0 if less then, > 0 if greater than, 0 if equal)
        public int CompareVertex(VertexIntPair other)
        {
            return this.v.CompareTo(other.GetVertex());
        }

        /// ToString
        /// Returns string representation of VertexIntPair
        /// Params: none
        /// Returns: string
        override public string ToString()
        {
            return "[" + this.v.ToString() + ": " + this.dist + "]";
        }
    }
}
