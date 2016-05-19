using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class MovementCollider : MonoBehaviour {
	MovementController mc;
	NodesManager nm;


	void Start () {
		mc = FindObjectOfType<MovementController>();
		nm = FindObjectOfType<NodesManager>();
	}

/// <summary>
/// Quando collide con un RoadNode si fa dire il successivo e quello diventa actual node.
/// </summary>
/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other){
			Debug.Log ("Collisione");
	 	if(other.GetComponent<RoadNode>()!= null ) {
			if(mc.ActualNode == null)
				mc.ActualNode = nm.GetFirstNode();
		
		RoadNode nextNode = nm.GetNextNode(mc.ActualNode);
			
			if (nextNode != null)
				mc.ActualNode =nextNode;
				Debug.Log (mc.ActualNode);
			
			}
		}
	}
}