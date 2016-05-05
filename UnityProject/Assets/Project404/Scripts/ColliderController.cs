using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class ColliderController : MonoBehaviour {

		Player p;

	// Use this for initialization
	void Start () {
			 p = gameObject.GetComponentInParent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void OnTriggerEnter (Collider other) {

	
	

		IEffector effector = other.gameObject.GetComponent<IEffector>();
			if (effector != null) {
			effector.ApplyEffect(p);
			}
		

				
			}

		}

	}

