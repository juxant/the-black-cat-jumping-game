using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSuelo : MonoBehaviour {

    private Player player;


	void Start () {
        player = GetComponentInParent<Player>();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Suelo") {
            player.enSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Suelo") {
            player.enSuelo = false;
        }
    }
}
