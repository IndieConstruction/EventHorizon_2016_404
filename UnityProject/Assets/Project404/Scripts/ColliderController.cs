using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class ColliderController : MonoBehaviour {



	void OnTriggerEnter (Collider other) {

	Player p = gameObject.GetComponentInParent<Player>();
	

		IEffector effector = other.gameObject.GetComponent<IEffector>();
			if (effector != null) {
			effector.ApplyEffect(p);
			}
			else {
				Debug.Log("ho incontrato un non ieffector");
			}



		}

	}
}
