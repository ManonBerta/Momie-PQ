using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiteQuiSpawn : MonoBehaviour
{
    public GameObject caissePrefab;  //On met tous les préfab en gameobject
    public GameObject scarabeePrefab;
    public GameObject pilierPrefab;
    public GameObject pqPrefab;
    public int NombreCollider;
    public float TempsApparitionCaisse = 2;  // Temps entre chaque apparition
    public float TempsApparitionPilier = 5;
    public float TempsApparitionScarabee = 3;
    public float TempsApparitionPQ;
    private Vector2 bordEcran;  // On définit les bords de l'écran
    // Start is called before the first frame update
    void Start()
    {
        bordEcran = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); // Définition bord écran
        StartCoroutine(SpawnDeCaisses()); // On appelle les coroutines du bas à se répéter
        StartCoroutine(SpawnDeScarabees());
        StartCoroutine(SpawnDePiliers());
        StartCoroutine(SpawnDePQ());
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
            NombreCollider = NombreCollider + 1;
        
    }

    void OnTriggerExit2D(Collider2D Col)
    {

            NombreCollider = NombreCollider - 1;
        
    }
    private void SpawnCaisse() //fonction pour les caisses
    {
        if (NombreCollider <= 3)
        {
            GameObject caisse = Instantiate(caissePrefab) as GameObject;
            caisse.transform.position = new Vector2(bordEcran.x * -2, -3.45f); //Coordonées où il apparait
        }
    }
    private void SpawnScarabée() //fonction pour les scarabées
    {
        if (NombreCollider <= 3)
        {
        GameObject scarabee = Instantiate(scarabeePrefab) as GameObject;
        scarabee.transform.position = new Vector2(bordEcran.x * -2, -2.30f); //Coordonées où il apparait
    }
}
    private void SpawnPilier() //fonction pour les piliers
    {
        if (NombreCollider <= 3)
        {
            GameObject pilier = Instantiate(pilierPrefab) as GameObject;
            pilier.transform.position = new Vector2(bordEcran.x * -2, -1.630f); //Coordonées où il apparait
        }
    }
    private void SpawnPQ() //fonction pour le PQ
    {
        GameObject pq = Instantiate(pqPrefab) as GameObject;
        pq.transform.position = new Vector2(bordEcran.x * -2, Random.Range(-0.5f, -3.3f)); //Coordonées où il apparait
    }
    IEnumerator SpawnDeCaisses()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(TempsApparitionCaisse);
            SpawnCaisse();
        }
    }
    IEnumerator SpawnDeScarabees()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(TempsApparitionScarabee);
            SpawnScarabée();
        }
    }
    IEnumerator SpawnDePiliers()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(TempsApparitionPilier);
            SpawnPilier();
        }
    }
    IEnumerator SpawnDePQ()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10, 15));
            SpawnPQ();
        }
    }
}
