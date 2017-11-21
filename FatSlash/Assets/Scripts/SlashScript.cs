﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour {

	Animator anim;
	Renderer renderer;
	CupcakeMovement cupcake;
	public float knockbackPower;

	// Use this for initialization
	void Start () {
//		gameObject.SetActive (false);
		anim = GetComponent<Animator> ();
		renderer = GetComponent<Renderer> ();
		cupcake = GameObject.FindGameObjectWithTag("Cupcake").GetComponent<CupcakeMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			gameObject.SetActive (true);
			anim.SetTrigger ("Attack");
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == ("Cupcake")) {
			Vector2 knockbackDirection = col.contacts[0].point - new Vector2(cupcake.transform.position.x, cupcake.transform.position.y);
			knockbackDirection = -knockbackDirection.normalized;
			StartCoroutine(cupcake.KnockbackEnemy(knockbackPower, knockbackDirection));
		}
	}

}
