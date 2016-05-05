using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EH.Project404{
	public class MovementController : MonoBehaviour, IMove  {
		public float speed;
		RoadNode actualNode;
		public bool ReverseMovement = false;
		public RoadNode ActualNode {
			get{

				return actualNode;}
			set{
				if(actualNode != value){
					if(ReverseMovement)
						value.transform.position = -value.transform.position;
				}
				actualNode = value;
				
			}
		}
	
		void Start(){
			if(ActualNode == null)
				ActualNode = FindObjectOfType<NodesManager>().GetFirstNode();
		}

		void Update(){

			Movement ();
		}

		public void Movement () {
			if(ReverseMovement)
				transform.LookAt(-ActualNode.transform.position);
			else
				transform.LookAt(ActualNode.transform);
			if (ReverseMovement == true) {
				transform.Translate (Vector3.back * Time.deltaTime * speed);
			}
			else {
				transform.Translate (Vector3.forward * Time.deltaTime * speed);
			}

			
		}

	}
}
