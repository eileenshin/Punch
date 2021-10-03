using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_DestroyBar : MonoBehaviour
{
    public GameObject Standard;
    //public float dist1;
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
            float dist1 = Mathf.Abs(Standard.transform.position.y - other.transform.position.y);
            print(KH_ScoreManager.instance.Combo);


            if (dist1 < .7f)
            {
                print("Perfect");
                KH_ScoreManager.instance.AddScore(100);

            }
            else if (dist1 < 1.2f)
            {
                print("Cool");
                KH_ScoreManager.instance.AddScore(70);

            }

            else
            {
                print("Miss");
                KH_ScoreManager.instance.HP -= 10;
                KH_ScoreManager.instance.Combo = 0;
                KH_ScoreManager.instance.MissCnt += 1;
            }
            Destroy(other.gameObject);
        }
    }
}
