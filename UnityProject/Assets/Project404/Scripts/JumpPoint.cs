using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class JumpPoint : MonoBehaviour,IEffector {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		public void ApplyEffect(Player p ){
			Debug.Log("eseguo l'effetto del Jumppoint");
			if (p.PlayerDimension <=2){
				p = p.GetComponent<Player> ();
				p.Jump();
		}
			else {
				Debug.Log("Inaspettato");
			}
		}

}
}
