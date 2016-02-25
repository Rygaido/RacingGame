using UnityEngine;
using System.Collections;

public class drive : MonoBehaviour {

	private float speed = 1.0f;
	private float topSpeed = 1.0f;

	private Rigidbody r;

	private Vector3 velocity;
	private Vector3 acceleration;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		velocity = new Vector3 (0, 0, 0);
		acceleration = new Vector3 (0, 0, 0);
		direction = transform.forward;
		//r = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		acceleration *= 0.9f;

		if (Input.GetKey ("up")) {
			acceleration += direction * speed; //* Time.deltaTime;
		}
		if (Input.GetKey ("down")) {
			acceleration += -0.5f * direction * speed; //* Time.deltaTime;
		}

		if(Input.GetKey("left")){
			direction = Quaternion.AngleAxis (-5,Vector3.up) * direction;
			transform.rotation = (Quaternion.LookRotation (direction));
			//transform.Rotate (new Vector3(0,-1.0f,0));
		}
		if(Input.GetKey("right")){
			direction = Quaternion.AngleAxis (5,Vector3.up) * direction;
			transform.rotation = (Quaternion.LookRotation (direction));
			//transform.Rotate (new Vector3(0,1.0f,0));
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
