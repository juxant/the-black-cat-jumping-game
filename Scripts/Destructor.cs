using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Pies") {
            Destroy(collision.gameObject);
        }
    }
}
