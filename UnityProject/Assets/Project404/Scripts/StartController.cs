using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace EH.Project404{
public class StartController : MonoBehaviour {

		public void LoadLevelMenu () {
			SceneManager.LoadScene("MainMenu");
		}
		public void Exit () {
			Application.Quit();
		}
}
}