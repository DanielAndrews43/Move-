using UnityEngine;
using System.Collections;

public class MoveDown : MonoBehaviour {
	Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			rigidBody.velocity = new Vector3(0, -10);
		}
	}
}
