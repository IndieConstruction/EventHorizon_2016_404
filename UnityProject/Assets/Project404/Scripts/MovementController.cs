using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EH.Project404{
	public class MovementController : MonoBehaviour, IMove  {
		//public float speed =0.3f;
		RoadNode actualNode;
		public GameManager gm;

		void OnEnable () {
			GameManager.OnPreSetUp += OnPreSetUp;
			GameManager.OnSetUp += OnSetUp;
			GameManager.OnPostSetUp += OnPostSetUp;
		}
		void OnDisable () {
			GameManager.OnPreSetUp -= OnPreSetUp;
			GameManager.OnSetUp -= OnSetUp;
			GameManager.OnPostSetUp -= OnPostSetUp;
		}
		void OnPreSetUp(GameManager gm){

		
		}
		void OnSetUp(GameManager gm){
			if(ActualNode == null)
				ActualNode = gm.nm.GetFirstNode();
		}
		void OnPostSetUp(GameManager gm){}

		/// <summary>
		///Setta l'actual node
		/// </summary>
		/// <value>The actual node.</value>
		public RoadNode ActualNode {
			get{

				return actualNode;
			}
			set{
				if(actualNode != value){
					Debug.Log ("sposto road node numero " + value);
				//	value.transform.position =- value.transform.position;

				}
				actualNode = value;

			}
		}
	
	

		void Update(){
			if (ActualNode != null) {
			Movement ();
			}
		}
	/// <summary>
	/// La pista si muove verso l'actual node
	/// </summary>
		public void Movement () {
			transform.position = Vector3.MoveTowards(this.transform.position,ActualNode.transform.position,0.3f);
		}

		/// <summary>
		/// Quando collide con lo spawnController spawna un nuovo prefab
		/// </summary>
		/// <param name="other">Other.</param>
		void OnTriggerEnter (Collider other) {
			SpawnController spCntrl = other.GetComponent<SpawnController> (); 
			if (spCntrl != null) {

				spCntrl.RandomSpawnItems ();
				Vector3 newPos = new Vector3 (0,0,417);
				spCntrl.transform.position = spCntrl.transform.position - newPos;

			}
		}


	}
}
