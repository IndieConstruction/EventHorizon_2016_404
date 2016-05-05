using UnityEngine;
using System.Collections;

namespace EH.Project404{
public class Player : MonoBehaviour {
		Animator animator;
		public int PlayerDimension;
		public int MaxPlayerDimension =5;
		public int MinPlayerDimension=1;
		public float JumpSpeed = 450;
		Rigidbody rb;
		public int BonusCounter;
		public int BonusStadio1;
		public int BonusStadio2;
		public int BonusStadio3;
		public int BonusStadio4;
		public int BonusStadio5;

		public MovementController road;

	

		// Use this for initialization
	void Start () {
			rb = gameObject.GetComponentInChildren<Rigidbody> ();
			PlayerDimension = 1;
			BonusCounter = 0;
			animator = GetComponentInChildren<Animator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
			Move ();
			if (Input.GetKeyDown(KeyCode.Space)) {


				BonusCounter = BonusCounter -1;
				if (PlayerDimension <= MinPlayerDimension){
					PlayerDimension=MinPlayerDimension;
				}
//				Vector3 vector = new Vector3(0.1f, 0.1f, 0.1f);
				ModifyScale ();
			}
			if (PlayerDimension>=MaxPlayerDimension){
				PlayerDimension= MaxPlayerDimension;
			}
			if (BonusCounter<=0){
				BonusCounter=0;
			}


	}

		//movimento della sfera
	void Move () {
			float speed = 4.0f;

			float translationX = Input.GetAxisRaw("Horizontal") * speed;
			//translationZ *= Time.deltaTime;
			translationX *= Time.deltaTime;
			
			transform.Translate(translationX, 0, 0);
			//transform.Rotate (Vector3.right * Time.deltaTime * speed *10);
	
		}
	
		void OnTriggerEnter ( Collider other ) {




		}
		/// <summary>
		/// The minimum permitted dimension.
		/// </summary>
		public float MinPermittedDimension =1;
		public void ModifyScale () {
			if (transform.localScale.x < MinPermittedDimension){
				return;
			}



		
			
			if (BonusCounter <= BonusStadio1) {
				
				return;
			}
			if (BonusCounter > BonusStadio1 && BonusCounter <=BonusStadio2) {
				
				transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				PlayerDimension =1;
			}
			else if (BonusCounter >BonusStadio2 && BonusCounter <=BonusStadio3) {
				
				transform.localScale = new Vector3 (1.6f, 1.6f, 1.6f);
				PlayerDimension =2;
			}
			else if (BonusCounter >BonusStadio3 && BonusCounter <=BonusStadio4) {
				
				transform.localScale = new Vector3 (1.9f, 1.9f, 1.9f);
				PlayerDimension =3;
			}
			else if (BonusCounter >BonusStadio4 && BonusCounter <=BonusStadio5) {
				
				transform.localScale = new Vector3 (2.2f, 2.2f, 2.2f);
				PlayerDimension =4;
			}

		}
		public void Falling () {
			rb.useGravity = true;
			Debug.Log("gravity");
		}
		public void Jump () {
			animator.SetTrigger("Jump");

		}

	}
}


