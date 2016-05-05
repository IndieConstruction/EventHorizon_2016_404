using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace EH.FrameWork{

public class HudManager : MonoBehaviour {

	Text[] texts ;
	public Text Health;
	public Text NpcToFree;
	public Text Exp;
	// Use this for initialization
	public GameController gc;
	//public NPC npc;
	public BasePlayer p;
	bool isEnable;
	void Awake(){

		texts = GetComponentsInChildren<Text>(); 
		Health = texts [1];
		NpcToFree = texts [2];
		Exp = texts [3];
		GameController.OnGameOver += HandleOnGameOver;
		GameController.OnGameWin += HandleOnGameWin;
		GameController.OnNextLevel += HandleOnNextLevel;
		GameController.OnLoadLevelComplete += HandleOnLoadLevelComplete;
	}
	

	void Start () {

	}

	void Update () {
	if (isEnable) {
		UpdateHud ();
		}
	}

	void HandleOnLoadLevelComplete ()
	{
		isEnable = true;
		gameObject.GetComponentInChildren<Text>().text = "Level" + gc.Level;
		gameObject.GetComponentInChildren<Text> ().enabled = true; 
	}
	void HandleOnGameOver ()
	{
		gameObject.GetComponentInChildren<Text>().text = "GameOver";
		gameObject.GetComponentInChildren<Text> ().enabled = true;
	}

	void HandleOnGameWin ()
	{
		gameObject.GetComponentInChildren<Text>().text = "YouWin";
		gameObject.GetComponentInChildren<Text> ().enabled = true;
	}

	void HandleOnNextLevel ()
	{
		isEnable = false;
		gameObject.GetComponentInChildren<Text>().text = "New Level ";
		gameObject.GetComponentInChildren<Text> ().enabled = true;
	}
	void UpdateHud (){
		Health.text = "Health : " + p.Health ;
		
		Exp.text = "Experience : " + p.exp;
	}
	void OnDisable() {
		GameController.OnGameOver -= HandleOnGameOver;
		GameController.OnGameWin -= HandleOnGameWin;
		GameController.OnNextLevel -= HandleOnNextLevel;
	}
}
}