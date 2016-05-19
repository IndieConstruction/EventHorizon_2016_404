using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class ColliderController : MonoBehaviour {


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void OnTriggerEnter (Collider other) {

	Player p = gameObject.GetComponentInParent<Player>();
	

		IEffector effector = other.gameObject.GetComponent<IEffector>();
			if (effector != null) {
			effector.ApplyEffect(p);
			}
			else {
				Debug.Log("ho incontrato un non ieffector");
			}


	// se collide con il bonus, il player aumenta di dimensione e il bonus scompare
//			Bonus b = other.gameObject.GetComponent<Bonus> ();
//				if (b != null && jumpPoint==null) {
//					transform.localScale += new Vector3 (0.3f, 0.3f, 0.3f);
//							
//							Destroy (b.gameObject);
//						}
		}

	}
}
