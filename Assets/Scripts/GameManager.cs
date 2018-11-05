using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public Vector2 playerPos;
    public SwipeController swipe;
    public ArrowsController arrow;
    public GameObject arrowsUI;

    void Start () {
        player = Singleton.GetInstance.player;
        playerPos = new Vector2(0,-4);

        if (GameObject.FindGameObjectWithTag("Player") == null)
        { 
            Instantiate(player, playerPos, Quaternion.identity);
        }
    }
	
	void Update () {

        if (PlayerPrefs.GetString("PlayerMovement") == "swipe")
        {
            arrowsUI.SetActive(false);
            arrow.enabled = false;
            swipe.enabled = true;
        }
        else 
        {
            arrowsUI.SetActive(true);
            swipe.enabled = false;
            arrow.enabled = true;
        }

    }
}