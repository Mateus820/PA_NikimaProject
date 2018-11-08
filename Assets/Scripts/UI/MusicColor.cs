using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicColor : MonoBehaviour {

	[SerializeField] private BallShot ballShot;
	

	void Start () {
		ballShot.DelaySetColor = 1.0f;	
	}

	void Update () {
		print(AudioManager.instance.GetMusicTime("Glitch 2.5"));
		
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 8f)
		{
			ballShot.DelaySetColor = 0.95f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 15f)
		{
			ballShot.DelaySetColor = 0.65f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 23f)
		{
			ballShot.DelaySetColor = 0.55f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 37f)
		{
			ballShot.DelaySetColor = 0.35f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 67f)
		{
			ballShot.DelaySetColor = 0.20f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 74f)
		{
			ballShot.DelaySetColor = 0.15f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 81f)
		{
			ballShot.DelaySetColor = 0.13f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 110f)
		{
			ballShot.DelaySetColor = 0.20f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 126f)
		{
			ballShot.DelaySetColor = 0.15f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 131f)
		{
			ballShot.DelaySetColor = 0.13f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 148f)
		{
			ballShot.DelaySetColor = 0.15f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 177f)
		{
			ballShot.DelaySetColor = 0.01f;
		}
		if(AudioManager.instance.GetMusicTime("Glitch 2.5") >= 196f)
		{
			ballShot.DelaySetColor = 0.01f;
		}

	}	
}
