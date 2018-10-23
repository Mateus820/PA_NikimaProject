using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public Vector2 playerPos;

    public bool moveBySwipe { get; private set; }
    public bool arrowsTest;
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

        if (!arrowsTest)
        {
            arrowsUI.SetActive(false);
            moveBySwipe = true;
        }
        else 
        {
            arrowsUI.SetActive(true);
            moveBySwipe = false;
        }

    }
}