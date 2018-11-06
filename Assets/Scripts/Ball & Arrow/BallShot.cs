﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour {

	public float rotZ;
	public bool isJoystick;
	[SerializeField] private Transform joystickFollow;
	public GameObject angleArrow;
	[SerializeField] private BallCount ballCount;
	[SerializeField] private float delaySetColor;
	[SerializeField] private SpriteRenderer paddleSprite;
	[SerializeField] private SpriteRenderer arrowSprite;
	[SerializeField] private float offset;
    [SerializeField] private float[] limits;
	[SerializeField] private Color_Name[] colors;
	public bool changeColor;

    void Start() 
	{
		changeColor = true;

		angleArrow.SetActive(false);
		StartCoroutine(SetColor());
    }


	void Update ()
    {
		Vector3 difference = Difference();
		rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		if(rotZ >= 0)
		{
			rotZ = Mathf.Clamp(rotZ, limits[0], limits[1]);
			transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
		}
	}

	public Vector3 Difference()
    {
		if(isJoystick)
        {
			return joystickFollow.position - transform.position;
		}
		return Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	}

	public void SetJoystick(Transform joy){
		joystickFollow = joy;
	}

	public void Shot(PaddleController playerScript) {

		var obj =  ObjectPooler.instance.GetPooledObject();

		SpriteRenderer sp = obj.GetComponentInChildren<SpriteRenderer>();
		sp.color = paddleSprite.color;
		obj.tag = SetTag(sp.color);
		print(obj);
		if(obj != null){
			obj.transform.position = transform.position;
			obj.SetActive(true);
			AudioManager.instance.Play("Shot");
			playerScript.DecreasingBalls();
		}
	}

	Color RandomBallColor(Color cl){
		Color colorReturn;
		if((colorReturn = colors[Random.Range(0, colors.Length - 1)].color) == cl){
			RandomBallColor(paddleSprite.color);
		}
		//print(cl);
		return colorReturn;
	}
	string SetTag(Color target)
	{
		for(int i = 0; i < colors.Length; i++)
		{
			if(target == colors[i].color)
			{
				return colors[i].name;
			}
		}
		
		return "Error";
	}

	 
	IEnumerator SetColor(){
		while(true){
			if(changeColor){
				paddleSprite.color = RandomBallColor(paddleSprite.color);
				arrowSprite.color = paddleSprite.color;
			}
			yield return new WaitForSeconds(delaySetColor);
		}
	}

	public void ColorVelocity(float delay){
		delaySetColor = delay;
	}
}