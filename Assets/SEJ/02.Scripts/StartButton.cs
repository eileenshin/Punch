using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.instance != null)
            ScoreManager.instance.isNL = false;
        if(KH_ScoreManager.instance != null)
            KH_ScoreManager.instance.isBS = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void onClickStartButton()
    //{
    //    SceneManager.LoadScene("KH_GameScene");
    //}

    //public void onClickNextLevel()
    //{
    //    SceneManager.LoadScene("SEJ_Scene");
    //}
    
    public void OnClickGo()
    {
        if (StartScroll.instance.isShark == true)
        {
            SceneManager.LoadScene("KH_GameScene");
        }

        else if (StartScroll.instance.isNextLevel == true)
        {
            SceneManager.LoadScene("SEJ_Scene");
        }
        else if (StartScroll.instance.isHeyMama == true)
        {
            SceneManager.LoadScene("SEJ_Heymama");
        }
        else if (StartScroll.instance.isOnePiece == true)
        {
            SceneManager.LoadScene("SEJ_Onepiece");
        }
        else if (StartScroll.instance.isNonono == true)
        {
            SceneManager.LoadScene("KH_Nonono");
        }
        else if (StartScroll.instance.isCloser == true)
        {
            SceneManager.LoadScene("KH_Closer");
        }
    }

}
