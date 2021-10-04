using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLose : MonoBehaviour
{

    //¹öÆ°
    public Button btReplay;
    public Button btQuit;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

                         
    public void OnClickRepaly()
    {
        SceneManager.LoadScene("KH_StartScene");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }


}
