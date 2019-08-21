using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Instantiate(gameObject, new Vector3(transform.position.x + 22.150f, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
