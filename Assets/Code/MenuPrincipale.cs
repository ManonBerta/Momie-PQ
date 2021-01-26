using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipale : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip SonRejouer;
        private AudioSource audiosource;
    private void Start()
    {
        audiosource = GetComponent < AudioSource>();
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void MenuMS()
    {
        SceneManager.LoadScene(2);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Jouer()
    {
        SceneManager.LoadScene(1);
    }
    IEnumerator AttenteSonJoueur()
    {
        audiosource.PlayOneShot(SonRejouer, 1f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}