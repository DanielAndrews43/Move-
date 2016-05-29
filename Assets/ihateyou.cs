using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class ihateyou : MonoBehaviour {

	public Sprite[] sprites;

	// Update is called once per frame
	void Update () {
		GetComponent<Image> ().sprite = sprites [Int32.Parse (PlayerPrefs.GetString ("name")) - 1];
	}
}
