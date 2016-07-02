using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EH.Project404{
	public class MovementController : MonoBehaviour, IMove  {
		public bool Mov = true;
		RoadNode actualNode;
		public GameManager gm;
		public float speed = 0.32f;
		//Player player;
		void OnEnable () {
			GameManager.OnPreSetUp += OnPreSetUp;
			GameManager.OnSetUp += OnSetUp;
			GameManager.OnPostSetUp += OnPostSetUp;
			GameManager.OnGameOver += OnGameOver;
			GameManager.OnGamePaused += OnGamePaused;
			GameManager.OnGameResumed += OnGameResumed;
		}
		void OnDisable () {
			GameManager.OnPreSetUp -= OnPreSetUp;
			GameManager.OnSetUp -= OnSetUp;
			GameManager.OnPostSetUp -= OnPostSetUp;
			GameManager.OnGameOver += OnGameOver;
			GameManager.OnGameResumed -= OnGameResumed;
		}
		void OnPreSetUp(GameManager gm){
			//player = FindObjectOfType<Player>();
		
		}
		void OnSetUp(GameManager gm){
			if(ActualNode == null)
				ActualNode = gm.nm.GetFirstNode();
		}
		void OnPostSetUp(GameManager gm){}

		void OnGameOver (GameManager gm) {
			
			speed = 0.0f;
		}
		void OnGamePaused (GameManager gm) {
			Mov = false;
		}
		void OnGameResumed (GameManager gm) {
			Mov = true;
		}
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
				

				}
				actualNode = value;

			}
		}
	
	

		void Update(){
			if (Mov){
			if (ActualNode != null) {
			Movement ();

			}
			}
		}
	/// <summary>
	/// La pista si muove verso l'actual node
	/// </summary>
		public void Movement () {
			transform.position = Vector3.MoveTowards(this.transform.position,ActualNode.transform.position,speed);
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
