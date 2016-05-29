using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetScores : MonoBehaviour {

	public Text score;
	public Text highscore;

	void Start(){
		score.text = "Score: " + PlayerPrefs.GetInt ("score", 0);
		highscore.text = "Highscore: " + PlayerPrefs.GetInt ("0", 0);
	}
}
