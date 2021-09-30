using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;


    public GameObject echo;
   
    private GameManager gm;

    void Start()
    {
        gm = GetComponent<GameManager>();
    }


    void Update()
    {
      //�뷡�� �������̶��
     

        if(timeBtwSpawns <= 0 )
        {
            Instantiate(echo, transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;

        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
      
    }
}
