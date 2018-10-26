using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour {

	public float rotZ;
	public GameObject angleArrow;
	public BallCount ballCount;
	[SerializeField] private float delaySetColor;
	[SerializeField] private SpriteRenderer paddleSprite;
	[SerializeField] private SpriteRenderer arrowSprite;
	[SerializeField] private float offset;
    [SerializeField] private float[] limits;
	[SerializeField] private Color[] colors;
	private PaddleController playerScript;
	private bool changeColor;

    void Start() 
	{
		changeColor = true;
		angleArrow.SetActive(false);
        playerScript = Singleton.GetInstance.playerScript;
		StartCoroutine(SetColor());
    }
	void Update () {
        if (!playerScript.isMovingWithSwipe && rotZ > 0 && playerScript.ballCount > 0) {
            if (Input.GetMouseButton(0) && !playerScript.isClicking)
            {   
				//paddleSprite.color = RandomBallColor();
                angleArrow.SetActive(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                angleArrow.SetActive(false);

				//CancelRoutine();
                Shot(playerScript);
				changeColor = true;
            }
			if(Input.GetMouseButtonDown(0)){
				changeColor = false;
			}
        }

        if (playerScript.isMovingWithSwipe)
            angleArrow.SetActive(false);

		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		if(rotZ >= 0)
		{
			rotZ = Mathf.Clamp(rotZ, limits[0], limits[1]);
			transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
		}
	}

	void Shot(PaddleController playerScript){
		var obj =  ObjectPooler.instance.GetPooledObject();

		SpriteRenderer sp = obj.GetComponentInChildren<SpriteRenderer>();
		sp.color = paddleSprite.color;

		if(obj != null){
			obj.transform.position = transform.position;
			obj.SetActive(true);
			playerScript.DecreasingBalls();
		}
	}

	Color RandomBallColor(Color cl){
		Color colorReturn;
		if((colorReturn = colors[Random.Range(0, colors.Length - 1)]) == cl){
			RandomBallColor(paddleSprite.color);
		}
		//print(cl);
		return colorReturn;
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
}