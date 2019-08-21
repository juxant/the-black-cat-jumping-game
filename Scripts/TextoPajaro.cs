using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoPajaro : MonoBehaviour {

    private Vector2 posicionInicial;

	void Start () {
        posicionInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.up * 2 * Time.deltaTime);

        if(transform.position.y > posicionInicial.y + 2) {
            Destroy(gameObject);
        }
	}
}
