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
        int combo = ScoreManager.instance.combo;
        float score = ScoreManager.instance.score;
        int MissCount = ScoreManager.instance.missCount;



        ranktxt.text = "F";
        scoretxt.text = "Score : " + score + '\n' + "Combo : " + combo;


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
