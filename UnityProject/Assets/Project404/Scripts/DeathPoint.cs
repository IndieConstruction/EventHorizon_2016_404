using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class DeathPoint : MonoBehaviour, IEffector {
		public GameManager gm;
	
		GameOverComponent gameover;

		void OnEnable () {
			gameover = FindObjectOfType<GameOverComponent>();
			gm = FindObjectOfType<GameManager> ();

		}
	
		public void ApplyEffect(Player p ){
			
			p.soundMan.Blob_FallDead();
			gameover.State = GameOverComponent.GameOverState.Lost;
				Destroy (p.gameObject);
				gm.GameOver();
		
				
		}

}
}