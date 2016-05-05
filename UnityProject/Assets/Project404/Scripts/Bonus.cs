using UnityEngine;
using System.Collections;
using EH.FrameWork;
namespace EH.Project404{
public class Bonus : MonoBehaviour, IItem, IEffector {
		 
	// Use this for initialization
	void Start () {
		
			
			if (bonus == null) {
				bonus = this.gameObject.GetComponent<GameObject>();
			}
		}

		GameObject bonus;
		public GameObject ItemGameObject {
			get{
				return bonus;
			}
		}

		public void OnTriggerEnter ( Collider other){

		}
	
		public void ApplyEffect(Player p ){
			p.BonusCounter++;
			p.ModifyScale ();
			Destroy(gameObject);
			}
		void Update(){
			//Movement ();
		}
		
//		public void Movement () {
//			float speed =15;
//			transform.Translate (Vector3.right* Time.deltaTime * speed);
//		}
		}


}
