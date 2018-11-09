using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {
	
	[SerializeField] private Animator arrowsAnim;
	[SerializeField] private Animator swipeAnim;
	[SerializeField] private Animator joystickAnim;

	void OnEnable()
	{
        if (!PlayerPrefs.HasKey("PlayerMovement")){
            PlayerPrefs.SetString("PlayerMovement", "arrows");
        }

		if(PlayerPrefs.GetString("PlayerMovement") == "arrows"){
			swipeAnim.SetBool("glitching" , false);
			arrowsAnim.SetBool("glitching" , true);
			joystickAnim.SetBool("glitching", false);
		}  
		else if(PlayerPrefs.GetString("PlayerMovement") == "swipe"){
			arrowsAnim.SetBool("glitching" , false);
			swipeAnim.SetBool("glitching" , true);
			joystickAnim.SetBool("glitching", false);
		}
		else if(PlayerPrefs.GetString("PlayerMovement") == "joystick")
		{
			arrowsAnim.SetBool("glitching" , false);
			swipeAnim.SetBool("glitching" , false);
			joystickAnim.SetBool("glitching", true);
		}
	}

	public void ChoosingArrows()
	{
		PlayerPrefs.SetString("PlayerMovement" , "arrows");
		//animações
		swipeAnim.SetBool("glitching" , false);
		joystickAnim.SetBool("glitching", false);
		arrowsAnim.SetBool("glitching" , true);
		PlayerPrefs.Save();
	}

	public void ChoosingSwipe()
	{
		PlayerPrefs.SetString("PlayerMovement" , "swipe");
		//animações
		arrowsAnim.SetBool("glitching" , false);
		joystickAnim.SetBool("glitching", false);
		swipeAnim.SetBool("glitching" , true);
		PlayerPrefs.Save();
	}

	public void ChoosingJoystick(){
		PlayerPrefs.SetString("PlayerMovement", "joystick");
		arrowsAnim.SetBool("glitching" , false);
		swipeAnim.SetBool("glitching" , false);
		joystickAnim.SetBool("glitching", true);
		PlayerPrefs.Save();
	}

}
