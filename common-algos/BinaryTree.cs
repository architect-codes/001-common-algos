﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ar.codes.common_algos
{
    /// <summary>
    /// implements binary tree concepts
    /// </summary>
    public class BinaryTree<T> where T : notnull, IComparable<T>
    {
        public Node<T>? Root { get; set; }

        public BinaryTree()
        {

        }

        /// <summary>
        /// adds new node
        /// </summary>
        /// <param name="value">value of a node</param>
        public void AddNode(T value)
        {
            // check if our tree is not initialized yet
            if (Root is null)
            {
                // let's create a root node, assign value to it and this is it
                Root = new Node<T>() { Value = value };
                return;
            }

            // ok, start traversing 
            Root.Add(value);
        }

        public void Traverse(Action<Node<T>> action)
        {
            Root?.TraverseDepth(action);
        }
    }

    public class Node<T> where T : notnull, IComparable<T>
    {
        public T? Value { get; set; } 

        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public void Add(T newValue)
        {
            // determine if newValue should go left or right
            if(newValue.CompareTo(Value) < 0)
                Left = AssureExists(Left, newValue);

            if (newValue.CompareTo(Value) > 0)
                Right = AssureExists(Right, newValue);

            static Node<T> AssureExists(Node<T>? node, T newValue)
            {
                if(node is null)
                    node = new Node<T>() { Value = newValue };
                else
                    node.Add(newValue);

                return node;
            }
        }

        /// <summary>
        /// Traverses a tree via depth-first algoritm and invokes action passed
        /// </summary>
        /// <param name="action"></param>
        public void TraverseDepth(Action<Node<T>> action)
        {
            action?.Invoke(this);

            Left?.TraverseDepth(action!);
            Right?.TraverseDepth(action!);
        }
    }
}