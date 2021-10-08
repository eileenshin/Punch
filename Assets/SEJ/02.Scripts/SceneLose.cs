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
        
    }

    void Update()
    {
       
    }
    public void GetScore()
    {
        float score = ScoreManager.instance.score;

        ranktxt.text = "F";
        scoretxt.text = "Score : " + score + '\n' + "Try again?";
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
