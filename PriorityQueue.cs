/// PriorityQueue
/// C# Priority Queue implementation specialized for Dijkstra (limited to only using VertexIntPair object)
/// Author: Karena Qian
/// Last Edited: 3/17/2023

using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphImpl
{
    class PriorityQueue<VertexIntPair> where VertexIntPair : IComparable<VertexIntPair>
    {
        /// C# Implementation of PriorityQueue using Min Binary Heap,
        /// which is implemented using an array
        /// left child index: 2i + 1
        /// right child index: 2i + 2
        private readonly List<VertexIntPair> pQueue = new List<VertexIntPair>();

        /// Swap (helper for Swim and Sink)
        /// Does a simple element swap in the priority queue
        /// Params:
        ///     index1 (index of first element to be swapped with second element)
        ///     index2 (index of second element to be swapped with first element)
        /// Returns: none
        private void Swap(int index1, int index2)
        {
            var temp = this.pQueue[index1];
            this.pQueue[index1] = this.pQueue[index2];
            this.pQueue[index2] = temp;
        }
        
        /// Swim (helper for Enqueue)
        /// Moves up the inserted element until the heap invariant is satisfied
        /// Implements the min heap invariant
        /// Params: none
        /// Returns: none
        private void Swim()
        {
            int child = this.pQueue.Count - 1; //initial index of child being moved up
            while(child > 0) //stops if child reaches root
            {
                int currParent = (child - 1) / 2; //get curr index of parent
                if(this.pQueue[child].CompareTo(this.pQueue[currParent]) >= 0) //stop if child is greater/equal to parent
                {
                    break;
                }
                Swap(child, currParent); //swap parent with child
                child = currParent; //child's index is now parent's index
            }
        }

        /// RemoveAndReplaceTop (helper for Dequeue)
        /// Removes and replaces first element with the last element
        /// Params: none
        /// Returns: none
        private void RemoveAndReplaceTop()
        {
            var last = this.pQueue.Count - 1; //index of last element
            this.pQueue[0] = this.pQueue[last]; //swap top element with bottom element
            this.pQueue.RemoveAt(last); //remove the swapped top element
        }

        /// Sink (helper for Dequeue)
        /// Moves down the top element until the heap invariant is satisfied
        /// Implements the min heap invariant
        /// Params: none
        /// Returns: none
        private void Sink() // Implementation of the Min Heap Sink Down operation
        {
            var last = this.pQueue.Count - 1; //index of last element
            var parent = 0; //index of parent/element to be moved down

            while (true)
            {
                var currChild = (parent * 2) + 1; //get the left child of parent
                if (currChild > last) //stop if left child reaches bottom
                {
                    break;
                }
                var rightChild = currChild + 1; //get the right child of parents
                if (rightChild <= last && this.pQueue[rightChild].CompareTo(this.pQueue[currChild]) < 0)
                {
                    currChild = rightChild; //set curr child to right child if right child is less than left child and is less/equal to last
                }
                if (this.pQueue[parent].CompareTo(this.pQueue[currChild]) < 0) //stop if curr child is greater than the parent
                {
                    break;
                }
                Swap(parent, currChild); //swaps parent with child
                parent = currChild; //set parent to child
            }
        }

        /// Enqueue
        /// Adds an element to the end of the priority queue
        /// and then sorts it so the heap invariant is satisfied
        /// Params: item (element to be added)
        /// Returns: none
        public void Enqueue(VertexIntPair item)
        {
            this.pQueue.Add(item);
            Swim();
        }

        /// Dequeue
        /// Removes an element from the front of the priority queue
        /// and then sorts it so the heap invariant is satisfied
        /// Params: none
        /// Returns: element that was removed
        public VertexIntPair Dequeue()
        {
            var item = this.pQueue[0];
            RemoveAndReplaceTop();
            Sink();
            return item;
        }

        /// Peek
        /// Gets the first element of priority queue without returning it
        /// Params: none
        /// Returns: first element of priority queue
        public VertexIntPair Peek()
        {
            return this.pQueue[0];
        }

        /// Count
        /// Returns the number of elements in priority queue
        /// Params: none
        /// Returns: number of elements in array
        public int Count()
        {
            return this.pQueue.Count();
        }

        /// Clear
        /// Removes all elements in priority queue
        /// Params: none
        /// Returns: none
        public void Clear()
        {
            this.pQueue.Clear();
        }

        /// ToString
        /// Returns string representation of priority queue
        /// Params: none
        /// Returns: string
        override public string ToString()
        {
            string ret = "[";
            for(int i = 0; i < this.pQueue.Count()-1; i++)
            {
                ret += this.pQueue[i].ToString() + ", ";
            }
            ret += this.pQueue[this.pQueue.Count() - 1].ToString() + "]";
            return ret;
        }
    }
}
