﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajaro : MonoBehaviour {

	
	void Update () {
        transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y,transform.position.z);
	}
}
