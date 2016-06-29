using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class Malus : MonoBehaviour,IEffector   {
		GameManager gm;
		public int MalusDimension;
	
		FMOD_SoundManager soundManager;
		GameOverComponent gameover;

		void OnEnable () {
			gameover = FindObjectOfType<GameOverComponent>();
			gm = FindObjectOfType<GameManager> ();
			soundManager = FindObjectOfType<FMOD_SoundManager>();

		}

		public void ApplyEffect(Player p ){

			if (p.PlayerDimension >= MalusDimension) {
				ObjectDestroySound();
				Destroy (this.gameObject);

			}
			else if (p.PlayerDimension < MalusDimension) {
				ObjectCollisionSound();
				soundManager.Blob_SplatDead(p.PlayerDimension);
				gameover.State = GameOverComponent.GameOverState.Lost;
				Destroy (p.gameObject);
				gm.GameOver ();
			}

		}

		void ObjectCollisionSound()
		{
			if(this.gameObject.tag == "Ancora"){
				//SUONA IL SUONO DELL'ANCORA
				soundManager.Anchor_Hit();
			}
			else if(this.gameObject.tag == "Anfora"){
				//SUONA IL SUONO DELL'ANFORA
				soundManager.Urn_Hit();
			}
			else if(this.gameObject.tag == "Corallo"){
				//SUONA IL SUONO DEL CORALLO
				soundManager.Coral_Green_Hit();
			}

		}


		void ObjectDestroySound()
		{
			if(this.gameObject.tag == "Ancora"){
				//SUONA IL SUONO DELL'ANCORA
				soundManager.Anchor_Destroyed();
			}
			else if(this.gameObject.tag == "Anfora"){
				//SUONA IL SUONO DELL'ANFORA
				soundManager.Urn_Destroyed();
			}
			else if(this.gameObject.tag == "Corallo"){
				//SUONA IL SUONO DEL CORALLO
				soundManager.Coral_Green_Destroyed();
			}

		}
	
}
}