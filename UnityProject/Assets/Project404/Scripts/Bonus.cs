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

			//TODO Trasferire logica nel player e richiamare la funzione
			p.BonusCounter++;
			Destroy (this.gameObject);

			if (p.BonusCounter <= p.BonusStadio1) {

				return;
			}
			if (p.BonusCounter > p.BonusStadio1 && p.BonusCounter <=p.BonusStadio2) {

				p.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				p.PlayerDimension =1;
			}
			else if (p.BonusCounter >p.BonusStadio2 && p.BonusCounter <=p.BonusStadio3) {

				p.transform.localScale = new Vector3 (1.6f, 1.6f, 1.6f);
				p.PlayerDimension =2;
			}
			else if (p.BonusCounter >p.BonusStadio3 && p.BonusCounter <=p.BonusStadio4) {
				
				p.transform.localScale = new Vector3 (1.9f, 1.9f, 1.9f);
				p.PlayerDimension =3;
			}
			else if (p.BonusCounter >p.BonusStadio4 && p.BonusCounter <=p.BonusStadio5) {
				
				p.transform.localScale = new Vector3 (2.2f, 2.2f, 2.2f);
				p.PlayerDimension =4;
			}
			}

		
	
		}


}
