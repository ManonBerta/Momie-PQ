using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementJoueur : MonoBehaviour
{
    public GameObject Joueur;
    public bool toucheSol = true;


    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) //glisser 
        {

            transform.RotateAround(Joueur.transform.position, Vector3.forward, 90);

        }

        if (Input.GetKeyUp(KeyCode.DownArrow)) //Rétablir glissade
        {
            transform.RotateAround(Joueur.transform.position, Vector3.forward, -90);
        }
        if (toucheSol) // on détecte si notre personnage touche le sol
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) // sauter
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250)); // fait sauter le personnage
                toucheSol = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //ralentir
        {

        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) //accélérer
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Plateforme")
        {
            toucheSol = true;
        }
    }
}

