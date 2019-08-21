using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public Transform player;
	
	void Update () {
        transform.position = new Vector3(player.transform.position.x +8, transform.position.y, transform.position.z);
	}
}
