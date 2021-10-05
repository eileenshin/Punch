using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    //���� ��ü��  End1���� �����ϸ�
    //���������� ScoreManager�� ���ش�
    //�޺�����, ��������, ����ü��

    //�̱����������� ScoreManager ���´�
    public static ScoreManager instance = null;
    public int combo;
    public int score;
    public int bestScore;
    public int missCount;

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
        missCount = 0;
        score = 0;
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

        currScore.text = "" + score;
        comboScore.text = "Combo:" + combo;
        txtBestScore.text = "Best:" + bestScore;

        if (currHP > 100)
        {
            currHP = 100;
        }

        LoseScene();
        WinScene();
        AddScore();

    }


    //public void AddScore(int addValue)
    //{

    //    //���࿡ ���������� �ְ��������� Ŀ����
    //    if (score > bestScore)
    //    {
    //        //�ְ������� ���������� ����
    //        bestScore = score;

    //        //�ְ������� �����Ѵ� playerprefs.setint("�̸�",��)
    //        PlayerPrefs.SetInt("best_score", bestScore);
    //    }

    //}
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
                SceneManager.LoadScene("GameOver_Victory1"); //Victory �����´�.

            }
        }
    }



}
