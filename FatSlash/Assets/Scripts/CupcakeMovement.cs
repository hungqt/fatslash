using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeMovement : MonoBehaviour {

	private Vector3 Player;
	private Vector3 Cupcake;
	private Vector2 PlayerDirection;
	private float Xdif;
	private float Ydif;
	public float speed;
	Camera mycam;


	// Use this for initialization
	void Start () {
		mycam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {
		Player = GameObject.Find ("Player").transform.position;
		Cupcake = GameObject.Find ("Cupcake").transform.position;

		Vector3 screenPoint = mycam.WorldToViewportPoint(Cupcake);

		bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

		if (onScreen) {
			Xdif = Player.x - transform.position.x;
			Ydif = Player.y - transform.position.y;

			PlayerDirection = new Vector2 (Xdif, Ydif);

			transform.Translate(PlayerDirection * speed);
		}

	}
}
