using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {
	
	public void ChangeScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}

	public void StartMenu(){
		
	}
}
