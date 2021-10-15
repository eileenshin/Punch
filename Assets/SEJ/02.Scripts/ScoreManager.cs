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

    //가중치 20 50 100/ 2배 3배 5배
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

    public string EachHighestScore;
    public GameObject canvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        Init();
        

        //bestScore 보이게하기
        //bestScore = PlayerPrefs.GetFloat("Best_1");
    }

    void Updater()
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
        progress();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "KH_Closer")
        {
            Updater();
        }
        if (SceneManager.GetActiveScene().name == "KH_Nonono")
        {
            Updater();
        }
        if (SceneManager.GetActiveScene().name == "SEJ_Scene")
        {
            Updater();
        }
        if (SceneManager.GetActiveScene().name == "SEJ_Onepiece")
        {
            Updater();
        }
        if (SceneManager.GetActiveScene().name == "SEJ_Heymama")
        {
            Updater();
        }


    }
    public Text progressUI;
    public Image ProgressBar;
    public Image BackProgressBar;
    public void progress()
    {
        float count = GameManager.instance.listNode.Count;
        float nodeCnt = GameManager.instance.nodeCnt;
        //진행도
        ProgressBar.fillAmount = (nodeCnt / count);
        float percentage = (float)nodeCnt / (float)count;
        progressUI.text = "Finish" + '\n' + Mathf.Round(percentage * 100) + "%";
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

        if (score > bestScore)
        {
            bestScore = score;
            txtBestScore.text = "Best : " + bestScore;
            PlayerPrefs.SetFloat(EachHighestScore, bestScore);
        }

    }

    public bool isNL = false;


    public void LoseScene()
    {
        if (currHP <= 0)
        {
            currHP = 0;
            isNL = true;
            SceneManager.LoadScene("GameOver_Lose");
            currHP = maxHP;
            canvas.SetActive(false);
         
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
                SceneManager.LoadScene("GameOver_Victory1");
                canvas.SetActive(false);
               
            }
        }
    }

    public void Init()
    {
        combo = 0;
        score = 0;
        missCount = 0;

        currHP = maxHP;
        percent = (float)currHP / (float)maxHP;

        EachHighestScore = SceneManager.GetActiveScene().name;

        bestScore = PlayerPrefs.GetFloat(EachHighestScore);
        txtBestScore.text = "Best: " + bestScore;

        canvas.SetActive(true);
    }



}
