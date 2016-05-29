using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderboardScript : MonoBehaviour {

	public Text[] text;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < text.Length; i++) {
			text [i].text = (i+1) + ": " + PlayerPrefs.GetInt ((i + 1) + "", 0) + "";
		}
	}

}
