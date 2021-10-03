using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KH_Result : MonoBehaviour
{
    public static KH_Result instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getGrade()
    {
        int MissCount = KH_ScoreManager.instance.MissCnt;
        if (MissCount == 0)
        {
            print("Grade_S");
        }
        else if(MissCount>0 && MissCount <= 3)
        {
            print("Grade_A");
        }
        else if (MissCount > 3 && MissCount < 6)
        {
            print("Grade_B");
        }
        else if (MissCount >= 6)
        {
            print("Grade_C");
        }
    }
   
    public void getScore()
    {
        int Score = KH_ScoreManager.instance.CurrScore;
        //public Text ResultScore;
        //Eg)ResultScore.text = "ResultScore: " + ResultScore;
    }
}
