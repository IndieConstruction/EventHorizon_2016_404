using UnityEngine;
using System.Collections;

namespace EH.Project404{
public class Player : MonoBehaviour {
		
		public GameManager gameMan;
		public MovementController movementC;
		public bool Alive = true;
		Animator animator;
		public int PlayerDimension =1;
		public int MaxPlayerDimension;
		public int MinPlayerDimension;
		public float JumpSpeed = 450;
		Rigidbody rb;
		public int BonusCounter;
		public int BonusStadio1;
		public int BonusStadio2;
		public int BonusStadio3;
		public int BonusStadio4;
		public int BonusStadio5;
		public float SpeedStadio1;
		public float SpeedStadio2;
		public float SpeedStadio3;
		public float SpeedStadio4;
		public float SpeedStadio5;

		// blob graphic
		public Transform blob;

		void OnEnable (){
			GameManager.OnPreSetUp += PreSetUp;
		}
	// Use this for initialization
	void Start () {
			BonusEffect();
			rb = gameObject.GetComponentInChildren<Rigidbody> ();
			PlayerDimension = 1;
			BonusCounter = 0;
			animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (BonusCounter <= 0){
					BonusCounter = 0;
					return;
				}
				BonusCounter --;
				BonusEffect();
				if (PlayerDimension <= MinPlayerDimension){
					PlayerDimension=MinPlayerDimension;
				}
				Vector3 vector = new Vector3(0.1f, 0.1f, 0.1f);
				ModifyScale (vector);
			}
			if (PlayerDimension>=MaxPlayerDimension){
				PlayerDimension= MaxPlayerDimension;
			}

	}

		void PreSetUp (GameManager gameManager) {
			gameMan = gameManager; 
		}

		//movimento della sfera


		/// <summary>
		/// The minimum permitted dimension.
		/// </summary>
		public float MinPermittedDimension =1;
		void ModifyScale (Vector3 vector) {
			if (transform.localScale.x <= MinPermittedDimension){
				return;
			}
			vector = new Vector3(0.1f, 0.1f, 0.1f);
			transform.localScale -= vector;

		}
		public void Falling () {
			rb.useGravity = true;
			Debug.Log("gravity");
		}
		public void Jump () {
			animator.SetTrigger("Jump");

		}
		public void BonusEffect(){
			if (BonusCounter <= BonusStadio1) {

				return;
			}
			if (BonusCounter <=BonusStadio2) {
				// Stadio 1
				transform.localScale = new Vector3 (1, 1, 1);
				blob.position = new Vector3 ( blob.position.x, -0.5f,blob.position.z);
				PlayerDimension =1;
				movementC.speed = SpeedStadio1;
			}
			else if (BonusCounter >BonusStadio2 && BonusCounter <=BonusStadio3) {
				// Stadio 2
				transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				blob.position = new Vector3 ( blob.position.x, -0.4f,blob.position.z);
				PlayerDimension =2;
				movementC.speed = SpeedStadio2;
			}
			else if (BonusCounter >BonusStadio3 && BonusCounter <=BonusStadio4) {
				// Stadio 3
				blob.position = new Vector3 ( blob.position.x, -0.4f,blob.position.z);
				transform.localScale = new Vector3 (1.6f, 1.6f, 1.6f);
				PlayerDimension =3;
				movementC.speed = SpeedStadio3;
			}
			else if (BonusCounter >BonusStadio4 && BonusCounter <=BonusStadio5) {
				// Stadio 4
				blob.position = new Vector3 ( blob.position.x, -0.35f,blob.position.z);
				transform.localScale = new Vector3 (1.9f, 1.9f, 1.9f);
				PlayerDimension =4;
				movementC.speed = SpeedStadio4;
			}
			else if (BonusCounter > BonusStadio5) {
				// Stadio 5
				blob.position = new Vector3 ( blob.position.x, -0.3f,blob.position.z);
				transform.localScale = new Vector3 (2.2f, 2.2f, 2.2f);
				PlayerDimension =5;
				movementC.speed = SpeedStadio5;
			}
		}
	}
}


