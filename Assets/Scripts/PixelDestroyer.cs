using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PixelDestroyer : MonoBehaviour {

	// [SerializeField] private GameObject effect;
	private void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.tag == this.gameObject.tag || this.gameObject.tag == "Untagged" )
		{
			// Instantiate(effect, transform.position, Quaternion.identity);
            Singleton.GetInstance.gm.pixelsDestroyed++;
            if (Singleton.GetInstance.gm.pixelsDestroyed++ >= 630)
           	{
                SceneManager.LoadScene(4);
        	}
           // AudioManager.instance.Play("Crack");
			Destroy(gameObject);		 	
		}  
	}
}