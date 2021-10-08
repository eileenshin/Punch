using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public Text ranktxt;
    public Text scoretxt;

    //¹öÆ°
    public Button btReplay;
    public Button btQuit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getGrade();

    }


    public void getGrade()
    {
        int combo = ScoreManager.instance.combo;
        float score = ScoreManager.instance.score;
        int MissCount = ScoreManager.instance.missCount;
        if (MissCount == 0)
        {
            print("Grade_S");
            ranktxt.text = "S";
            scoretxt.text =  "Score : " + score + '\n'+ "Combo : " + combo;
            
            
        }
        else if (MissCount > 0 && MissCount <= 3)
        {
            print("Grade_A");
            ranktxt.text = "A";
            scoretxt.text = "Score : " + score + '\n' + "Combo : " + combo;
        }
        else if (MissCount > 3 && MissCount < 6)
        {
            print("Grade_B");
            ranktxt.text = "B";
            scoretxt.text = "Score : " + score + '\n' + "Combo : " + combo;
        }
        else if (MissCount >= 6)
        {
            print("Grade_C");
            ranktxt.text = "C";
            scoretxt.text = "Score : " + score + '\n' + "Combo : " + combo;
        }
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

