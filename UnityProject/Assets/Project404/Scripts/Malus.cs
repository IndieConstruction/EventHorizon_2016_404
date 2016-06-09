using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class Malus : MonoBehaviour,IEffector   {
		GameManager gm;
		public int MalusDimension;
	

		GameOverComponent gameover;

		void OnEnable () {
			gameover = FindObjectOfType<GameOverComponent>();
			gm = FindObjectOfType<GameManager> ();

		}

		public void ApplyEffect(Player p ){
			Debug.Log("eseguo l'effetto del Malus");
			if (p.PlayerDimension >= MalusDimension) {
				
				Destroy (this.gameObject);

			}
			else if (p.PlayerDimension < MalusDimension) {
				gameover.State = GameOverComponent.GameOverState.Lost;
				Destroy (p.gameObject);
				gm.GameOver ();
			}

		}

	
}
}