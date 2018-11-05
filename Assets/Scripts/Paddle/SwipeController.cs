using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MoveController {

    public bool isMovingWithSwipe { get; private set; }
    [SerializeField] private PaddleController paddleControl;
    [SerializeField] private BallShot ballShot;
    private Collider2D coll;

    private void Start()
    {
        rb = paddleControl.rb;
        coll = paddleControl.coll;
    }

    private void Update()
    {
        if (paddleControl.ballCount > 0 && ballShot.rotZ > 0 && !isMovingWithSwipe)
        {
            if (Input.GetMouseButton(0))
            {
                ballShot.angleArrow.SetActive(true);
                ballShot.ChangeColor = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                ballShot.angleArrow.SetActive(false);
                ballShot.Shot(paddleControl);
                ballShot.ChangeColor = true;
            }
        }

        if (isMovingWithSwipe)
        {
            ballShot.angleArrow.SetActive(false);
            ballShot.ChangeColor = true;
        }
    }

    void FixedUpdate()
    {
        if (isMovingWithSwipe)
        {
            Vector3 realMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(new Vector2(realMousePos.x, rb.position.y));
        }
    }

    public void OnMouseDown()
    {
        Collider2D collOnPoint = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (collOnPoint.Equals(coll))
        {
            isMovingWithSwipe = true;
        }
    }

    void OnMouseUp()
    {
        StartCoroutine(TurnMoveFalse(0.0005f));
    }

    IEnumerator TurnMoveFalse(float time)
    {
        yield return new WaitForSeconds(time);
        isMovingWithSwipe = false;
    }

}
