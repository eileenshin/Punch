using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{


    public static ScoreManager instance = null;
    public int combo;
    public float score;
    public float bestScore;
    public int missCount;

    //����ġ 20 50 100/ 2�� 3�� 5��
    public float weight_20 = 1.2f;
    public float weight_50 = 1.5f;
    public float weight_100 = 2.0f;




    public float currHP;
    public float maxHP = 100;
    float percent;
    //IMAGE UI
    public Image HpBar;
    public Image BackHpBar;
    //Text UI
    public Text Hp;
    public Text currScore;
    public Text comboScore;
    public Text txtBestScore;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        missCount = 0;
        score = 0;
    
        currHP = maxHP;
        percent = (float)currHP / (float)maxHP;

        //bestScore ���̰��ϱ�
        bestScore = PlayerPrefs.GetFloat("Best_1");
        txtBestScore.text = "Best: " + bestScore;

    }

    void Update()
    {


        HpBar.fillAmount = currHP / maxHP;
        Hp.text = currHP + "/" + maxHP;
        percent = (float)currHP / (float)maxHP;

        currScore.text = "" + score;
        comboScore.text = "Combo:" + combo;
        

        

        if (currHP > 100)
        {
            currHP = 100;
        }

        LoseScene();
        WinScene();
       

    }

    public void ScoreWeight(int score)
    {
        if (combo < 20)
        {
            this.score += score;
        }

        else if (combo >= 20 && combo < 50)
        {
            this.score += score * weight_20;
        }

        else if (combo >= 50 && combo < 100)
        {
            this.score += score * weight_50;
        }

        else if (combo >= 100)
        {
            this.score += score * weight_100;
        }
    }


    public void AddScore(int Score)
    {

        combo += 1;
        currHP += 1;
        ScoreWeight(Score);

        if (score>bestScore)
        {
            bestScore = score;
            txtBestScore.text = "Best:" + bestScore;
            PlayerPrefs.SetFloat("Best_1", bestScore);
        }
 
    }
    public void LoseScene()
    {
        if(currHP <=0)
        {
          SceneManager.LoadScene("GameOver_Lose");
        }
    }
    float EndTime = 0;
    public void WinScene()
    {
        int count = GameManager.instance.listNode.Count;
        int nodeCnt = GameManager.instance.nodeCnt;
        print("count: " + count);
        print("Nodecount: " + nodeCnt);
        if (count == nodeCnt)
        {

            EndTime += Time.deltaTime;
            if (EndTime > 5)
            {
                SceneManager.LoadScene("GameOver_Victory1"); //Victory
            }
        }
    }



}
