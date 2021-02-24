using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SearchBFS
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
		Debug.Log("Entered BFS");
		// <create queue>
		Queue<GraphNode> nodes = new Queue<GraphNode>();

		// <set source node visited to true>
		source.Visited = true;
		// <enqueue source node>
		nodes.Enqueue(source);

		// set found bool flag and the current number of steps
		bool found = false;
		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			GraphNode node = nodes.Dequeue();//< dequeue node >
		
			// go through edges of node
			foreach (GraphNode.Edge edge in node.Edges)
			{
				Debug.Log("Looking at nodes on edges");
				// if nodeB is not visited
				if (edge.nodeB.Visited == false)
				{
					// <set nodeB visited to true>
					edge.nodeB.Visited = true;
					// <set nodeB parent to node>
					edge.nodeB.Parent = node;
					// <enqueue nodeB>
					nodes.Enqueue(edge.nodeB);
				}
				if (edge.nodeB.Type == GraphNode.eType.Destination)
				{
					// <set found to true>
					found = true;
					// <break from foreach>
					break;
				}
			}
			Debug.Log("Found Destination");
		}
		Debug.Log("Got out of While Loop");
		// create a list of graph nodes (path)
		path = new List<GraphNode>();
		Debug.Log("Made Path list");
		// if found is true
		if (found)
		{
			Debug.Log("Entered found if");
			GraphNode node = destination;//< set node to destination >
			Debug.Log("Node set to Destination");
		    // while node not null
			while (node != null)
			{
				Debug.Log("Entered While Loop");
				// <add node to path list>
				path.Add(node);
				// <set node to node.Parent>
				node = node.Parent;
			}
			// reverse path
			path.Reverse();
			Debug.Log("Made path list");
		}
		else
		{
			path = nodes.ToList();
		}

		Debug.Log("Returned Path");
		return found;

	}
}
