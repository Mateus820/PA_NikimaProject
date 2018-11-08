using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSettings : MonoBehaviour {

	[SerializeField] private GameObject settingsMenu;

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
    }

    IEnumerator ClosingMenu()
    {
        yield return new WaitForSeconds(0.5f);
        settingsMenu.SetActive(false);
    }
}
