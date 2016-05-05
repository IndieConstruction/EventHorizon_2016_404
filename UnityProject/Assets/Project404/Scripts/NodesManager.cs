using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class NodesManager : MonoBehaviour {

	public RoadNode[] nodes;

	void Awake (){
		nodes = GetComponentsInChildren<RoadNode>();
	}

	void Start () {
		
	}
	public RoadNode GetFirstNode (){
		return nodes[0];
	}

	public RoadNode GetNextNode (RoadNode actualNode) {

		for (int i = 0; i < nodes.Length; i++) {
			if (nodes[i]== actualNode && i+1 < nodes.Length){

				return nodes[i+1];
			}
		
		}
		return null;
	}
}
}