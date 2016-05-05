using UnityEngine;
using System.Collections;


namespace EH.FrameWork {
public class Agent : MonoBehaviour {



	public GameController gc;
	/// <summary>
	/// Speed of movement
	/// </summary>

	public string Name = "NoName";
	public float MoveSpeed;
	public float Health;
	public int Level = 1;

/// <summary>
/// La salute massima è moltiplicata per il livello 
/// </summary>
	private float maxHealth =10;
	public float MaxHealth{
		get {
			return maxHealth;
		}
		set {
			maxHealth = maxHealth*Level;
			maxHealth = value;

		}
	}

	void Awake () {
		if (gc == null) {
			gc = FindObjectOfType<GameController>();
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	 void Update () {
	 
	}

	/// <summary>
	/// Aggiorna il valore della speed attuale (moveSpeed) sommando il valore del parametro di entrate
	/// </summary>
	/// <param name="peedToAddOrRemove">Valore da aggiungere (se è negativo si sottrae).</param>

	public void UpdateSpeed (float SpeedToAddOrRemove) {
		MoveSpeed = MoveSpeed + SpeedToAddOrRemove;
		// per non fare andare la velocità in negativo 
		if (MoveSpeed<=0) { 
			MoveSpeed = 0;
		}
	}
	/// <summary>
	/// Attacks me.
	/// </summary>
	/// <param name="damage">Damage ( che è uguale all'attacco dell'Agent )</param>
	public void DecreaseHealth (float damage) {

		Health = Health - damage;

		if (Health <= 0){

			OnDeath();
		}

	}


	// fai qualcosa quando muori
	protected virtual void OnDeath () {

	}


	}
}


