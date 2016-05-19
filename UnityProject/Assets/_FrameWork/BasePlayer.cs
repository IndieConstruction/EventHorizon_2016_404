using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace EH.FrameWork {
public class BasePlayer : Agent {

	 Inventory inventory;

//	public bool isOver;
	public enum PlayerStates {
		Alive,
		Dead
	}

	private Rigidbody rb;
	public float exp;


	// richiama il metodo che setta i comportamenti di ogni stato solo quando necessario
	private PlayerStates currentPlayerState = PlayerStates.Alive; 
	public PlayerStates CurrentPlayerState {
		get{return currentPlayerState;}
		set{
			if (currentPlayerState != value){
				currentPlayerState = value;

				OnChangeState();

			}
			currentPlayerState = value;
		}
	}



	void Awake () {
		// Iscrizione all'evento GameController.OnGameStart
		rb = GetComponent<Rigidbody> ();

		inventory = GetComponentInChildren<Inventory>();
	}

	// Use this for initialization
	void Start () {

		currentPlayerState = PlayerStates.Alive;
		exp = 0;	 
		if (gc == null) {
			gc = FindObjectOfType<GameController> ();
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		UpdateHealth ();
		}
			
	/// <summary>
	/// Viene chiamata quando cambia il valore di CurrentAiState
	/// </summary>
	public void OnChangeState () {

		switch (CurrentPlayerState) {
		case PlayerStates.Alive:

		
			break;
		
		case PlayerStates.Dead:

		 


			break;
		

		}

		//gameController.PlayerChangedState ();
	}
	// aumenta l'esperienza del Player

	void OnTriggerEnter (Collider other){
		if(other.tag == "Finish"){
			gc.PlayerLevelCompleted();

		}


	}
	void UpgradeExp (float expUpgrader) {
		exp = exp + expUpgrader;
	}

	void UpdateHealth(){
		if(Health == 0 ){
			currentPlayerState = PlayerStates.Dead;
			OnDeath ();
		}
	}
	// aumenta di 1 il livello del Player
	void UpgradeLevel () {
		Level = Level + 1;
	}

	// Cosa succede quando il Player muore
	protected override void OnDeath ()
	{
		base.OnDeath ();
		currentPlayerState = PlayerStates.Dead;
	}
	/// <summary>
	/// Se esiste un'inventario te lo restituisco,altrimenti null
	/// </summary>
	/// <returns>The inventory.</returns>
	public Inventory GetInventory(){
		if (inventory != null) {
			return inventory;
		}
		else {
			return null;
		}
	} 
	/// <summary>
	/// Attack the specified hitpoint.
	/// </summary>
	/// <param name="hitpoint">Hitpoint.</param>

}
}