using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    //���� ��ü��  End1���� �����ϸ�
    //��������� ScoreManager�� ���ش�
    //�޺�����, ��������, ����ü��

    //�̱����������� ScoreManager ��´�
    public static ScoreManager instance = null;
    public int combo;
    public int score;
    public int bestScore;
   
    //ü��
    public float currHP;
    public float maxHP = 100;
    float percent;
    //HP UI image������Ʈ
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
        //����HP
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

        currScore.text = ""+ score ;
        comboScore.text = "Combo:" + combo;
        txtBestScore.text = "Best:" + bestScore;
        


        //���࿡ ���������� �ְ��������� Ŀ����
        if (score > bestScore)
        {
            //�ְ������� ���������� ����
            bestScore = score;

            //�ְ������� �����Ѵ� playerprefs.setint("�̸�",��)
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
