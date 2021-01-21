using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decors : MonoBehaviour
{
    public GameObject[] decors;
    private Camera mainCamera;
    private Vector2 limiteEcrant;
    public float vitesse;
    public float enchevetrement;
    private float objLargeur;
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
        objLargeur = obj.GetComponent<SpriteRenderer>().bounds.size.x; // largeur objet
        int nbcopie = (int)Mathf.Ceil(limiteEcrant.x * 2 / objLargeur); // calcule du nombre de copie pour un ecran
        GameObject clone = Instantiate(obj) as GameObject;
        nbcopie = nbcopie * (-1) +3;
        for (int i = 0; i <= nbcopie; i++) //crée a la suite les copies
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objLargeur * i -5, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone); 
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    void repositionnerDecord(GameObject obj)
    {
        Transform[] enfant = obj.GetComponentsInChildren<Transform>(); //création de liste chainée, on aura le premierre element et le derniere, et on le modifira aux fur a a mesure
        if (enfant.Length > 1)
        {
            GameObject premiereEnfant = enfant[1].gameObject; // premiere element de la liste
            GameObject dernierEnfant = enfant[enfant.Length - 1].gameObject; // deuxieme element de la liste
            float halfObjectWidth = dernierEnfant.GetComponent<SpriteRenderer>().bounds.extents.x + enchevetrement; 
            if (transform.position.x + limiteEcrant.x + objLargeur +20 > dernierEnfant.transform.position.x + halfObjectWidth)
            {
                premiereEnfant.transform.SetAsLastSibling();
                premiereEnfant.transform.position = new Vector3(dernierEnfant.transform.position.x + halfObjectWidth * 2, dernierEnfant.transform.position.y, dernierEnfant.transform.position.z);
            }
            else if (transform.position.x - limiteEcrant.x - objLargeur +20 < premiereEnfant.transform.position.x - halfObjectWidth)
            {
                dernierEnfant.transform.SetAsFirstSibling();
                dernierEnfant.transform.position = new Vector3(premiereEnfant.transform.position.x - halfObjectWidth * 2, premiereEnfant.transform.position.y, premiereEnfant.transform.position.z);
            }
        }
    }
    void LateUpdate()
    {
        foreach (GameObject obj in decors)
        {
            repositionnerDecord(obj);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
