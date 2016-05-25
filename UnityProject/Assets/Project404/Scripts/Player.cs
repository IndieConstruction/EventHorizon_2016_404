using UnityEngine;
using System.Collections;

namespace EH.Project404{
public class Player : MonoBehaviour {
		public bool Alive = true;
		Animator animator;
		public int PlayerDimension;
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
				PlayerDimension --;
				BonusCounter =0;
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
	}
}


