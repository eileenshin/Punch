using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SEJ_SceneManager : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "NextLevel":
                SceneManager.LoadScene("KH_GameScene");
                break;
            case "BabyShark":
                SceneManager.LoadScene("JKH_");
                break;


        }
    }
}
