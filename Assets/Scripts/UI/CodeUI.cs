using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeUI : MonoBehaviour {

public Color invisible;

private SpriteRenderer sp;
public GameObject canvas;
public ParticleSystem zeroParticle;
public ParticleSystem oneParticle;

public Animator anim;

private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame

	public void Fall()
	{
		rb.gravityScale = 0.5f;
	}

	IEnumerator ChangingScene()
	{
		yield return new WaitForSeconds(1.5f);
		canvas.SetActive(false);
		sp.color = invisible;
		anim.SetTrigger("glitching");
		yield return new WaitForSeconds(1f);
		GameInit();
		
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		zeroParticle.Pause();
		oneParticle.Pause();
		StartCoroutine(ChangingScene());
		
	}

	void GameInit()
	{
		SceneManager.LoadScene("Game");
	}

}
