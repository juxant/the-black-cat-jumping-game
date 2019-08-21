using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotonJugar : MonoBehaviour {

    private void OnMouseDown() {
        SceneManager.LoadScene(1);
    }
}
