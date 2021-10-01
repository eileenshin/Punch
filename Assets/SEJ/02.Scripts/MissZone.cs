using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Node")
        {
            
            ScoreManager.instance.combo = 0;
            ScoreManager.instance.Hp -= 10;
            print("Miss" + ScoreManager.instance.Hp);
            Destroy(other.gameObject);
        }    





    }

}
