using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class DeathPoint : MonoBehaviour, IEffector {
		public GameManager gm;

		public void ApplyEffect(Player p ){
			Debug.Log("eseguo l'effetto del Burrone");
		
			p.Alive = false;
				Destroy (p.gameObject);
			gm.GameOver();
			//Application.LoadLevel(Application.loadedLevel);

			
		}

}
}