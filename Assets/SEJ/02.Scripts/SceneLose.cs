using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLose : MonoBehaviour
{

    //¹öÆ°
    public Button btReplay;
    public Button btQuit;

    public Text ranktxt;
    public Text scoretxt;

    void Start()
    {
        //if (ScoreManager.instance.isNL == false)
        //{
        //    KH_Score();
        //    print("a");

        //}

        if (ScoreManager.instance != null && ScoreManager.instance.isNL == true)
        {
            GetScore();
            print("Scoremanager b");
        }

        if (KH_ScoreManager.instance != null && KH_ScoreManager.instance.isBS == true)
        {
            KH_Score();
            print("kh scoremanager a");
        }


    }
    void Update()
    {

    }

    public void GetScore()
    {
        float score = ScoreManager.instance.score;
        float bestScore = ScoreManager.instance.bestScore;

        ranktxt.text = "F";
        scoretxt.text = '\n' + "Score : " + score + '\n' + '\n' + "Try again?";
    }
    public void KH_Score()
    {
        float score = KH_ScoreManager.instance.CurrScore;
        float bestScore = KH_ScoreManager.instance.bestScore;

        ranktxt.text = "F";
        scoretxt.text = '\n' + "Score : " + score + '\n' + '\n' + "Try again?";
    }

    public void OnClickRepaly()
    {
        SceneManager.LoadScene("SEJ_Start");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }


}
