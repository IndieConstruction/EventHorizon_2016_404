﻿using UnityEngine;
using System.Collections.Generic;
namespace EH.Project404{
public class NodesManager : MonoBehaviour {
		
	public List<RoadNode> nodes = new List<RoadNode>() ;


	public RoadNode GetFirstNode (){
		return nodes[0];
	}

	public RoadNode GetNextNode (RoadNode actualNode) {

		for (int i = 0; i < nodes.Count; i++) {
				if (nodes[i]== actualNode && i+1 < nodes.Count){

				return nodes[i+1];

			}

		}
		return null;
	}
		public void AddNodes (List<RoadNode> nodesToAdd){

			nodes.AddRange(nodesToAdd);
		}
		public void RemoveNodes (){
			
			nodes.RemoveRange(1,2);
		}

}
}