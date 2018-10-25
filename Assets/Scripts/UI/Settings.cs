using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	string playerMovement;

	public Animator arrowsAnim;

	public Animator swipeAnim;
	public GameObject SettingsMenu;
	void Start () 
	{
		if(PlayerPrefs.HasKey("PlayerMomevent"))
		{
			playerMovement = PlayerPrefs.GetString("PlayerMovement");
		}

		else
		{
			playerMovement = "arrows";
		}
		
	}
	
	
	void Update () 
	{
		if(PlayerPrefs.GetString("PlayerMovement") == "arrows")
		{
			swipeAnim.SetBool("glitching" , false);
			arrowsAnim.SetBool("glitching" , true);
		}

		if(PlayerPrefs.GetString("PlayerMovement") == "swipe")
		{
			arrowsAnim.SetBool("glitching" , false);
			swipeAnim.SetBool("glitching" , true);
		}
		
	}

	public void OpenMenu()
	{
		SettingsMenu.SetActive(true);
	}
	
	public void CloseMenu()
	{
		SettingsMenu.SetActive(false);
	}

public void ChoosingArrows()
{
	PlayerPrefs.SetString("PlayerMovement" , "arrows");
}

public void ChoosingSwipe()
{
	PlayerPrefs.SetString("PlayerMovement" , "swipe");
}

}
