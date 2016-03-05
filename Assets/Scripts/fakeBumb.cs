using UnityEngine;
using System.Collections;

public class fakeBumb : MonoBehaviour {
	public GameObject player;

	float range = 5;
	public float yi;
	// Use this for initialization
	void Start () {
		yi = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		var dy = 0.25f;
		float distance = (transform.position - player.transform.position).magnitude;
		if (distance < range) {
			if (player.transform.position.y < dy+yi) {
				player.transform.Translate (new Vector3 (0, dy, 0));
			}
		} else if (distance == range) {
			//Quaternion.r
			if (player.transform.position.y > yi) {
				player.transform.Translate (new Vector3 (0, -dy, 0));
			}
		} else {
			if (player.transform.position.y > yi) {
				player.transform.Translate (new Vector3 (0, -dy, 0));
			}
		}
			
	}
}
