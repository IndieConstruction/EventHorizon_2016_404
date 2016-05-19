using UnityEngine;
using System.Collections;
namespace EH.FrameWork{
/// <summary>
/// Conferisce la capacità al player di emettere suoni
/// </summary>
public class SoundController : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip BonusTaken;
	public AudioClip Followed;
	public AudioClip Blocked;
	public AudioClip Free;
	public AudioClip GameOver;
	public AudioClip Win;
	public AudioClip NextLevel;
	public Sounds DefaultSound;

	void Awake () {
		GameController.OnGameOver += HandleOnGameOver;
		GameController.OnGameWin += HandleOnGameWin;
		GameController.OnNextLevel += HandleOnNextLevel;
		GameController.OnBonusTaken += HandleOnBonusTaken;
	}

	void HandleOnBonusTaken ()
	{
		PlaySound(Sounds.BonusTaken);
	}

	void HandleOnNextLevel ()
	{
		PlaySound(Sounds.NextLevel);
	}

	void HandleOnGameWin ()
	{
		PlaySound (Sounds.Win);
	}

	void HandleOnGameOver ()
	{
		PlaySound (Sounds.GameOver);
	}


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		if (audioSource == null) {
			audioSource = gameObject.AddComponent<AudioSource>(); 
		}

		PlaySound (DefaultSound); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(Sounds _soundToPlay){
		switch (_soundToPlay) {
		case Sounds.Blocked:
			audioSource.clip = Blocked;
			break;
		case Sounds.Followed:
			audioSource.clip = Followed;
			break;
		case Sounds.Free:
			audioSource.clip = Free;
			break;
		case Sounds.GameOver:
			audioSource.clip = GameOver;
			break;
		case Sounds.Win:
			audioSource.clip = Win;
			break;
		case Sounds.BonusTaken :
			audioSource.clip = BonusTaken;
			break;
		case Sounds.NextLevel:
			audioSource.clip = NextLevel;
			break;
		}

		audioSource.Play ();
	}

	public enum Sounds {
		Followed,
		Blocked,
		Free,
		GameOver,
		Win,
		BonusTaken,
		NextLevel
	}
}
}