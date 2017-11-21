﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeMovement : MonoBehaviour {

	private PlayerMovement player; 
	private Vector3 playerPosition;
	private Vector3 Cupcake;
	private Vector2 playerPositionDirection;
	private float Xdif;
	private float Ydif;
	public float speed;
	public float knockbackPower;
	Camera mycam;
	Animator anim;

	bool collided = false;
	public int health;
	private Vector2 movement_vector;
	private Vector2 knockback_vector;

	// Use this for initialization
	void Start () {
		mycam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update () {
		playerPosition = GameObject.Find ("Player").transform.position;
		Cupcake = GameObject.Find ("Cupcake").transform.position;

		Vector3 screenPoint = mycam.WorldToViewportPoint(Cupcake);

		bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

		if (onScreen) {

			if (!collided) {
				anim.SetBool ("isHit", false);
				Xdif = playerPosition.x - transform.position.x;
				Ydif = playerPosition.y - transform.position.y;

				playerPositionDirection = new Vector2 (Xdif, Ydif);
			} 

			transform.Translate (playerPositionDirection * speed);

			anim.SetFloat ("input_x", playerPositionDirection.x);
			anim.SetFloat ("input_y", playerPositionDirection.y);
			collided = false;
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.layer == (10)) {
			Debug.Log ("treffer slash");
			return;
		}
		if (col.gameObject.tag == ("Player")) {
			Vector2 knockbackDirection = col.contacts[0].point - new Vector2(player.transform.position.x, player.transform.position.y);
			knockbackDirection = -knockbackDirection.normalized;
			StartCoroutine(player.Knockback(knockbackPower, knockbackDirection));
		}
	}

	public IEnumerator KnockbackEnemy(float knockbackPower, Vector2 knockbackDirection) {
		collided = true;
		anim.SetBool ("isHit", true);
		playerPositionDirection = knockbackDirection * knockbackPower;
		health -= 1;
		if (health < 1) {
			player.addPoints (1000);
			Debug.Log ("" + player.getPoints ());
			Destroy(gameObject);
		}
		yield return 0;
	}
		
}
