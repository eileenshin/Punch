using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_BarManager : MonoBehaviour
{
    public GameObject End1;
    public GameObject End2;
    //public GameObject Benchmark;
    //DestroyBar EndBar1 = GameObject.Find("EndPos1").GetComponent<DestroyBar>();
    //DestroyBar_2 EndBar2 = GameObject.Find("EndPos2").GetComponent<DestroyBar_2>();
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            End1.SetActive(true);
        }
        else
        {
            End1.SetActive(false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            End2.SetActive(true);
        }
        else
        {
            End2.SetActive(false);
        }
    }
}
