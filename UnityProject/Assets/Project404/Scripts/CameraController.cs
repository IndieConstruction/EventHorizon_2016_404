using UnityEngine;
using System.Collections;
namespace EH.Project404{

public class CameraController : MonoBehaviour { 
		public MovementController mc;

		void Update () {
			if (mc.ActualNode != null)
			transform.position = Vector3.MoveTowards(this.transform.position,mc.ActualNode.transform.position,0.3f);
		}

}
}