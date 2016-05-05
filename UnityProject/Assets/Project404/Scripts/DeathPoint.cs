using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class DeathPoint : MonoBehaviour, IEffector {
		public void ApplyEffect(Player p ){
			Debug.Log("eseguo l'effetto del Burrone");
		
				
				Destroy (p.gameObject);
			Application.LoadLevel(Application.loadedLevel);
			
		}

}
}