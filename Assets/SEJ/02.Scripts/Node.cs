using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float speed = 1;
    public int nodeNum;
    public float currTime;



    void Start()
    {
        speed = GameManager.instance.nodeSpeed;
    }
   


    private void FixedUpdate()
    {
      //  if(currTime < 9.36723f)
        {
            //currTime += Time.fixedDeltaTime;

            transform.position += Vector3.back * speed * Time.fixedDeltaTime;
           
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        //오른손에 닿으면
        if(other.gameObject.CompareTag("Right"))
        {

        }
    }

}