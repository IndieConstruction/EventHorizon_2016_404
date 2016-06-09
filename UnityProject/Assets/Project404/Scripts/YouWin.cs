using UnityEngine;
using System.Collections;
namespace EH.Project404{

	public class YouWin : MonoBehaviour, IEffector {
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
			

			gameover.State = GameOverComponent.GameOverState.Win;
			gm.GameOver();
		}

	}
}