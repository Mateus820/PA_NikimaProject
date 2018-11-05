using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MoveController : MonoBehaviour {

	protected float speed;
	[SerializeField] protected PaddleController paddle;
	[SerializeField] protected BallShot ballShot;
	protected Rigidbody2D rb;

}
