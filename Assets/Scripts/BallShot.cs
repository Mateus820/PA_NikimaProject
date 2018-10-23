using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour {

	public float rotZ;
	public GameObject angleArrow;
	public BallCount ballCount;
    private PaddleController playerScript;
    [SerializeField] private float offset;
    [SerializeField]private float[] limits;

    void Start() 
	{
		angleArrow.SetActive(false);
        playerScript = Singleton.GetInstance.playerScript;
    }
	void Update () {
        if (!playerScript.isMovingWithSwipe && rotZ > 0 && playerScript.ballCount > 0) {
            if (Input.GetMouseButton(0) && !playerScript.isClicking)
            {   
                angleArrow.SetActive(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                angleArrow.SetActive(false);
                Shot(playerScript);
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

		if(obj != null){
			obj.transform.position = transform.position;
			obj.SetActive(true);
			playerScript.DecreasingBalls();
		}

	}
}