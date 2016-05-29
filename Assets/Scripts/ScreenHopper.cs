using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenHopper : MonoBehaviour {

	public GameObject on;
	public GameObject off;

	public void ToDead(){
		SceneManager.LoadScene (0);
	}

	public void ToGame(){
		SceneManager.LoadScene (1);
	}

	public void ToCodeDay(){
		SceneManager.LoadScene (2);
	}

	public void ToLeader(){
		SceneManager.LoadScene (3);
	}

	public void ToShop(){
		SceneManager.LoadScene (4);
	}


	public void SetName(string n){
		PlayerPrefs.SetString ("name", n);
	}

	public void SetAudio(int a){
		PlayerPrefs.SetInt ("on", a);

		if (a == 1) {
			on.gameObject.SetActive (true);
			off.gameObject.SetActive (false);
		} else if (a == 0) {
			on.gameObject.SetActive (false);
			off.gameObject.SetActive (true);
		}
	}

}
