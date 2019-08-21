using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour {

    private TextMesh textoPuntuacion;
    public int puntuacion;
    public bool activar;

    void Start () {
        activar = true;
        textoPuntuacion = GetComponent<TextMesh>();
    }
	
	void Update () {

        if (activar) {
            puntuacion += Mathf.RoundToInt(Time.deltaTime * 100);
        }
        textoPuntuacion.text = puntuacion.ToString();
	}

    public void IncrementarPuntos(int puntos) {

        puntuacion += puntos;
        
    }
}
