using UnityEngine;
using System.Collections;

public class drive : MonoBehaviour {

	private float speed = 1.0f;
	private float topSpeed = 1.0f;

	private Rigidbody r;

	private Vector3 velocity;
	private Vector3 acceleration;

	// Use this for initialization
	void Start () {
		velocity = new Vector3 (0, 0, 0);
		acceleration = new Vector3 (0, 0, 0);
		//r = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		acceleration *= 0.9f;

		if (Input.GetKey ("up")) {
			acceleration += transform.forward * speed; //* Time.deltaTime;
		}
		if (Input.GetKey ("down")) {
			acceleration += -0.5f * transform.forward * speed; //* Time.deltaTime;
		}

		if(Input.GetKey("left")){
			transform.Rotate (new Vector3(0,-1.0f,0));
		}
		if(Input.GetKey("right")){
			transform.Rotate (new Vector3(0,1.0f,0));
		}
		/*
		velocity *= 0.9f;
		if (velocity.magnitude < 0.001f * Time.deltaTime) {
			velocity *= 0.0f;
		}
		*/

		if (velocity.magnitude < 0.01f) {
			velocity *= 0.0f;
		}
		if (acceleration.magnitude < 0.01f) {
			acceleration *= 0.0f;
		} else if (acceleration.magnitude > topSpeed) {
			acceleration.Normalize ();
			acceleration *= topSpeed;
		}
		velocity -= velocity*0.1f;
		velocity += acceleration;
		transform.position += velocity * Time.deltaTime;
	}
}
