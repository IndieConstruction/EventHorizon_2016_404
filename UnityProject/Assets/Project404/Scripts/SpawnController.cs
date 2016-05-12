using UnityEngine;
using System.Collections.Generic;
namespace EH.Project404{
public class SpawnController : MonoBehaviour {
		public NodesManager nm;
		public GameObject [] Roads;

		void Start () {

		}

		public void Spawn(GameObject objectToSpawn, Vector3 positionToSpawn){
			GameObject newGO = Instantiate (objectToSpawn, positionToSpawn, objectToSpawn.transform.rotation) as GameObject;
			//TODO Spostare newGO.transform sotto RoadContainer
//			newGO.transform.SetParent(hhh);
			List<RoadNode> nodesToAdd = new List<RoadNode>(); 
			foreach (var item in newGO.GetComponentsInChildren<RoadNode>()) {
				nodesToAdd.Add(item);
			}	
			nm.AddNodes(nodesToAdd);
		}
		void RandomSpawnItems (){
		

			int randomItem = Random.Range(0, Roads.Length);
		
			GameObject ItemToSpawn = Roads [randomItem];
		
			//Spawn (ItemToSpawn,spawnPosition);
		}

}
}