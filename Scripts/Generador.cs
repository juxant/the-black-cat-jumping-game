using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {


    public GameObject[] obj;
    public float tiempoMax;
    public float tiempoMin;
    public bool activar;

    void Generar() {

        if (activar) {
            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, transform.rotation);
            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }
    }

    private void OnDisable() {
   
        activar = false;
        CancelInvoke();
    }

    private void OnEnable() {
      
        activar = true;
        Generar();
    }
}
