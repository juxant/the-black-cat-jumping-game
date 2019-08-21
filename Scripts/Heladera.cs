using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heladera : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag == "Suelo") {
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
