using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_Node : MonoBehaviour
{
    float speed = 1;
    public int nodeNum;
    GameObject Standard;
    // Start is called before the first frame update
    void Start()
    {
        speed = KH_GameManager.instance.nodeSpeed;
        Standard = GameObject.Find("EndPos");
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.back * speed * Time.fixedDeltaTime;
        //transform.position += -transform.forward * speed * Time.fixedDeltaTime;
        //transform.back? 이렇게하면 되려나?

    }
    bool isTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!isTrigger) return;
        if (other.gameObject.tag == "Hand")
        {

            isTrigger = false;
            float dist1 = Mathf.Abs(Standard.transform.position.y - other.transform.position.y);
            print(KH_ScoreManager.instance.Combo);
            Destroy(gameObject);

            if (dist1 < .7f)
            {
                print("Perfect");
                print("debug" + transform.name);
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
                //KH_ScoreManager.instance.CurrScore = 0;
                KH_ScoreManager.instance.currHP -= 10;
                KH_ScoreManager.instance.Combo = 0;
                KH_ScoreManager.instance.MissCnt += 1;
            }
            
        }

    }
}
