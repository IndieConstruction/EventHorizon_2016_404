using UnityEngine;
using System.Collections;
namespace EH.Project404{

	public class YouWin : MonoBehaviour, IEffector {
		public Transform pareteStatica;
		public Transform pareteAnimata;

		public Animation animation;
		public GameManager gm;

		public GameOverComponent gameover;

		void OnEnable () {
			gm = FindObjectOfType<GameManager>();
			gameover = FindObjectOfType<GameOverComponent>();
			GameManager.OnPreSetUp += OnPreSetUp;
		}
		void OnDisable () {

			GameManager.OnPreSetUp += OnPreSetUp;
		}
		void OnPreSetUp (GameManager gameM) {

		


		}
		public void ApplyEffect(Player p ){
			
			pareteStatica.gameObject.SetActive(false);
			animation.Play();
			gameover.State = GameOverComponent.GameOverState.Win;

			gm.GameOver();
		}

	}
}