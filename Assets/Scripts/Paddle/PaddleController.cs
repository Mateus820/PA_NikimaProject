using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public GameManager managerOpt;    
    public int health;
    public int ballCount;
    public int ballsHitted;
    public int activeBall;
    public Color[] colors;
    public bool isJoyStickMoving;
    public Rigidbody2D rb;
    public Collider2D coll;
    public float speed;
    public BallCount ballCountScript;
    public Vector2 finalSpeed;
    public Animator animLeftArrow;
    public Animator animRightArrow;


	void Start (){
        health = 3;
        activeBall = 0;
        ballCount = 3;
        ballCountScript.UpdateUI(ballCount);
        isJoyStickMoving = true;
	}

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.18f ,2.18f) , transform.position.y);
        rb.velocity = new Vector2 (Mathf.Clamp(rb.velocity.x ,-speed * Time.deltaTime, speed * Time.deltaTime) , rb.velocity.y);
        //finalSpeed = MoveJoyStick();
        
        //if(Input.GetButtonDown("Fire1")){
        //    ballShot.isJoystickShooting = !ballShot.isJoystickShooting;
        //    ballShot.ChangeColor = false;
        //}
    }

    #region PhysicsUpdate
    void FixedUpdate()
    {
        //if(isJoyStickMoving && !ballShot.isJoystickShooting){
        //    rb.velocity = finalSpeed;
        //}
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "GreenBall" || coll.gameObject.tag == "OrangeBall" || coll.gameObject.tag == "BlueBall" || coll.gameObject.tag == "PinkBall")
        {
            ballsHitted++;
            AddingBalls();
        }
    }
    #endregion PhysicsUpdate

    #region JoystickMove
    Vector2 MoveJoyStick(){
        Vector2 finalSpeed = new Vector2();
        if(isJoyStickMoving){
            float x = Input.GetAxisRaw("Horizontal");
            if(x > 0){
                finalSpeed.x = speed * 0.02f; 
            }
            else if(x < 0){
                finalSpeed.x = -speed * 0.02f;
            }
            return finalSpeed;
        }
        return Vector2.zero;
    }
    #endregion

    #region BallController
    void AddingBalls()
    {
        if (ballsHitted == 3)
        {
            //Add a ball;
            ballsHitted = 0;
            if (ballCount < 8 && (ballCount + activeBall) < 8)
            {
                ballCount++;
                ballCountScript.UpdateUI(ballCount);
            }
        }
    }
    public void DecreasingBalls()
    {
        activeBall++;
	    ballCount--;
		ballCountScript.UpdateUI(ballCount);
    }
    #endregion BallController

}