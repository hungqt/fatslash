﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	public float speed;
	private Vector2 movement_vector;
	private Vector2 knockback_vector;
	bool collided = false;
	public int health;

	// Use this for initialization
	void Start () {
		
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			
		}
		if (!collided) {
			movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			anim.SetBool ("isHit", false);
		}

		if (movement_vector != Vector2.zero) {
			anim.SetBool ("iswalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);
		} else {
			anim.SetBool ("iswalking", false);
		}

		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * speed);
		collided = false;
	}

	public IEnumerator Knockback(float knockbackPower, Vector2 knockbackDirection) {
		collided = true;
		anim.SetBool ("isHit", true);
//		rbody.MovePosition (rbody.position + knockbackDirection * knockbackPower * Time.deltaTime);
		movement_vector = knockbackDirection * knockbackPower;
		health -= 1;
		yield return 0;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == ("Portal")) {
			// U win
			SceneManager.LoadScene ("Win");
		}
	}

}