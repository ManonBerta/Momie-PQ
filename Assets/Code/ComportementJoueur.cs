﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementJoueur : MonoBehaviour
{
    public GameObject Joueur;
    public bool toucheSol = true;
    private bool positionSuperieur = true ;
    private int Score = 0;
    private int PointsDeVie = 3;

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

            if (Input.GetKeyDown(KeyCode.Space)) // chagement de plateforme
            {
                if (positionSuperieur)
                {
                    Joueur.transform.Translate(0, -6, -2);
                    positionSuperieur = false;
                }
                else
                {
                    Joueur.transform.Translate(0, 6, 2);
                    positionSuperieur = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //ralentir
        {

        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) //accélérer
        {

        }
        if (PointsDeVie <= 0)
        {
            Debug.Log("T'es mort fdp !");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Plateforme")
        {
            toucheSol = true;
        }
        if (other.gameObject.CompareTag("Item"))
        {
            Score = Score + 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PointsDeVie = PointsDeVie - 1;
            Destroy(other.gameObject);
        }
    }
}

