using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decors : MonoBehaviour
{
    public GameObject[] decors;
    private Camera mainCamera;
    private Vector2 limiteEcrant;
    public float vitesse;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        limiteEcrant = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z)); // met dans cette variable la limite de l'ecrant
        foreach(GameObject obj in decors)
            {
            initiationObjet(obj);
        }
    }
    void initiationObjet(GameObject obj)
    {
        float objLargeur = obj.GetComponent<SpriteRenderer>().bounds.size.x; // largeur objet
        int nbcopie = (int)Mathf.Ceil(limiteEcrant.x * 2 / objLargeur); // calcule du nombre de copie pour un ecran
        GameObject clone = Instantiate(obj) as GameObject;
        nbcopie = nbcopie * (-1);
        for (int i = 0; i <= nbcopie; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objLargeur * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
