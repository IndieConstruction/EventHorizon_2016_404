using UnityEngine;
using System.Collections.Generic;
namespace EH.Project404{
public class SpawnController : MonoBehaviour {
		public NodesManager nm;
		public MovementController mc;
		public GameObject [] Roads;
		public Vector3 spawnPosition;
		void Start () {
			RandomSpawnItems ();
		}

		public void Spawn(GameObject objectToSpawn, Vector3 positionToSpawn){
			GameObject newGO = Instantiate (objectToSpawn, positionToSpawn, objectToSpawn.transform.rotation) as GameObject;
			//la pista spawnata diventa figlia di RoadContainer
			newGO.transform.SetParent (mc.transform);

			List<RoadNode> nodesToAdd = new List<RoadNode>(); 
			foreach (var item in newGO.GetComponentsInChildren<RoadNode>()) {
				nodesToAdd.Add(item);
			}	
			nm.AddNodes(nodesToAdd);
		}

	public	void RandomSpawnItems (){
		

			int randomItem = Random.Range(0, Roads.Length);
		
			GameObject ItemToSpawn = Roads [randomItem];
		
			Spawn (ItemToSpawn,spawnPosition);
		}

}
}