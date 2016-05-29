using UnityEngine;
using System.Collections;

public class LooperScript : MonoBehaviour {

	GameController gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		gc.MoveBrickRow (coll.gameObject.transform);
	}
}
