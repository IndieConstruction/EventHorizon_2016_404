using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace EH.Project404{

	public class MainMenuController : MonoBehaviour {
		LevelManager levelManager;
		public Button InfiniteButton;
		public Button Level0;
		public Button LevelOne;
		public Button LevelTwo;
		public Button LevelThree;
		void Start () {
			levelManager = FindObjectOfType<LevelManager>();
			LevelOne.interactable = levelManager.LevelOneUnLocked;
			LevelTwo.interactable = levelManager.LevelTwoUnLocked;
			LevelThree.interactable = levelManager.LevelThreeUnLocked;
			InfiniteButton.interactable = levelManager.InfiniteUnLocked;
			Level0.interactable = levelManager.Level0UnLocked;

		}

		public void LoadLevelMenu () {
			SceneManager.LoadScene("MainMenu");
		}
		public void Exit () {
			Application.Quit();
		}
		public void LoadFirstLevel () {
		
			SceneManager.LoadScene("GameScene");
		}
		public void Back () {
			SceneManager.LoadScene("StartScene");
		
		}
		public void LoadSecondLevel () {

			SceneManager.LoadScene("LevelTwo");
		}
		public void LoadThirdLevel () {

			SceneManager.LoadScene("LevelThree");
		}

		public void LoadTutorialLevel () {

			SceneManager.LoadScene("LevelZero");
		}

	}

}