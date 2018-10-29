using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDestroyer : MonoBehaviour {

private void OnCollisionEnter2D(Collision2D other) 
{
	if(other.gameObject.tag == this.gameObject.tag)
	{

		Destroy(gameObject);		
	}
}

}