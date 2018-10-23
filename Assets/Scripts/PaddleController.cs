using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public GameManager managerOpt;    
    public int health;
    public int ballCount;
    public int ballsHitted;
    public int activeBall;
    public bool isMovingWithSwipe { get; private set; }
    public bool isClicking { get; private set; }
    private Rigidbody2D rb;
    private Collider2D coll;
    private bool moveBySwipe;
    [SerializeField] private float speed;
    [SerializeField] private BallCount ballCountScript;

     public Animator animLeftArrow;
     public Animator animRightArrow;


	void Start (){
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        health = 3;
        activeBall = 0;
        ballCount = 3;
        ballCountScript.UpdateUI(ballCount);

        isMovingWithSwipe = false;
        isClicking = false;

        moveBySwipe = managerOpt.moveBySwipe;
	}

    void Update()
    {
         moveBySwipe = managerOpt.moveBySwipe;
         transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.18f ,2.18f) , transform.position.y);
         rb.velocity = new Vector2 (Mathf.Clamp(rb.velocity.x ,-speed * Time.deltaTime, speed * Time.deltaTime) , rb.velocity.y);

    }

    #region InputEvents
    void OnMouseDown()
    {
        if (moveBySwipe)
        {
            Collider2D collOnPoint = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (collOnPoint.Equals(coll))
            {
                isMovingWithSwipe = true;
            }
        }
    }

    void OnMouseUp()
    {
        if(moveBySwipe)
        StartCoroutine(TurnMoveFalse(0.0005f));
    }
    #endregion InputEvents

    #region PhysicsUpdate
    void FixedUpdate()
    {
        if (isMovingWithSwipe && moveBySwipe)
        {
            Vector3 realMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(new Vector2(realMousePos.x, rb.position.y));
        }
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

    #region ArrowMove

    public void MoveRight()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
         animRightArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = true;
        Singleton.GetInstance.ballShot.angleArrow.SetActive(false);
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        animLeftArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = true;
        Singleton.GetInstance.ballShot.angleArrow.SetActive(false);
    }

    public void StopMoveRight()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animRightArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = false;
    }
    public void StopMoveLeft()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animLeftArrow.SetInteger("glitching", Mathf.RoundToInt(rb.velocity.x));
        isClicking = false;
    }
    #endregion ArrowMove

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

    #region IENumerators
    IEnumerator TurnMoveFalse(float time)
    {
        yield return new WaitForSeconds(time);
        isMovingWithSwipe = false;
    }
    #endregion IENumerators

}