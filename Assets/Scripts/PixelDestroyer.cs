using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDestroyer : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.tag == this.gameObject.tag || this.gameObject.tag == "Untagged" )
		{
			Destroy(gameObject);		 	
		}  
	}
}