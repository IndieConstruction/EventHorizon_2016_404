using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EH.FrameWork {
public class ItemSpawner : MonoBehaviour {
	//	string levelName = "bonus";
		public List<IItem> Items = new List<IItem>();
		public Transform[] ItemsSpawnPoints; // array di spawnPoints
	// Use this for initialization
	void Start () {

//			// auto
//			for (int i = 0; i < 4; i++) {
//				// fa lo spawn 
//				GameObject g = Resources.Load<GameObject>(levelName + "/0 " + i);
//			
//				var goChecked = g.GetComponent<IItem>();
//				if ( goChecked != null) {
//					Items.Add(goChecked);
//				}
//			}

	}
	
	
	// Update is called once per frame
	void Update () {

	}
	/// <summary>
	/// Spawn the specified objectToSpawn in the positionToSpawn.
	/// </summary>
	/// <param name="objectToSpawn">Object to spawn.</param>
	/// <param name="positionToSpawn">Position to spawn.</param>
	public void Spawn(GameObject objectToSpawn, Vector3 positionToSpawn){
		Instantiate (objectToSpawn, positionToSpawn, objectToSpawn.transform.rotation);
			
		}
		/// <summary>
		/// Spawn Random degli Items
		/// </summary>
		public virtual void RandomSpawnItems (){

			// sceglie un indice a caso nella lista di  Items
			int randomItem = Random.Range(0, Items.Count -1);
			// assegna l'indice scelto al gameobject ItemToSpawn
			GameObject ItemToSpawn = Items[randomItem].ItemGameObject ;
			// sceglie un indice a caso nella lista di spawnPoint
			int randomIndex = Random.Range (0,ItemsSpawnPoints.Length -1);
			// assegna l'indice alla variabile spawnPosition
			Vector3 spawnPosition = ItemsSpawnPoints [randomIndex].position;
			// esegue lo spawn con i parametri ItemToSpawn e spawnPosition
			Spawn (ItemToSpawn,spawnPosition);
		}



}
		
}
/// <summary>
///interfaccia Item che contiene una funzione per la collisione, per riempire proprietà vedi Obstacle.cs
/// </summary>
namespace EH.FrameWork {
public interface IItem {
	 GameObject ItemGameObject {
		get;
		//set;
	}
	void OnTriggerEnter ( Collider other);
}
}