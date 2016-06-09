using UnityEngine;
using System.Collections;
using EH.FrameWork;
namespace EH.Project404{
public class Bonus : MonoBehaviour, IItem, IEffector {
		
	
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
			Destroy (this.gameObject);
			p.BonusEffect();

			}

		void Update () {
			transform.RotateAround (transform.position, Vector3.up, 1.0f);
		}
	
		}


}
