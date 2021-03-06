using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KH_ScoreManager : MonoBehaviour
{
    public float CurrScore = 0;
    public int Combo = 0;

    //가중치 20 50 100/ 2배 3배 5배
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

    //나중에할거 진행도
    public Image ProgressBar;
    public Image BackProgressBar;

    public GameObject canvas;


    public static KH_ScoreManager instance;

    public bool isBS = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //bestScore 보이게하기
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

        //currHP = maxHP;  //Max HP

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

        else if (Combo >= 20 && Combo < 50)
        {
            this.CurrScore += Score * weight_20;
        }

        else if (Combo >= 50 && Combo < 100)
        {
            this.CurrScore += Score * weight_50;
        }

        else if (Combo >= 100)
        {
            this.CurrScore += Score * weight_100;
        }

        //만약 최고점수를 넘는다면
        if (CurrScore > bestScore)
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
        //진행도
        ProgressBar.fillAmount = (nodeCnt / count);
        float percentage = (float)nodeCnt / (float)count;
        progressUI.text = "Finish" + '\n' + Mathf.Round(percentage * 100) + "%";
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
        ComboUI.text = "Combo : " + Combo;
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
            currHP = 0;
            isBS = true;
            SceneManager.LoadScene("GameOver_Lose"); //loseScene 가져온다.
            print("Lose");
            currHP = maxHP;
            canvas.SetActive(false);
        }


    }

    public void VictoryScene()
    {
        int count = KH_GameManager.instance.listNode.Count;
        int nodeCnt = KH_GameManager.instance.nodeCnt;
        //print("Count갯수" + count);
        //print("NodeCnt갯수" + nodeCnt);
        if (count == nodeCnt)
        {

            EndTime += Time.deltaTime;
            if (EndTime > 4.5f)
            {
                SceneManager.LoadScene("KH_VictoryScene"); //Victory 가져온다.
                print("Victory");
                canvas.SetActive(false);
            }
        }
    }
    public void Miss()
    {

    }

    public void Init()
    {
        Combo = 0;
        CurrScore = 0;
        MissCnt = 0;

        currHP = maxHP;
        percent = (float)currHP / (float)maxHP;

        bestScore = PlayerPrefs.GetFloat("Best");
        bestScoreUI.text = "Best: " + bestScore;

        canvas.SetActive(true);
    }
}
