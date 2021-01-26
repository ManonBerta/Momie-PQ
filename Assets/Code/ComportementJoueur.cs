using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComportementJoueur : MonoBehaviour
{
    public GameObject Joueur;
    public bool toucheSol = true;
    private bool positionSuperieur = true;
    private bool saut = true;
    public float ScoreFloat = 0;
    public int Score = 0;
    public int ScoreDuJoueur;
    private int PointsDeVie = 3;
    public int BugSpace = 0;
    public GameObject PanelGameOver;
    public TextMeshProUGUI Vies;
    public Animator animator;
    public TextMeshProUGUI AfficheScore;
    public AudioClip Impact;
    public AudioClip Saut;
    public AudioClip fin;
    public AudioClip Glissade;
    public AudioClip Bonus;
    public AudioClip Musique;
    public AudioSource Audiosource;

    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
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
            BugSpace = 1; // Empêche le joueur d'utiliser espace en pleine glissade
            saut = false;
            Audiosource.PlayOneShot(Glissade, 1f);
            transform.RotateAround(Joueur.transform.position, Vector3.forward, 90);
            Joueur.transform.Translate(1, 0, 0);
            animator.SetBool("Dash", true);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) //Rétablir glissade
        {
            BugSpace = 0;
            saut = true;
            transform.RotateAround(Joueur.transform.position, Vector3.forward, -90);
            animator.SetBool("Dash", false);
        }

        if (toucheSol) // on détecte si notre personnage touche le sol
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) // sauter
            {
                if (saut)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300)); // fait sauter le personnage
                    toucheSol = false;
                    animator.SetBool("saut", false);
                    saut = false;
                }
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
            Audiosource.PlayOneShot(fin, 1f);
            Time.timeScale = 0;
            ScoreDuJoueur = Score;
            PlayerPrefs.SetInt("ScoreDuJoueur", ScoreDuJoueur);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Plateforme")
        {
            toucheSol = true;
            animator.SetBool("saut", true);
            saut = true;
        }
        if (other.gameObject.CompareTag("Item"))
        {
            Audiosource.PlayOneShot(Bonus, 0.7f);
            ScoreFloat = ScoreFloat + 100;
            AfficheScore.text = "Score : " + ScoreFloat;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Audiosource.PlayOneShot(Impact, 0.7f);
            PointsDeVie = PointsDeVie - 1;
            Vies.text = "Vies : " + PointsDeVie;
            Destroy(other.gameObject);
        }
    }
}


