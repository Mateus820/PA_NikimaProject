using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDestroyer : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.tag == this.gameObject.tag || this.gameObject.tag == "Untagged" )
		{
            Singleton.GetInstance.gm.pixelsDestroyed++;
            if (Singleton.GetInstance.gm.pixelsDestroyed++ >= 630)
           {
           print("Win");
        }
           // AudioManager.instance.Play("Crack");
			Destroy(gameObject);		 	
		}  
	}
}