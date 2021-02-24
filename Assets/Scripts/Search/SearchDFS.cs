using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SearchDFS
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {

		Stack<GraphNode> nodes = new Stack<GraphNode>();
		nodes.Push(source);

		bool found = false;
		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			// get top node of stack node (peek)
			GraphNode node = nodes.Peek();//< peek at stack

			node.Visited = true;

			bool forward = false;
			// search node edges for unvisited node
			foreach (GraphNode.Edge edge in node.Edges)
			{
				// if node unvisited then push on stack
				nodes.Push(node);
				if (edge.nodeB.Visited == false)
				{
					nodes.Push(edge.nodeB);
					forward = true;

					if (edge.nodeB == destination)
					{
						found = true;
					}
					break;
				}
			}

			// if not moving forward, pop current node off stack
			if (forward == false)
			{
				nodes.Pop();
			}
		}

		Debug.Log(nodes.Count);
		// convert stack path nodes to list
		path = new List<GraphNode>(nodes);
		path.Reverse();

		return found;
	}
}
