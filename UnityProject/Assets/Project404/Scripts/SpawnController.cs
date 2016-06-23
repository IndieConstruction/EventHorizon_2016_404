using UnityEngine;
using System.Collections.Generic;
namespace EH.Project404{
public class SpawnController : MonoBehaviour {
		public NodesManager nm;
		public MovementController mc;
		public GameObject [] Roads;
		public Transform spawnPosition;
		public GameObject RoadContainer;
		public GameObject FinalRoad;
		void OnEnable () {
			GameManager.OnPreSetUp += OnPreSetUp;
	
		}
		void OnDisable () {
			GameManager.OnPreSetUp -= OnPreSetUp;
	
		}
		void OnPreSetUp(GameManager gm){

			RoadContainer = gm.RoadContainer;
		}

		public Transform Spawn(GameObject objectToSpawn, Transform positionToSpawn){


			GameObject newGO = Instantiate (objectToSpawn, positionToSpawn.position, objectToSpawn.transform.rotation) as GameObject;
			
			//la pista spawnata diventa figlia di RoadContainer.
			newGO.transform.SetParent (RoadContainer.transform);

			// aggiunge i nodi ad una lista e li rende figli del NodeManager.
			List<RoadNode> nodesToAdd = new List<RoadNode>(); 
			foreach (var item in newGO.GetComponentsInChildren<RoadNode>()) {
				nodesToAdd.Add(item);
				//item.transform.SetParent (nm.transform);

			}	


			nm.AddNodes(nodesToAdd);
			return nm.nodes[nm.nodes.Count -1].transform;

		}
		/// <summary>
		/// Spawna un prefab Road random dall'array di Roads.
		/// </summary>
	public	void RandomSpawnItems (){

		int randomItem = Random.Range(0, Roads.Length);
		
		GameObject ItemToSpawn = Roads [randomItem];


		spawnPosition =	Spawn (ItemToSpawn, spawnPosition);


		}
	
		public void SpawnFinalRoad(){
			spawnPosition = Spawn (FinalRoad, spawnPosition);
		}
}
}