using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float fuerzaSalto;
    public bool enSuelo;
    public bool dobleSalto;
    private Rigidbody2D rb2d;
    private Animator animator;
    private bool corriendo;
    public float velocidad;
    public GameObject[] generadores;
    public GameObject puntuacion;
    public GameObject textoPajaro;
    public GameObject textoHeladera;
    public GameObject edificioGrande;
    private bool choco = true;
    public GameObject vidasText;
    public GameObject textoMuerte;
    public GameObject fiambreria;
    public GameObject textoFiambreria;
    public int vidas;
    public float tiempo;

    void Start() {
        vidas = 7;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
  
    void Update () {

        if (corriendo) {
            tiempo += Time.deltaTime;
        }

        if(Mathf.RoundToInt(tiempo) == 60) {
            tiempo = 0;
            Instantiate(fiambreria, generadores[0].transform.position, Quaternion.identity);
        }

        if(vidas == 0) {
            PlayerPrefs.SetString("Puntuacion", puntuacion.GetComponent<TextMesh>().text);
            SceneManager.LoadScene(2);

        }

        if (corriendo) {
            rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
        }
        animator.SetFloat("velX", rb2d.velocity.x);
        animator.SetBool("enSuelo", enSuelo);


        if (enSuelo) {
            dobleSalto = false;
        }

        if (Input.GetMouseButtonDown(0)) {

            if (corriendo) {

                if (enSuelo || !dobleSalto) {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, fuerzaSalto);

                    if (!dobleSalto && !enSuelo) {
                        dobleSalto = true;
                    }
                }
            } else {
                corriendo = true;
                EmpezarRun(true);
                choco = true;
                puntuacion.GetComponent<Puntuacion>().enabled = true;
            }
        }
		
	}

    void EmpezarRun(bool condicion) {

        for (int i = 0; i < generadores.Length; i++) {
            generadores[i].GetComponent<Generador>().enabled = condicion;
            
        }    

        puntuacion.GetComponent<Puntuacion>().activar = condicion;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag == "Pajaro") {
            puntuacion.GetComponent<Puntuacion>().IncrementarPuntos(500);
            Instantiate(textoPajaro, collision.gameObject.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);   
        }

        if (collision.gameObject.tag == "Heladera") {
            puntuacion.GetComponent<Puntuacion>().IncrementarPuntos(1000);
            Instantiate(textoHeladera, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (choco) {
            if (collision.gameObject.tag == "Destructor") {

                choco = false;
                rb2d.velocity = Vector2.zero;
                Instantiate(edificioGrande, transform.position, Quaternion.identity);
                transform.position = new Vector3(transform.position.x, transform.position.y + 7);
                vidasText.GetComponent<TextMesh>().text = "LIVES : " + --vidas;
                puntuacion.GetComponent<Puntuacion>().IncrementarPuntos(-1500);
                Instantiate(textoMuerte, transform.position, Quaternion.identity);
                corriendo = false;
                EmpezarRun(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Heladera") {
            puntuacion.GetComponent<Puntuacion>().IncrementarPuntos(1000);
            Instantiate(textoHeladera, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Fiambreria") {
            puntuacion.GetComponent<Puntuacion>().IncrementarPuntos(5000);
            Instantiate(textoFiambreria, transform.position, Quaternion.identity);
            PlayerPrefs.SetString("Puntuacion", puntuacion.GetComponent<TextMesh>().text);
            animator.SetBool("Win", true);
            corriendo = false;
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
            Invoke("Win", 3);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        
    }

    void Win() {
        SceneManager.LoadScene(3);
    }
}
