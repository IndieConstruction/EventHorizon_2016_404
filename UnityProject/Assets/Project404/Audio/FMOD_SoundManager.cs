using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;
namespace EH.Project404{
public class FMOD_SoundManager : MonoBehaviour
{
    // sounds for the blob
    [EventRef]
    public string SND_Blob_Run;         // looping sound of the blob rolling
    [EventRef]
    public string SND_Blob_Jump;        // one shot sound of the blob jumping on the platform
    [EventRef]
    public string SND_Blob_SplatDead;   // one shot sound of the blob dying against an obstacle (exception: UrchinExplosion)
    [EventRef]
    public string SND_Blob_Eat;         // one shot sound of the blob eating objects
    [EventRef]
    public string SND_Blob_FallDead;    // one shot sound of the blob falling through holes
    [EventRef]
    public string SND_Blob_GrowUp;      // one shot sound triggered every time the blob grows up in size
    [EventRef]
    public string SND_Blob_GrowDown;    // one shot sound triggered every time the blob gets smaller in size
    [EventRef]
    public string SND_Blob_UrchinExplosion; // one shot sound of the blob exploding when touching the urchin

   // public string p_blobSize;          // parameter for the blob size. ranges from 0 to 4
                                        // affected events are: SND_Blob_Run, SND_Blob_Jump, SND_Blob_SplatDead, SND_Blob_Eat

  /* 
   * Non esiste nessuno scrigno.
   * [EventRef]
    public string SND_Chest_Opens;      // one shot sound for when the chest opens
    [EventRef]
    public string SND_Chest_Hit;        // one shot sound for when the chest is hit
    [EventRef]
    public string SND_Chest_Destroyed;  // one shot sound for when the chest is destroyed
*/
		//QUESTE COSE NON ESISTONO
	[EventRef]
    public string SND_Anchor_Hit;       // one shot sound for when the anchor is hit
    [EventRef]
    public string SND_Anchor_Destroyed; // one shot sound for when the anchor is destroyed
    [EventRef]
    public string SND_Urn_Hit;          // one shot sound for when the urn is hit
    [EventRef]
    public string SND_Urn_Destroyed;    // one shot sound for when the urn is destroyed
    [EventRef]
    public string SND_Coral_Green_Hit;          // one shot sound for when the green corals are hit
    [EventRef]
    public string SND_Coral_Green_Destroyed;    // one shot sound for when the green corals are destroyed
    [EventRef]
    public string SND_Coral_Red_Hit;            // one shot sound for when the red corals are hit

    [EventRef]
    public string SND_Ambience;         // looping sound for ambience

    [EventRef]
    public string SND_Music;            // looping sound for music
   // public string p_musicState;         // parameter that is changed via trigger planes along the level. values range from 0 to 3 (int)
   // public string p_gameState;          // parameter that says if we are in the menu state (0), or in-game (1) (int, just in case they want to add more states)



    [EventRef]
	public string SND_PlayerDimensionChanged; // one shot sound for when the ball changes dimension


    void Start() {
		DontDestroyOnLoad(this);
		Sound_StartLevel();
    }


	public void Sound_StartLevel(){
		/*
        EventInstance SND_ControlledEvent = RuntimeManager.CreateInstance(SND_PlayerDeath);
		SND_ControlledEvent.start();		


		EventInstance SND_ControlledEvent_WithParameters = RuntimeManager.CreateInstance(SND_PlayerShoot);
		SND_ControlledEvent_WithParameters.setParameterValue("WeaponNumber", 1);
		SND_ControlledEvent_WithParameters.start();
		SND_ControlledEvent_WithParameters.setParameterValue("WeaponNumber", 2);
		SND_ControlledEvent_WithParameters.start();
        */

	}

    public void CreateSoundEventInstance(string SND_eventName, EventInstance EVT_eventName)
    {
        if (SND_eventName != null)
        {
           // EventInstance EVT_eventName = RuntimeManager.CreateInstance(SND_eventName);
        }

    }

    public void PlayerDimensionChanged(float _playerDimension, float _playerSpeed){
		/*
        EventInstance EVT_SND_PlayerDimensionChanged = RuntimeManager.CreateInstance(SND_PlayerDimensionChanged);
		EVT_SND_PlayerDimensionChanged.setParameterValue("Dimension", _playerDimension);
		EVT_SND_PlayerDimensionChanged.setParameterValue("Speed", _playerSpeed);
		EVT_SND_PlayerDimensionChanged.start();
		EVT_SND_PlayerDimensionChanged.stop();
		RuntimeManager.PlayOneShot(EVT_SND_PlayerDimensionChanged);
        */
	}
		public void Blob_Run(int Dimension){

        EventInstance EVT_SND_Blob_Run = RuntimeManager.CreateInstance(SND_Blob_Run);
		EVT_SND_Blob_Run.setParameterValue("size",Dimension);
		EVT_SND_Blob_Run.start();
		//EVT_SND_Blob_Run.stop();
		//RuntimeManager.PlayOneShot(EVT_SND_Blob_Run);
      
		}

		public void Blob_Jump(int Dimension){
			
			EventInstance EVT_SND_Blob_Jump = RuntimeManager.CreateInstance(SND_Blob_Jump);
			EVT_SND_Blob_Jump.setParameterValue("size",Dimension);
			EVT_SND_Blob_Jump.start();
		
		}
		public void Blob_SplatDead(int Dimension){
			
			 EventInstance EVT_SND_Blob_SplatDead = RuntimeManager.CreateInstance(SND_Blob_SplatDead);
			EVT_SND_Blob_SplatDead.setParameterValue("size",Dimension);
			EVT_SND_Blob_SplatDead.start();
		
		}
		public void Blob_Eat(int Dimension){
			
			 EventInstance EVT_SND_Blob_Eat = RuntimeManager.CreateInstance(SND_Blob_Eat);
			EVT_SND_Blob_Eat.setParameterValue("size",Dimension);
			EVT_SND_Blob_Eat.start();

		}
		public void Blob_FallDead(){

			 EventInstance EVT_SND_Blob_FallDead = RuntimeManager.CreateInstance(SND_Blob_FallDead);
			EVT_SND_Blob_FallDead.start();
		
		}

		public void Blob_GrowUp(){
			
			 EventInstance EVT_SND_Blob_GrowUp = RuntimeManager.CreateInstance(SND_Blob_GrowUp);
			EVT_SND_Blob_GrowUp.start();

}
		public void Blob_GrowDown(){

			EventInstance EVT_SND_Blob_GrowDown = RuntimeManager.CreateInstance(SND_Blob_GrowDown);
			EVT_SND_Blob_GrowDown.start();
			}


		public void Blob_UrchinExplosion(){
			/*
			EventInstance EVT_SND_Blob_UrchinExplosion = RuntimeManager.CreateInstance(SND_Blob_UrchinExplosion);
			RuntimeManager.PlayOneShot(EVT_SND_Blob_UrchinExplosion);
			*/
		}


		public void Anchor_Hit(){
			/*
			EventInstance EVT_SND_Anchor_Hit = RuntimeManager.CreateInstance(SND_Anchor_Hit);
			RuntimeManager.PlayOneShot(EVT_SND_Anchor_Hit);
			*/
		}


		public void Anchor_Destroyed(){
//			EventInstance EVT_SND_Anchor_Destroyed = RuntimeManager.CreateInstance(SND_Anchor_Destroyed);
//			RuntimeManager.PlayOneShot(EVT_SND_Anchor_Destroyed);
		}


		public void Urn_Hit(){
//			EventInstance EVT_SND_Urn_Hit = RuntimeManager.CreateInstance(SND_Urn_Hit);
//			RuntimeManager.PlayOneShot(EVT_SND_Urn_Hit);
		}

		public void Urn_Destroyed(){
//			EventInstance EVT_SND_Urn_Destroyed = RuntimeManager.CreateInstance(SND_Urn_Destroyed);
//			RuntimeManager.PlayOneShot(EVT_SND_Urn_Destroyed);
		}


		public void Coral_Green_Hit(){
//			EventInstance EVT_SND_Coral_Green_Hit = RuntimeManager.CreateInstance(SND_Coral_Green_Hit);
//			RuntimeManager.PlayOneShot(EVT_SND_Coral_Green_Hit);
		}


		public void Coral_Red_Hit(){
//			EventInstance EVT_SND_Coral_Red_Hit = RuntimeManager.CreateInstance(SND_Coral_Red_Hit);
//			RuntimeManager.PlayOneShot(EVT_SND_Coral_Red_Hit);
		}

		public void Coral_Green_Destroyed(){
//			EventInstance EVT_SND_Coral_Green_Destroyed = RuntimeManager.CreateInstance(SND_Coral_Green_Destroyed);
//			RuntimeManager.PlayOneShot(EVT_SND_Coral_Green_Destroyed);
		}

		public void Ambience(){
			EventInstance EVT_SND_Ambience = RuntimeManager.CreateInstance(SND_Ambience);
			EVT_SND_Ambience.start();
			//EVT_SND_Blob_Run.stop();
			//RuntimeManager.PlayOneShot(EVT_SND_Blob_Run);

		}
		public void Music(int musicState, int gameState){
			EventInstance EVT_SND_Music = RuntimeManager.CreateInstance(SND_Music);
			EVT_SND_Music.setParameterValue("musicState",musicState);
			EVT_SND_Music.setParameterValue("gameState",gameState);
			EVT_SND_Music.start();
			//EVT_SND_Blob_Run.stop();
			//RuntimeManager.PlayOneShot(EVT_SND_Blob_Run);

		}
	
		public void PlayerDimensionChanged(){
//			EventInstance EVT_SND_PlayerDimensionChanged = RuntimeManager.CreateInstance(SND_PlayerDimensionChanged);
//			RuntimeManager.PlayOneShot(EVT_SND_PlayerDimensionChanged);
		}
}
}