using UnityEngine;
using System.Collections;
namespace EH.Project404{

	public class TubeEffect : MonoBehaviour,IEffector {
		public GameManager gm;

		GameOverComponent gameover;

		void OnEnable () {
			gameover = FindObjectOfType<GameOverComponent>();
			gm = FindObjectOfType<GameManager> ();

		}
	
		public void ApplyEffect(Player p ){
			
			if (p.PlayerDimension <=2){
				p = p.GetComponent<Player> ();
				return;
			}
			else {
				gameover.State = GameOverComponent.GameOverState.Lost;
				Destroy (p.gameObject);
				gm.GameOver();
			}
		}

	}
}