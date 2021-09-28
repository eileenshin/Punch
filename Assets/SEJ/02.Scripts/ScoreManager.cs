using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //현재점수, 최고점수, 콤보점수
    private int currScore;
    private int bestScore;

    //싱글톤패턴으로 ScoreManager 담는다
    public static ScoreManager instance = null;
    //점수 자체를  End1에서 판정하면
    //점수계산은 ScoreManager가 해준다
    public int combo;
    public int score;
    public int Hp;


    //점수 열거형
    enum ScoreM
    {
        perfect, //0
        good,     //1
        bad,      //2
        miss      //3
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hp > 100)
        {
            Hp = 100;
        }

    }

    //public 다른곳에서도 쓸 수 있게 하겠다
    public void AddScore(int addValue)
    {

        //가져온 컴포넌트의 현재점수 값을 증가시키자 
        currScore += addValue;


        //만약에 현재점수가 최고점수보다 커지면
        if (currScore > bestScore)
        {
            //최고점수를 현재점수로 갱신
            bestScore = currScore;

            //최고점수를 저장한다 playerprefs.setint("이름",값)
            PlayerPrefs.SetInt("best_score", bestScore);
        }
    }
}
