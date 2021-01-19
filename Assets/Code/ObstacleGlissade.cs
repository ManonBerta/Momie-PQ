using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGlissade : MonoBehaviour
{
    public float Vitesse = 10;   // Vitesse du scarabée
    private Rigidbody2D rb;
    public Rigidbody2D ColliderSpawn;
    private Vector2 bordEcran;  // Bord de l'écran 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-Vitesse, 0);  // On dit que l'objet se déplace en x mais pas en y
        bordEcran = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));  // On définit les bords de l'écran
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < bordEcran.x * 2)   //Si l'objet est plus loin que 2 fois le bord de l'écran, il est détruit !
        {
            Destroy(this.gameObject);
        }
    }
}
