using UnityEngine;
using System.Collections;

namespace EH.Project404{
	public class InputController : MonoBehaviour {


		// Update is called once per frame
		void FixedUpdate () {
			Move ();


		}

		//movimento della sfera
		public void Move () {
			float speed = 4.0f;
			// Input
			float translationX = Input.GetAxisRaw("Horizontal") * speed;
			// Traduce in mov
			float pos = transform.position.x;
			if (pos >= -8 && pos <= 8){
				translationX *= Time.deltaTime;
				transform.Translate(translationX, 0, 0);
			
			}
			if (pos <= -8)
				transform.position = new Vector3 (-7.999f, transform.position.y, transform.position.z);
			if (pos >= 8)
				transform.position = new Vector3 (7.999f, transform.position.y, transform.position.z);
			}

		}

	}



