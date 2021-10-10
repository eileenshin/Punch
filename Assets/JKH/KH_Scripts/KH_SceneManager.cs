using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KH_SceneManager : MonoBehaviour
{
    //int ii = KH_SwipeMenu.instance.ii;
    public static KH_SceneManager instance;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickStartButton()
    {
        SceneManager.LoadScene("KH_GameScene");
    }

    public void onClickNextLevel()
    {
        SceneManager.LoadScene("SEJ_Scene");
    }
    
    public void onClickStartBtn()
    {
        if (KH_SwipeMenu.instance.isShark == true)
        {
            SceneManager.LoadScene("KH_GameScene");
        }

        else if (KH_SwipeMenu.instance.isNextLevel == true)
        {
            SceneManager.LoadScene("SEJ_Scene");
        }
    }


}
