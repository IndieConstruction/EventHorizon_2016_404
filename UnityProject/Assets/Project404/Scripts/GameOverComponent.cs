using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace EH.Project404{
public class GameOverComponent : MonoBehaviour {
	
		private bool isActive;
	
		bool IsActive {
			get{ return isActive; }
			set{ 
				
				if (isActive != value){
					if (State == GameOverState.Lost){
						TitleText.text = "You Lost!!";
						NextLevel.gameObject.SetActive(false);
						ReStart.gameObject.SetActive(true);
					} 
					else{
						TitleText.text = "You Win!!";
						NextLevel.gameObject.SetActive(true);
						ReStart.gameObject.SetActive(false);
					} 
				GetComponent<Animator>().SetBool("IsAcTive", isActive);
				}
				isActive = value;
			}
		}

	public Text TitleText; 
	public Button NextLevel;
	public Button ReStart;
	public enum GameOverState {Win, Lost}
	public GameOverState State;


	//Logica
	public void SetWindowVisible (bool _visible) {
			IsActive = _visible;
		}
}

}