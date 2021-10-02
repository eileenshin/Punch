using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KH_ScoreManager : MonoBehaviour
{
    public int CurrScore = 0;
    public int Combo = 0;
    public int HP = 100;

    public Text CurrScoreUI;
    public Text bestScoreUI;
    public Text HpUI;
    public Text ComboUI;
    //public int currScore;
    public int bestScore;
    
    


    public static KH_ScoreManager instance;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 100)
        {
            HP = 100;
        }
        float currTime = 0;
        if (currTime > 2)
        {
            //print(Score);
            print(Combo);
            print(HP);
            currTime = 0;
        }

        UpdateCurrScore();
        UpdateCombo();
        UpdateHp();
    }

    public void AddScore(int Score)
    {
        this.CurrScore += Score;
        Combo += 1;
        HP += 1;
    }
    public void UpdateCurrScore()
    {
        CurrScoreUI.text = "" + CurrScore;
    }
    public void UpdateCombo()
    {
        ComboUI.text = ""+Combo;
    }
    public void UpdateHp()
    {
        HpUI.text = "Hp: " + HP;
    }

    public void LoseScene()
    {
        int count = KH_GameManager.instance.listNode.Count;
        int NodeCount = KH_GameManager.instance.nodeCnt;
        if (HP <= 0)
        {
            //SceneManager.LoadScene(""); //loseScene 가져온다.
            print("HP=0");
        }
        float currTime = 0;
        currTime += Time.deltaTime;
        if (count == NodeCount)
        {
            if (currTime > 2)
            {
                //SceneManager.LoadScene(""); //loseScene 가져온다.
                print("End");
            }
        }
    }
}
