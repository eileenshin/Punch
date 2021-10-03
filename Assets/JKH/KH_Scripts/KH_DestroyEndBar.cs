using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_DestroyEndBar : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node")
        {
            print("Miss");
            KH_ScoreManager.instance.HP -= 10;
            KH_ScoreManager.instance.Combo = 0;
            KH_ScoreManager.instance.MissCnt += 1;
            Destroy(other.gameObject);
        }
    }
}
