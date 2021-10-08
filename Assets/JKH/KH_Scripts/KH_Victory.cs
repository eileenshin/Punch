using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KH_Victory : MonoBehaviour
{

    public Text ranktxt;
    public Text scoretxt;
    public Text BestScoreUI;
    // Start is called before the first frame update
    void Start()
    {
        KH_getGrade();
        BestScoreUI.text = "Best: " + KH_ScoreManager.instance.bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KH_getGrade()
    {
        int combo = KH_ScoreManager.instance.Combo;
        float score = KH_ScoreManager.instance.CurrScore;
        int MissCount = KH_ScoreManager.instance.MissCnt;
        if (MissCount == 0)
        {
            print("Grade_S");
            ranktxt.text = "S";
            scoretxt.text = "Score : " + score + '\n' + "Combo : " + combo;


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
}
