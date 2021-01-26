using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiteQuiSpawn : MonoBehaviour
{
    public GameObject caissePrefab;  //On met tous les préfab en gameobject
    public GameObject scarabeePrefab;
    public GameObject pilierPrefab;
    public GameObject PetitPotPrefab;
    public GameObject ObstacleDoubleSSPrefab;
    public GameObject ObstacleDoubleSS2Prefab;
    public GameObject ObstacleDoubleSGPrefab;
    public GameObject ObstacleDoubleGSPrefab;
    public GameObject ObstacleDoubleGGPrefab;
    public GameObject pqPrefab;
    public float TempsApparitionObstacle = 15f;
    public float TempsApparitionPQ;
    public int NombreSpawn;
    public int NombrePQ;
    private Vector2 bordEcran;  // On définit les bords de l'écran
    // Start is called before the first frame update
    void Start()
    {
        bordEcran = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); // Définition bord écran
        StartCoroutine(SpawnDeObstacle());
        StartCoroutine(SpawnDeObstacleHaut());// On appelle les coroutines du bas à se répéter
        //StartCoroutine(SpawnDeScarabees());
        //StartCoroutine(Spawn());
        StartCoroutine(SpawnDePQ());
    }

    private void SpawnObstacle() //fonction pour les caisses
    {
        NombreSpawn = Random.Range(0, 13);

        if (NombreSpawn == 0 || NombreSpawn == 4)
        {
            GameObject caisse = Instantiate(caissePrefab) as GameObject;
          
                caisse.transform.position = new Vector3(bordEcran.x * -2, -3.32f); //Coordonées où il apparait
            
           
        }


        else if (NombreSpawn == 1 || NombreSpawn == 5)
        {
            GameObject scarabee = Instantiate(scarabeePrefab) as GameObject;
            
                scarabee.transform.position = new Vector3(bordEcran.x * -2, -1.7f); //Coordonées où il apparait
           
        }


        else if (NombreSpawn == 2 || NombreSpawn == 12)
        {
            GameObject pilier = Instantiate(pilierPrefab) as GameObject;
            if (Random.Range(0, 2) == 0)
            {
                pilier.transform.position = new Vector3(bordEcran.x * -2, -1.06f); //Coordonées où il apparait
            }
            else
            {
                pilier.transform.position = new Vector3(bordEcran.x * -2, 4.77f);
            }
        }

        else if (NombreSpawn == 3 || NombreSpawn == 6)
        {
            GameObject PetitPot = Instantiate(PetitPotPrefab) as GameObject;
          
                PetitPot.transform.position = new Vector3(bordEcran.x * -2, -3.52f); //Coordonées où il apparait
           
               
        }

        else if (NombreSpawn == 7)
        {
            GameObject DoublePetitPot = Instantiate(ObstacleDoubleSSPrefab) as GameObject;

           DoublePetitPot.transform.position = new Vector3(bordEcran.x * -2, -3.63f); //Coordonées où il apparait


        }

        else if (NombreSpawn == 8)
        {
            GameObject DoublePot = Instantiate(ObstacleDoubleSS2Prefab) as GameObject;

            DoublePot.transform.position = new Vector3(bordEcran.x * -2, -3.34f); //Coordonées où il apparait


        }
        else if (NombreSpawn == 9)
        {
            GameObject DoubleScara = Instantiate(ObstacleDoubleGGPrefab) as GameObject;

            DoubleScara.transform.position = new Vector3(bordEcran.x * -2, -2.35f); //Coordonées où il apparait


        }
        else if (NombreSpawn == 10)
        {
            GameObject DoubleGS = Instantiate(ObstacleDoubleGSPrefab) as GameObject;

            DoubleGS.transform.position = new Vector3(bordEcran.x * -2, -3.28f); //Coordonées où il apparait


        }
        else if (NombreSpawn == 11)
        {
            GameObject DoubleSG = Instantiate(ObstacleDoubleSGPrefab) as GameObject;

            DoubleSG.transform.position = new Vector3(bordEcran.x * -2, -3.18f); //Coordonées où il apparait

        }
    }

        private void SpawnObstacleHaut() //fonction pour les caisses
        {
            NombreSpawn = Random.Range(0, 11);

            if (NombreSpawn == 0 || NombreSpawn == 3)
            {
                GameObject caisse = Instantiate(caissePrefab) as GameObject;

                
                    caisse.transform.position = new Vector3(bordEcran.x * -2, 2.51f); //Coordonées où il appara
                
            }


            else if (NombreSpawn == 1 || NombreSpawn == 4)
            {
                GameObject scarabee = Instantiate(scarabeePrefab) as GameObject;
                
      
              
                    scarabee.transform.position = new Vector3(bordEcran.x * -2, 3.90f);
                
            }


            else if (NombreSpawn == 2 || NombreSpawn == 5)
            {
                GameObject PetitPot = Instantiate(PetitPotPrefab) as GameObject;
                
        
                
                
                
                    PetitPot.transform.position = new Vector3(bordEcran.x * -2, 2.19f); //Coordonées où il appara
                
            }
        else if (NombreSpawn == 6)
        {
            GameObject DoublePetitPot = Instantiate(ObstacleDoubleSSPrefab) as GameObject;

            DoublePetitPot.transform.position = new Vector3(bordEcran.x * -2, 2.23f); //Coordonées où il apparait


        }

        else if (NombreSpawn == 7)
        {
            GameObject DoublePot = Instantiate(ObstacleDoubleSS2Prefab) as GameObject;

            DoublePot.transform.position = new Vector3(bordEcran.x * -2, 2.48f); //Coordonées où il apparait


        }
        else if (NombreSpawn == 8)
        {
            GameObject DoubleScara = Instantiate(ObstacleDoubleGGPrefab) as GameObject;

            DoubleScara.transform.position = new Vector3(bordEcran.x * -2, 3.12f); //Coordonées où il apparait


        }
        else if (NombreSpawn == 9)
        {
            GameObject DoubleGS = Instantiate(ObstacleDoubleGSPrefab) as GameObject;

            DoubleGS.transform.position = new Vector3(bordEcran.x * -2, 2.51f); //Coordonées où il apparait


        }
        else if (NombreSpawn == 10)
        {
            GameObject DoubleSG = Instantiate(ObstacleDoubleSGPrefab) as GameObject;

            DoubleSG.transform.position = new Vector3(bordEcran.x * -2, 2.61f); //Coordonées où il apparait

        }
    }

            /*else if (NombreSpawn == 3)
            {
                GameObject ObstacleDoubleSS = Instantiate(ObstacleDoubleSSPrefab) as GameObject;
                if (Random.Range(0, 2) == 0)
                {
                    ObstacleDoubleSS.transform.position = new Vector3(bordEcran.x * -2, -3.45f); //Coordonées où il apparait
                }
                else
                {
                    ObstacleDoubleSS.transform.position = new Vector3(bordEcran.x * -2, 2.50f);
                }
            }
            else if (NombreSpawn == 4)
            {
                GameObject ObstacleDoubleGG = Instantiate(ObstacleDoubleGGPrefab) as GameObject;
                if (Random.Range(0, 2) == 0)
                {
                    ObstacleDoubleGG.transform.position = new Vector3(bordEcran.x * -2, -2.05f); //Coordonées où il apparait
                }
                else
                {
                    ObstacleDoubleGG.transform.position = new Vector3(bordEcran.x * -2, 3.90f);
                }
            }
            else if (NombreSpawn == 5)
            {
                GameObject ObstacleDoubleGS = Instantiate(ObstacleDoubleGSPrefab) as GameObject;
                if (Random.Range(0, 2) == 0)
                {
                    ObstacleDoubleGS.transform.position = new Vector3(bordEcran.x * -2, -3.45f); //Coordonées où il apparait
                }
                else
                {
                    ObstacleDoubleGS.transform.position = new Vector3(bordEcran.x * -2, 2.50f);
                }
            }
            else if (NombreSpawn == 6)
            {
                GameObject ObstacleDoubleSG = Instantiate(ObstacleDoubleSGPrefab) as GameObject;
                if (Random.Range(0, 2) == 0)
                {
                    ObstacleDoubleSG.transform.position = new Vector3(bordEcran.x * -2, -3.45f); //Coordonées où il apparait
                }
                else
                {
                    ObstacleDoubleSG.transform.position = new Vector3(bordEcran.x * -2, 2.50f);
                }
            }*/

        
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
        NombrePQ = Random.Range(0, 2);
        if (NombrePQ == 0)
        {
            pq.transform.position = new Vector3(bordEcran.x * -2, Random.Range(-0.5f, -3.3f)); //Coordonées où il apparait
        }
        else
        {
            pq.transform.position = new Vector3(bordEcran.x * -2, Random.Range(3.40f, 5.6f)); //Coordonées où il apparait
        }
    }
    IEnumerator SpawnDeObstacle()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(TempsApparitionObstacle);
            SpawnObstacle();
        }
    }

    IEnumerator SpawnDeObstacleHaut()  //Permet de faire en boucle l'apparition des trucs
    {
        while (true)
        {
            yield return new WaitForSeconds(TempsApparitionObstacle);
            SpawnObstacleHaut();
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
