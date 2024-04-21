using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GererMenu : MonoBehaviour
{
    public void CommencerJeu()
    {
        SceneManager.LoadScene("niveauTUTO");
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void AfficherControles()
    {
        SceneManager.LoadScene("Commandes");
    }

    public void AfficherMention()
    {
        SceneManager.LoadScene("Mentions");
    }
    public void RevenirMenu()
    {
        SceneManager.LoadScene("MenuStart");
    }
}
