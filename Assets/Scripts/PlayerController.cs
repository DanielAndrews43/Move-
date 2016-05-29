using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {

	public Sprite[] sprites;

	private float[] spots;
	int currentPos = 1;
	int direction;
	GameController gc;

	public KeyCode right;
	public KeyCode left;

	public Text text;

	void Start(){
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		spots = gc.spots;

		if (PlayerPrefs.GetString("name", "") != "") {
			GetComponent<SpriteRenderer> ().sprite = sprites [Int32.Parse (PlayerPrefs.GetString("name")) - 1];
		}
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x > transform.position.x) {
				direction = -1;
			} else if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x < transform.position.x) {
				direction = 1;
			}
		} else if (Input.GetKeyDown (right)) {
			direction = -1;
		} else if (Input.GetKeyDown (left)) {
			direction = 1;
		}
	}

	void FixedUpdate(){
		if (direction > 0 && currentPos > 0) {
			currentPos -= 1;
			transform.position = new Vector3 (spots [currentPos], transform.position.y);
			direction = 0;
		} else if (direction < 0 && currentPos < 3) {
			currentPos += 1;
			transform.position = new Vector3 (spots [currentPos], transform.position.y);
			direction = 0;
		} else {
			direction = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		Time.timeScale = 0;
		text.gameObject.SetActive (true);

		gc.LeaderBoardStuff ();

		GameObject.FindGameObjectWithTag ("Finish").gameObject.GetComponent<ScreenHopper> ().ToDead ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Scorer") {
			gc.AddScore ();
		}
	}
}
