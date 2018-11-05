using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {
	
	[SerializeField] private Animator arrowsAnim;
	[SerializeField] private Animator swipeAnim;

	void OnEnable()
	{
        if (!PlayerPrefs.HasKey("PlayerMovement")){
            PlayerPrefs.SetString("PlayerMovement", "arrows");
        }

		if(PlayerPrefs.GetString("PlayerMovement") == "arrows"){
			swipeAnim.SetBool("glitching" , false);
			arrowsAnim.SetBool("glitching" , true);
		}  
		else if(PlayerPrefs.GetString("PlayerMovement") == "swipe"){
			arrowsAnim.SetBool("glitching" , false);
			swipeAnim.SetBool("glitching" , true);
		}
	}

	void Start() {
		ChoosingJoystick();
	}

	public void ChoosingArrows()
	{
		PlayerPrefs.SetString("PlayerMovement" , "arrows");
		//animações
		swipeAnim.SetBool("glitching" , false);
		arrowsAnim.SetBool("glitching" , true);
		PlayerPrefs.Save();
	}

	public void ChoosingSwipe()
	{
		PlayerPrefs.SetString("PlayerMovement" , "swipe");
		//animações
		arrowsAnim.SetBool("glitching" , false);
		swipeAnim.SetBool("glitching" , true);
		PlayerPrefs.Save();
	}

	public void ChoosingJoystick(){
		PlayerPrefs.SetString("PlayerMovement", "joystick");
		PlayerPrefs.Save();
	}

}
