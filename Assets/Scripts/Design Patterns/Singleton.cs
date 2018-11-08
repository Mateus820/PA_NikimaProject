﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton : MonoBehaviour {

    public GameObject player;

	public PaddleController playerScript;

    public Canvas HUDGameplay;

	public CameraController cameraScript;
	
	public Transform paddleTransform;

	public BallShot ballShot;

    public GameManager gm;

	public HealthUI healthUI;

    public PlayerLosedTransition transitionToGameOver;

    private static Singleton instance;
	

	public static Singleton GetInstance{
		get{
			if(instance == null){
				instance = GameObject.FindObjectOfType<Singleton>();
			}
			return instance;
		}
	}
}
