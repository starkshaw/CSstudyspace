using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CompressionCalculator {
	// From MSDN
	public class Node<T> {
		// Private member-variables
		private T data;
		private NodeList<T> neighbors = null;

		public Node() { }
		public Node(T data) : this(data, null) { }
		public Node(T data, NodeList<T> neighbors) {
			this.data = data;
			this.neighbors = neighbors;
		}

		public T Value {
			get {
				return data;
			}
			set {
				data = value;
			}
		}

		protected NodeList<T> Neighbors {
			get {
				return neighbors;
			}
			set {
				neighbors = value;
			}
		}
	}

	public class NodeList<T> : Collection<Node<T>> {
		public NodeList() : base() { }

		public NodeList(int initialSize) {
			// Add the specified number of items
			for (int i = 0; i < initialSize; i++)
				base.Items.Add(default(Node<T>));
		}

		public Node<T> FindByValue(T value) {
			// search the list for the value
			foreach (Node<T> node in Items)
				if (node.Value.Equals(value))
					return node;

			// if we reached here, we didn't find a matching node
			return null;
		}
	}
}



/*public class Node {
	public char letter { get; set; }		// Store letter
	public string data;
	public int frequency;
	public Node leftChild { get; set; }		// This node's left child
	public Node rightChild { get; set; }	// This node's right child
	/*private int sum;

	public int Sum() {
		if (leftChild != null && rightChild != null) {
				
		} 
		return sum;
	}

	public Node(string data, int frequency) {
		this.data = data;
		this.frequency = frequency;
	}

	public Node(Node leftChild, Node rightChild) {
		this.leftChild = leftChild;
		this.rightChild = rightChild;
		this.data = string.Format("{0}:{1}", leftChild.data, rightChild);
		this.frequency = leftChild.frequency + rightChild.frequency;
	}
}
}*/
