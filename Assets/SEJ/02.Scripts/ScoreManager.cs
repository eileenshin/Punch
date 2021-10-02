using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    //점수 자체를  End1에서 판정하면
    //점수계산은 ScoreManager가 해준다
    //콤보점수, 현재점수, 현재체력

    //싱글톤패턴으로 ScoreManager 담는다
    public static ScoreManager instance = null;
    public int combo;
    public int score;
    public int bestScore;
   
    //체력
    public float currHP;
    public float maxHP = 100;
    float percent;
    //HP UI image컴포넌트
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
        //시작HP
        currHP = maxHP;
        percent = (float)currHP / (float)maxHP;
        
    }

    // Update is called once per frame
    void Update()
    {

        HpBar.fillAmount = currHP / maxHP;
        Hp.text = currHP + "/" + maxHP;
        percent = (float)currHP / (float)maxHP;

        if (currHP > 100)
        {
            currHP = 100;
        }

        LoseScene();
    }

   
    public void AddScore(int addValue)
    {

        score += addValue;
        combo += 1;
        currHP += 1;

        currScore.text = "" + score ;
        comboScore.text = "" + combo;
        txtBestScore.text = "" + bestScore;
        


        //만약에 현재점수가 최고점수보다 커지면
        if (score > bestScore)
        {
            //최고점수를 현재점수로 갱신
            bestScore = score;

            //최고점수를 저장한다 playerprefs.setint("이름",값)
            PlayerPrefs.SetInt("best_score", bestScore);
        }

    }
    public void LoseScene()
    {
        if(currHP <=0)
        {
          //  SceneManager.LoadScene("GameOver_Lose");
        }
    }



}
