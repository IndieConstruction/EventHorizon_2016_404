using UnityEngine;
using System.Collections;
namespace EH.Project404{
public class StartSceneSound : MonoBehaviour {
		FMOD_SoundManager soundManager;
	// Use this for initialization
	void Start () {
			soundManager = FindObjectOfType<FMOD_SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}
