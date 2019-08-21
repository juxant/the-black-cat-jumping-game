using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMainMenu : MonoBehaviour {

	
	void Update () {
        GetComponent<TextMesh>().text = "Score : " + PlayerPrefs.GetString("Puntuacion");
	}
}
