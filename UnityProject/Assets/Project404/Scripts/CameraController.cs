using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class CameraController : MonoBehaviour { 
		public bool Mov = true;
		MovementController movementC;
		public MovementController mc;
		//public float speed= 0.3f;
		void OnEnable () {
			movementC = FindObjectOfType<MovementController>();
			GameManager.OnGameOver += OnGameOver;
			GameManager.OnGamePaused += OnGamePaused;
			GameManager.OnGameResumed += OnGameResumed;
		}
		void OnDisable () {

			GameManager.OnGameOver += OnGameOver;
		}
		void Update () {
			if (Mov){
			if (mc.ActualNode != null)
				transform.position = Vector3.MoveTowards(this.transform.position,mc.ActualNode.transform.position,movementC.speed);
			}
		}
		void OnGameOver (GameManager gm) {movementC.speed =0.0f;}

		void OnGamePaused (GameManager gm) {Mov = false;}
		void OnGameResumed (GameManager gm) {Mov = true;}
}
}