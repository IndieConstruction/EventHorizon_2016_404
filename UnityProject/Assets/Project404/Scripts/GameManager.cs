using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace EH.Project404{
public class GameManager : MonoBehaviour {
		GameOverComponent gameOver;
		public RoadNode roadNode;
		public NodesManager nm;
		public SpawnController spawnC;
		public GameObject RoadContainer;
		public int RoadsOnStart =2;
		public bool Infinite = false;
		public int MaxRoadsInGame = 6;
		public string ActualLevel;

		#region PerfectLevel
		public int counterLev1;
		public int counterLev2;
		public int counterLev3;
		public int totGoldenBonus1;
		public int totGoldenBonus2;
		public int totGoldenBonus3;
		#endregion

		#region Events
		public delegate void GameEvent(GameManager gm);
		public static GameEvent OnPreSetUp;
		public static GameEvent OnSetUp;
		public static GameEvent OnPostSetUp;
		public static GameEvent OnGameOver;
		public static GameEvent OnGamePaused;
		public static GameEvent OnGameResumed;

		#endregion

		FMOD_SoundManager soundManager;

		void Start () {
			PreSetUp();
			SetUp();
			PostSetUp();
		}
		/// <summary>
		/// Riempie tutte le referenze
		/// </summary>
		void PreSetUp () {
			soundManager = FindObjectOfType< FMOD_SoundManager>();
			gameOver = FindObjectOfType<GameOverComponent>();
			gameOver.gameManager = this;
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
			if (Infinite == false)
			spawnC.SpawnFinalRoad ();
			if (OnSetUp != null) {
				OnSetUp(this);
			}
			}
			

		void PostSetUp () {
			if (OnPostSetUp != null) {
				OnPostSetUp(this);
			}
		}

	public void GameOver () {
			gameOver.SetWindowVisible(true);

			if (OnGameOver != null)
				OnGameOver(this);
			
		}

		public void GamePaused () {
			gameOver.State = GameOverComponent.GameOverState.Paused;
			gameOver.SetWindowVisible(true);

			if (OnGamePaused !=null)
				OnGamePaused (this);
			
		}
		public void GameResumed () {
			if (OnGameResumed !=null)
				OnGameResumed(this);	
			gameOver.SetWindowVisible(false);
		}
//		public void InfiniteGame () {
//			Infinite = true;
//			SceneManager.LoadScene("InfiniteGame");
//		}
		void OnTriggerEnter (Collider other) {
			if (other.tag == "Road" && Infinite == false){
				
			
				if (MaxRoadsInGame > 0) {
					
					spawnC.RandomSpawnItems();
					MaxRoadsInGame--;
				}
				if (MaxRoadsInGame <= 0) {
					Debug.Log ("Fine");
				}

				Destroy(other.gameObject, 1.0f);

			}
			else if (other.tag == "Road" && Infinite == true) {
				
				spawnC.RandomSpawnItems();
				Destroy(other.gameObject, 30.0f);
				Debug.Log("INFINITO");
			}

		}
		/// <summary>
		/// Restarts the level.
		/// </summary>
		public void RestartLevel (string ActualLevel) {
			switch (ActualLevel) {
			case "0":
				SceneManager.LoadScene("LevelZero");
			
				break;
			case "1":
				SceneManager.LoadScene("GameScene");

				break;
			case "2":
				SceneManager.LoadScene("LevelTwo");

				break;
			case "3":
				SceneManager.LoadScene("LevelThree");

				break;
			}

		}
		void Update () {
			if (Input.GetKey(KeyCode.Escape)){
				GamePaused();
			}
		}

		public void GoldenBonus(){
			
		//controllare in che livello si trova

			// aumenta il contatore del livello attuale
			switch (ActualLevel) {
			case "1":
				counterLev1++;
				break;
			case "2":
				counterLev2++;
				break;
			case "3":
				counterLev3++;
				break;
			default:
				break;
			}
		}
}
}