using UnityEngine;
using System.Collections;

public class scr : MonoBehaviour {

	int r = 244;
	int g = 145;
	int b = 145;

	bool up = true;

	bool bb = true;
	bool br = false;
	bool bg = false;

	void FixedUpdate () {

		if (bb == true && b < 244 && up == true) {
			b++;
			if(b == 244){
				bb = false;
				br = true;
				up = false;
			}
		}

		else if(br == true && r >144 && up == false) {
			r--;
			if (r == 145) {
				br = false;
				bg = true;
				up = true;
			}
		}

		else if ( bg == true  && g < 244 && up == true) {
			g++;
			if (g == 244) {
				bg = false;
				bb = true;
				up = false;
			}
		}

		if (bb == true && b > 145 && up == false) {
			b--;
			if(b == 145){
				bb = false;
				br = true;
				up = true;
			}
		}
		
		else if(br == true && r < 244 && up == true) {
			r++;
			if (r == 244) {
				br = false;
				bg = true;
				up = false;
			}
		}
		
		else if ( bg == true  && g > 145 && up == false) {
			g--;
			if (g == 145) {
				bg = false;
				bb = true;
				up = true;
			}
		}


		Camera.main.backgroundColor = new Color (r/255f, g/255f, b/255f, 5);

	}
}
