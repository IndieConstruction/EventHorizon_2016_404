using UnityEngine;
using System.Collections;
namespace EH.Project404{
	
	public class Falling : MonoBehaviour,IEffector {
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		public void ApplyEffect(Player p ){
		

				p = p.GetComponent<Player> ();
				p.Falling();
			

		}
		
	}
}