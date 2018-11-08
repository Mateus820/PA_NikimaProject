using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicColor : MonoBehaviour {

	[SerializeField] private BallShot ballShot;
	

	void Start () {
		ballShot.DelaySetColor = 1.0f;	
	}

	void Update () {
		print(AudioManager.instance.GetMusicTime("Glitch 3.0"));
		
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 8f)
		{
			ballShot.DelaySetColor = 0.95f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 15f)
		{
			ballShot.DelaySetColor = 0.65f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 23f)
		{
			ballShot.DelaySetColor = 0.55f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 37f)
		{
			ballShot.DelaySetColor = 0.35f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 67f)
		{
			ballShot.DelaySetColor = 0.20f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 74f)
		{
			ballShot.DelaySetColor = 0.15f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 81f)
		{
			ballShot.DelaySetColor = 0.13f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 110f)
		{
			ballShot.DelaySetColor = 0.20f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 126f)
		{
			ballShot.DelaySetColor = 0.15f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 131f)
		{
			ballShot.DelaySetColor = 0.13f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 148f)
		{
			ballShot.DelaySetColor = 0.15f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 177f)
		{
			ballShot.DelaySetColor = 0.01f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 3.0") >= 196f)
		{
			ballShot.DelaySetColor = 0.01f;
		}

	}	
}
