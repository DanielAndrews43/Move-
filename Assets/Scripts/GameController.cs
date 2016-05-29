using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject brickHolderPrefab;
	private GameObject[] brickHolders;
	private float lastYCoord = 10;
	public float spaceBetweenBricks;

	public AudioSource ac;

	private int score = 0;

	public Text text;

	public float[] spots;

	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("score", 0);
		brickHolders = new GameObject[10];
		MakeBricks ();
		Time.timeScale = 1;
		if (PlayerPrefs.GetInt ("on", 1) == 1) {
			ac.Play ();
			ac.UnPause ();
		}
		else{
			ac.Pause ();
		}
	}

	void MakeBricks(){
		for (int i = 0; i < brickHolders.Length; i++) {
			Vector3 coords = new Vector3(0, lastYCoord, 4.5f);
			lastYCoord += spaceBetweenBricks;
			brickHolders [i] = (GameObject)Instantiate (brickHolderPrefab);
			brickHolders [i].transform.position = coords;
			RandomizeBricks (i);
		}
	}

	float FindHighest(){
		float h = -100;
		for (int i = 0; i < brickHolders.Length; i++) {
			if (brickHolders [i].transform.position.y > h) {
				h = brickHolders [i].transform.position.y;
			}
		}
		return h;
	}

	void LegitMoveBrickRow(int i){
		float height = FindHighest ();
		height += spaceBetweenBricks;
		Vector3 coords = new Vector3(0, height, 4.5f);
		brickHolders [i].transform.position = coords;
		RandomizeBricks (i);
	}

	public void MoveBrickRow(Transform go){
		for (int i = 0; i < brickHolders.Length; i++) {
			if (go.Equals(brickHolders [i].transform)) {
				LegitMoveBrickRow (i);
			}
		}
	}

	void RandomizeBricks(int index){
		Transform brickOne = brickHolders [index].transform.GetChild (0);
		Transform brickTwo = brickHolders [index].transform.GetChild (1);
		Transform brickThree = brickHolders [index].transform.GetChild (2);
		Transform brickFour = brickHolders [index].transform.GetChild (3);
		Transform[] bricks = { brickOne, brickTwo, brickThree, brickFour };

		int[] takenSpots = { -1, -1, -1, -1 };
		for (int i = 0; i < 4; i++) {
			int spot = -1;
			while (spot < 0) {
				spot = Random.Range (0, 4);
				if (takenSpots [spot] == -1) {
					bricks [i].localPosition = new Vector3 (spots [spot], 0);
					takenSpots [spot] = 1;
				} else {
					spot = -1;
				}
			}
		}

	}

	public void AddScore(){
		score++;
		text.text = "" + score;

		PlayerPrefs.SetInt ("score", score);
		if (score > PlayerPrefs.GetInt ("highscore", 0)) {
			PlayerPrefs.SetInt ("highscore", score);
		}
	}

	public void LeaderBoardStuff(){
		int[] scores = {
			PlayerPrefs.GetInt("0", 0),
			PlayerPrefs.GetInt("1", 0),
			PlayerPrefs.GetInt("2", 0),
			PlayerPrefs.GetInt("3", 0),
			PlayerPrefs.GetInt("4", 0),
			PlayerPrefs.GetInt("5", 0),
			PlayerPrefs.GetInt("6", 0),
			PlayerPrefs.GetInt("7", 0),
			PlayerPrefs.GetInt("8", 0),
			PlayerPrefs.GetInt("9", 0),
		};
		int index = 11;
		for (int i = scores.Length; i >= 0; i--) {
			if (score > PlayerPrefs.GetInt ("" + i, 0)) {
				index = i;
			}
		}
		if (index == 11) {
			return;
		}

		for (int i = scores.Length - 1; i > index; i--) {
			PlayerPrefs.SetInt (i + "", PlayerPrefs.GetInt ((i - 1) + "", 0));
		}
		PlayerPrefs.SetInt ("" + index, score);
	}
}
//lamborghini merci