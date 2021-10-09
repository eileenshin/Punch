using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KH_ScoreManager : MonoBehaviour
{
    public float CurrScore = 0;
    public int Combo = 0;

    //����ġ 20 50 100/ 2�� 3�� 5��
    public float weight_20 = 2f;
    public float weight_50 = 3f;
    public float weight_100 = 5f;


    //Text UI 
    public Text CurrScoreUI;
    public Text bestScoreUI;
    public Text HpUI;
    public Text ComboUI;
    //public int currScore;
    public float bestScore;
    float EndTime = 0;
    public int MissCnt;


    public float currHP;
    public float maxHP = 100;
    public Image HpBar;
    public Image BackHpBar;
    
    float percent;

    //���߿��Ұ� ���൵
    public Image ProgressBar;
    public Image BackProgressBar;


    public static KH_ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //bestScore ���̰��ϱ�
        bestScore = PlayerPrefs.GetFloat("Best");
        bestScoreUI.text = "Best: " + bestScore;


        currHP = maxHP;
        Combo = 0;
        CurrScore = 0;
        MissCnt = 0;

    }

    // Update is called once per frame
    void Update()
    {





        currHP = maxHP;

        if (currHP > 100)
        {
            currHP = 100;
        }
        float currTime = 0;
        if (currTime > 2)
        {
            //print(Score);
            print(Combo);
          
            currTime = 0;
        }

        UpdateCurrScore();
        UpdateCombo();
        UpdateHp();
        LoseScene();
        VictoryScene();
        progress();
    }

    public void AddScore(int Score)
    {
        
        Combo += 1;
        currHP += 1;
        if (Combo < 20)
        {
            this.CurrScore += Score;
        }

        else if (Combo >= 20&& Combo<50)
        {
            this.CurrScore += Score * weight_20;
        }

        else if(Combo >= 50 && Combo < 100)
        {
            this.CurrScore += Score * weight_50;
        }

        else if(Combo >= 100)
        {
            this.CurrScore += Score * weight_100;
        }

        //���� �ְ������� �Ѵ´ٸ�
        if(CurrScore> bestScore)
        {
            bestScore = CurrScore;
            bestScoreUI.text = "Best: " + bestScore;
            PlayerPrefs.SetFloat("Best", bestScore);
            
        }
    }

    public Text progressUI;
    public void progress() //@@@@@@@
    {
        float count = KH_GameManager.instance.listNode.Count;
        float nodeCnt = KH_GameManager.instance.nodeCnt;
        //���൵
        ProgressBar.fillAmount = (nodeCnt / count);
        float percentage = (float)nodeCnt / (float)count;
        progressUI.text = Mathf.Round(percentage*100) + "%";
    }
    public void UpdateBestScore()
    {
        
    }
    public void UpdateCurrScore()
    {
        CurrScoreUI.text = "" + CurrScore;
    }
    public void UpdateCombo()
    {
        ComboUI.text = "Combo : "+Combo;
    }
    public void UpdateHp()
    {
        HpBar.fillAmount = currHP / maxHP;
        HpUI.text = currHP + "/" + maxHP;
        percent = (float)currHP / (float)maxHP;
    }

    public void LoseScene()
    {
        
        if (currHP <= 0)
        {
            SceneManager.LoadScene("GameOver_Lose"); //loseScene �����´�.
            print("Lose");
        }
        
        
    }

    public void VictoryScene()
    {
        int count = KH_GameManager.instance.listNode.Count;
        int nodeCnt = KH_GameManager.instance.nodeCnt;
        //print("Count����" + count);
        //print("NodeCnt����" + nodeCnt);
        if (count == nodeCnt) 
        {

            EndTime += Time.deltaTime;
            if (EndTime > 4.5f)
            {
                SceneManager.LoadScene("KH_VictoryScene"); //Victory �����´�.
                print("Victory");
            }
        }
    }
    public void Miss()
    {
        
    }
}
