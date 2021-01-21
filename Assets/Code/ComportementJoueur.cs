using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComportementJoueur : MonoBehaviour
{
    public GameObject Joueur;
    public bool toucheSol = true;
    private bool positionSuperieur = true ;
    public float ScoreFloat = 0;
    public int Score = 0;
    private int PointsDeVie = 3;
    public int BugSpace = 0;
    public GameObject PanelGameOver;
    public TextMeshProUGUI Vies;
    public TextMeshProUGUI AfficheScore;

    void Start()
    {
        PanelGameOver.SetActive(false);
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        ScoreFloat += Time.deltaTime;
        Score = Mathf.FloorToInt(ScoreFloat);
        AfficheScore.text = "Score : " + Score;


        if (Input.GetKeyDown(KeyCode.DownArrow)) //glisser 
        {
            BugSpace = 1;
            transform.RotateAround(Joueur.transform.position, Vector3.forward, 90);
            Joueur.transform.Translate(1, 0, 0);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) //Rétablir glissade
        {
            BugSpace = 0;
            transform.RotateAround(Joueur.transform.position, Vector3.forward, -90);
        }

        if (toucheSol) // on détecte si notre personnage touche le sol
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) // sauter
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300)); // fait sauter le personnage
                toucheSol = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) && BugSpace == 0) // chagement de plateforme
            {
                if (positionSuperieur)
                {
                    Joueur.transform.Translate(0, -6, 2);
                    positionSuperieur = false;
                    Debug.Log(Joueur.transform.position);
                }
                else
                {
                    Joueur.transform.Translate(0, 6, -2);
                    positionSuperieur = true;
                    Debug.Log(Joueur.transform.position);
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
            PanelGameOver.SetActive(true);
            Time.timeScale = 0;
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
            ScoreFloat = ScoreFloat + 100;
            AfficheScore.text = "Score : " + ScoreFloat;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PointsDeVie = PointsDeVie - 1;
            Vies.text = "Vies : " + PointsDeVie;
            Destroy(other.gameObject);
        }
    }
}

