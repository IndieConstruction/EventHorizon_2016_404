using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class GameManager : MonoBehaviour {
		public RoadNode roadNode;
		public NodesManager nm;
		public SpawnController spawnC;
		public GameObject RoadContainer;
		public int RoadsOnStart =2;
		public bool Infinite = false;
		public int MaxRoadsInGame = 6;
		#region Events
		public delegate void GameEvent(GameManager gm);
		public static GameEvent OnPreSetUp;
		public static GameEvent OnSetUp;
		public static GameEvent OnPostSetUp;
		#endregion
		void Start () {
			PreSetUp();
			SetUp();
			PostSetUp();
		}
		/// <summary>
		/// Riempie tutte le referenze
		/// </summary>
		void PreSetUp () {
			nm = FindObjectOfType<NodesManager>();
			RoadContainer = GameObject.FindGameObjectWithTag("RoadContainer");
			spawnC = FindObjectOfType<SpawnController>();
			if (OnPreSetUp != null) {
				OnPreSetUp(this);
			}
		}

		void SetUp () {
			MaxRoadsInGame = MaxRoadsInGame - RoadsOnStart;
			for (int i = 0; i < RoadsOnStart; i++) {
				spawnC.RandomSpawnItems();
			}
			if (OnSetUp != null) {
				OnSetUp(this);
			}
			}
			

		void PostSetUp () {
			if (OnPostSetUp != null) {
				OnPostSetUp(this);
			}
		}
		void OnTriggerEnter (Collider other) {
			if (other.tag == "Road" && Infinite == false){
				
			
				if (MaxRoadsInGame > 0) {
					
					spawnC.RandomSpawnItems();
					MaxRoadsInGame--;
				}
				if (MaxRoadsInGame <= 0) {
					Debug.Log ("Fine");
				}
		
			
//				RoadNode roadNode = other.GetComponent<RoadNode>();
//				nm.RemoveNodes();
				Destroy(other.gameObject, 1.0f);

			}
			else if (other.tag == "Road" && Infinite == true) {
				Debug.Log("Infinito");
				spawnC.RandomSpawnItems();
				Destroy(other.gameObject, 5.0f);

			}

		}

}
}