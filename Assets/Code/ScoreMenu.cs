using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreMenu : MonoBehaviour
{
    public int ScoreActuel;
    private int MS3;
    private int MS2;
    private int MS1;
    private int SaveScore;
    public TextMeshProUGUI TMS1;
    public TextMeshProUGUI TMS2;
    public TextMeshProUGUI TMS3;
    void Start()
    {
      ScoreActuel =  PlayerPrefs.GetInt("ScoreDuJoueur");
        MS3 = PlayerPrefs.GetInt("SMS3");
        MS2 = PlayerPrefs.GetInt("SMS2");
        MS1 = PlayerPrefs.GetInt("SMS1");
        if (ScoreActuel > MS3)
        {
            MS3 = ScoreActuel;
            PlayerPrefs.SetInt("SMS3", MS3);
        }
      if (MS3 > MS2)
        {
            SaveScore = MS2;
            MS2 = MS3;
            MS3 = SaveScore;
            PlayerPrefs.SetInt("SMS3", SaveScore);
            PlayerPrefs.SetInt("SMS2", MS2);
        }
      if (MS2 > MS1)
        {
            SaveScore = MS1;
            MS1 = MS2;
            MS2 = SaveScore;
            PlayerPrefs.SetInt("SMS2", SaveScore);
            PlayerPrefs.SetInt("SMS1", MS1);
        }
        TMS3.text = "#3 : " + MS3;
        TMS2.text = "#2 : " + MS2;
        TMS1.text = "#1 : " + MS1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
