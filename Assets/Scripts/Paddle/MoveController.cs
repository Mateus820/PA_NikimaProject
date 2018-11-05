using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MoveController : MonoBehaviour {

	[SerializeField] protected float speed;
	protected PaddleController paddle;
	protected Rigidbody2D rb;

}
