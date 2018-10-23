using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour {

	public GameObject[] UIHeart;
	
	IEnumerator DestroingHeart(GameObject corazon)
	{

		corazon.GetComponent<SetGlitch>().GlitchNow();
		yield return new WaitForSeconds(0.45f);
		corazon.SetActive(false);
	}

	public void LifeCheck(int playerHealth)
	{
		switch(playerHealth)
		{
			case 2:
				StartCoroutine(DestroingHeart(UIHeart[2]));
			break;

			case 1:
				StartCoroutine(DestroingHeart(UIHeart[1]));
			break;

			case 0:
				StartCoroutine(DestroingHeart(UIHeart[0]));
				SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex);
			break;

		}
	}
}
