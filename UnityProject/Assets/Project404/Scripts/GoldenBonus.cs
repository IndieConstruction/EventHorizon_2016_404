using UnityEngine;
using System.Collections;
namespace EH.Project404{
	public class GoldenBonus : MonoBehaviour, IEffector {

		public void ApplyEffect (Player p){
			p.gameMan.GoldenBonus();
			Destroy(gameObject);
		}
	}
}
