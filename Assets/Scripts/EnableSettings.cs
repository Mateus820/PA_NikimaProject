using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSettings : MonoBehaviour {

	[SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject startButton;

	public void OpenMenu()
	{
        StartCoroutine(OpeningMenu());
	}
		
	public void CloseMenu()
	{
        StartCoroutine(ClosingMenu());
	}


    IEnumerator OpeningMenu()
    {
        yield return new WaitForSeconds(0.5f);
        settingsMenu.SetActive(true);
        startButton.SetActive(false);
    }

    IEnumerator ClosingMenu()
    {
        yield return new WaitForSeconds(0.5f);
        startButton.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
