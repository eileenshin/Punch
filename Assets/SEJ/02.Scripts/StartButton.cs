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
    
    public void OnClickGo()
    {
        
    }

}
