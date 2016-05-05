using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class MovementCollider : MonoBehaviour {
	MovementController mc;
	NodesManager nm;
	// Use this for initialization
	void Start () {
		mc = FindObjectOfType<MovementController>();
		nm = FindObjectOfType<NodesManager>();
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
			Debug.Log("collido e basta con " + other.name );
	 	if(other.GetComponent<RoadNode>()!= null ) {
			if(mc.ActualNode == null)
				mc.ActualNode = nm.GetFirstNode();
		RoadNode nextNode = nm.GetNextNode(mc.ActualNode);
			
			if (nextNode != null){
				mc.ActualNode = nextNode;
			}
		//Debug.Log("node " + actualNode.name + "-> "+nextNode.name);
		}
	}
}
}