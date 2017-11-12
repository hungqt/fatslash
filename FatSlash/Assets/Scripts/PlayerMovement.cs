using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	public float speed;
	private Vector2 movement_vector;
	private Vector2 knockback_vector;

	// Use this for initialization
	void Start () {
		
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		movement_vector = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (movement_vector != Vector2.zero) {
			anim.SetBool ("iswalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);
		} else {
			anim.SetBool ("iswalking", false);
		}

		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * speed);
	}

	public IEnumerator Knockback(float knockbackPower, Vector2 knockbackDirection) {
		rbody.MovePosition (rbody.position + knockbackDirection * knockbackPower * Time.deltaTime);
		yield return 0;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == ("Cupcake")) {
			float knockbackPower = 1000;
			Vector2 knockbackDirection = col.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
			knockbackDirection = -knockbackDirection.normalized;

			rbody.MovePosition (rbody.position + knockbackDirection * knockbackPower * Time.deltaTime);
			Debug.Log ("treffer den");
		}
	}

}
