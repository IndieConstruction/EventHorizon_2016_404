using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace EH.Project404{
	public class GameOverComponent : MonoBehaviour {
		public GameManager gameManager;
		public delegate void GameOverEvent(string LevelName);
		public static GameOverEvent OnLevelCompleted;
		public static GameOverEvent OnLevelPerfect;
		private bool isActive;
	
		bool IsActive {
			get{ return isActive; }
			set{ 
				
				if (isActive != value){
					if (State == GameOverState.Lost){
						TitleText.text = "GAME OVER";

						NextLevel.gameObject.SetActive(false);
						ReStart.gameObject.SetActive(true);
						Resume.gameObject.SetActive(false);
						Exit.gameObject.SetActive(true);
						BackToMenu.gameObject.SetActive(true);
					} 
					if (State ==GameOverState.Win){
						TitleText.text = "You Win!!";
						if (gameManager.ActualLevel != "3")
						NextLevel.gameObject.SetActive(true);
						else {
							NextLevel.gameObject.SetActive(false);	
						}

						ReStart.gameObject.SetActive(true);
						Resume.gameObject.SetActive(false);
						Exit.gameObject.SetActive(true);
						BackToMenu.gameObject.SetActive(true);
						if (OnLevelCompleted !=null)
							OnLevelCompleted(gameManager.ActualLevel);
						//controllo del perfect
						if (gameManager.counterLev1 == gameManager.totGoldenBonus1 && gameManager.ActualLevel =="1"){
							if (OnLevelPerfect !=null)
								OnLevelPerfect("1");
						}
						if (gameManager.counterLev2 == gameManager.totGoldenBonus2 && gameManager.ActualLevel =="2"){
							if (OnLevelPerfect !=null)
								OnLevelPerfect("2");
						}
						if (gameManager.counterLev3 == gameManager.totGoldenBonus3 && gameManager.ActualLevel =="3"){
							if (OnLevelPerfect !=null)
								OnLevelPerfect("3");
						}

					}
					if (State ==GameOverState.Paused){
						
						TitleText.text = "Pausa";
						Resume.gameObject.SetActive(true);
						NextLevel.gameObject.SetActive(false);
						ReStart.gameObject.SetActive(true);
						Exit.gameObject.SetActive(true);
						BackToMenu.gameObject.SetActive(true);
					}

					isActive = value;
					GetComponent<Animator>().SetBool("IsActive", isActive);
				}

			}
		}

		public Text TitleText; 
		public Button NextLevel;
		public Button ReStart;
		public Button Resume;
		public Button Exit;
		public Button BackToMenu;
		public enum GameOverState {Win, Lost, Paused}
		public GameOverState State;

		


		/// <summary>
		/// Sets the window visible.
		/// </summary>
		/// <param name="_visible">If set to <c>true</c> visible.</param>
		public void SetWindowVisible (bool _visible) {
			IsActive = _visible;
		}

		public void LoadLevelMenu () {
			SceneManager.LoadScene("MainMenu");
		}
		public void ExitGame () {
			Application.Quit();
		}

		public void Back () {
			SceneManager.LoadScene("StartScene");

		}
		public void LoadNextLevel () {
			if (gameManager.ActualLevel == "0")
			SceneManager.LoadScene("GameScene");
			if (gameManager.ActualLevel == "1")
				SceneManager.LoadScene("LevelTwo");
			if (gameManager.ActualLevel == "2")
				SceneManager.LoadScene("LevelThree");
			
		}


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

		}
	}

}