using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipale : MonoBehaviour
{
    // Start is called before the first frame update
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void MenuMS()
    {
        SceneManager.LoadScene(2);
    }
}