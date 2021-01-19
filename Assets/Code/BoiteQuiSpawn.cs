using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiteQuiSpawn : MonoBehaviour
{
    public GameObject caissePrefab;  //On met tous les préfab en gameobject
    public GameObject scarabeePrefab;
    public GameObject pilierPrefab;
    public GameObject pqPrefab;
    public float TempsApparitionObstacle = 1;
    public float TempsApparitionPQ;
    public int NombreSpawn;
    private Vector2 bordEcran;  // On définit les bords de l'écran
    // Start is called before the first frame update
    void Start()
    {
        bordEcran = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); // Définition bord écran
        StartCoroutine(SpawnDeObstacle()); // On appelle les coroutines du bas à se répéter
        //StartCoroutine(SpawnDeScarabees());
        //StartCoroutine(Spawn());
        StartCoroutine(SpawnDePQ());
    }

    private void SpawnObstacle() //fonction pour les caisses
    {
        NombreSpawn = Random.Range(0, 3);

        if (NombreSpawn == 0)
        {
            GameObject caisse = Instantiate(caissePrefab) as GameObject;
            if (Random.Range(0, 2) == 0)
            {
                caisse.transform.position = new Vector3(bordEcran.x * -2, -3.45f); //Coordonées où il apparait
            }
            else
            {
                caisse.transform.position = new Vector3(bordEcran.x * -2, 2.50f); //Coordonées où il appara
            }
        }
        
        else if (NombreSpawn == 1)
        {
            GameObject scarabee = Instantiate(scarabeePrefab) as GameObject;
            if (Random.Range(0, 2) == 0)
            {
                scarabee.transform.position = new Vector3(bordEcran.x * -2, -2.05f); //Coordonées où il apparait
            }
            else
            {
                scarabee.transform.position = new Vector3(bordEcran.x * -2, 3.90f);
            }
        }


        else if (NombreSpawn == 2)
        {
            GameObject pilier = Instantiate(pilierPrefab) as GameObject;
            if (Random.Range(0, 2) == 0)
            {
                pilier.transform.position = new Vector3(bordEcran.x * -2, -1.630f); //Coordonées où il apparait
            }
            else
            {
                pilier.transform.position = new Vector3(bordEcran.x * -2, 4.40f);
            }
        }
    }
   /* private void SpawnScarabée() //fonction pour les scarabées
    {
        
        
        GameObject scarabee = Instantiate(scarabeePrefab) as GameObject;
        scarabee.transform.position = new Vector2(bordEcran.x * -2, -2.30f); //Coordonées où il apparait
    
}
    /*private void SpawnPilier() //fonction pour les piliers
    {
        
        
            GameObject pilier = Instantiate(pilierPrefab) as GameObject;
            pilier.transform.position = new Vector2(bordEcran.x * -2, -1.630f); //Coordonées où il apparait
        
    }
    */
    private void SpawnPQ() //fonction pour le PQ
    {
        GameObject pq = Instantiate(pqPrefab) as GameObject;
        pq.transform.position = new Vector2(bordEcran.x * -2, Random.Range(-0.5f, -3.3f)); //Coordonées où il apparait
    }
    IEnumerator SpawnDeObstacle()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(TempsApparitionObstacle);
            SpawnObstacle();
        }
    }
    /*IEnumerator SpawnDeScarabees()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(TempsApparitionScarabee);
            SpawnScarabée();
        }
    }
   /* IEnumerator SpawnDePiliers()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
         
            
                yield return new WaitForSeconds(TempsApparitionPilier);
                SpawnPilier();
            
        }
    }
   */
    IEnumerator SpawnDePQ()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10, 15));
            SpawnPQ();
        }
    }
}
