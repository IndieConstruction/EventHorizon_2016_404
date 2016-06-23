using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace EH.Project404{
public class LevelManager : MonoBehaviour {
	public bool Level0UnLocked = true;
	public bool LevelOneUnLocked = false;
	public bool LevelTwoUnLocked = false;
	public bool LevelThreeUnLocked = false;
	public bool InfiniteUnLocked = false;

		public bool LevOnePerfect = false;
		public bool LevTwoPerfect = false;
		public bool LevThreePerfect = false;

	void OnEnable () {
			GameOverComponent.OnLevelCompleted +=  OnLevelCompleted;
			GameOverComponent.OnLevelPerfect += OnLevelPerfect;

	}

		void Awake () {
			DontDestroyOnLoad(this);
			LoadLevelProgression();
		}

	
	
		void OnLevelCompleted (string LevelID) {
			switch (LevelID) {
			case "0":
				LevelOneUnLocked = true;
				break;
			case "1":
				LevelTwoUnLocked = true;
				break;
			case "2":
				LevelThreeUnLocked = true;
				break;
			
			default:
				break;
			}
			SaveLevelProgression();
		}
		void OnLevelPerfect (string LevelID) {
			switch (LevelID) {
			case "1":
				LevOnePerfect = true;
				break;
			case "2":
				LevTwoPerfect = true;
				break;
			case "3":
				LevThreePerfect= true;
				break;

			default:
				break;
			}
			if (LevOnePerfect && LevTwoPerfect && LevThreePerfect)
				InfiniteUnLocked =true;
			
			SaveLevelProgression();
		}

		void SaveLevelProgression() {
			PlayerPrefs.SetInt("Level0UnLocked", Level0UnLocked == true ? 1 : 0);
			PlayerPrefs.SetInt("LevelOneUnLocked", LevelOneUnLocked == true ? 1 : 0);
			PlayerPrefs.SetInt("LevelTwoUnLocked", LevelTwoUnLocked == true ? 1 : 0);
			PlayerPrefs.SetInt("LevelThreeUnLocked",  LevelThreeUnLocked == true ? 1 : 0);
			PlayerPrefs.SetInt("InfiniteUnLocked", InfiniteUnLocked == true ? 1 : 0);
			PlayerPrefs.SetInt("LevOnePerfect",  LevOnePerfect == true ? 1 : 0);
			PlayerPrefs.SetInt("LevTwoPerfect",  LevTwoPerfect == true ? 1 : 0);
			PlayerPrefs.SetInt("LevThreePerfect",LevThreePerfect== true ? 1 : 0);
			PlayerPrefs.Save();

		}
		void LoadLevelProgression() {
			Level0UnLocked = PlayerPrefs.GetInt("Level0UnLocked",1) == 1 ? true : false;
			LevelOneUnLocked = PlayerPrefs.GetInt("LevelOneUnLocked",0) == 1 ? true : false;
			LevelTwoUnLocked = PlayerPrefs.GetInt("LevelTwoUnLocked",0) == 1 ? true : false;
			LevelThreeUnLocked = PlayerPrefs.GetInt("LevelThreeUnLocked",0) == 1 ? true : false;
			InfiniteUnLocked = PlayerPrefs.GetInt("InfiniteUnLocked", 0) == 1 ? true : false;
			LevOnePerfect = PlayerPrefs.GetInt("LevOnePerfect", 0) == 1 ? true : false;
			LevTwoPerfect = PlayerPrefs.GetInt("LevTwoPerfect", 0) == 1 ? true : false;
			LevThreePerfect = PlayerPrefs.GetInt("LevThreePerfect", 0) == 1 ? true : false;
		}

		void Update(){
			if(Input.GetKeyDown(KeyCode.E)){
				PlayerPrefs.DeleteAll();
			}

		}
		public void InfiniteGame () {
			
			SceneManager.LoadScene("InfiniteGame");
		}

		}

}

