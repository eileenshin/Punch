using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject standard;

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
            //Endpos(기준) - 손 위치
            float dist = Mathf.Abs(standard.transform.position.y - other.gameObject.transform.position.y);

            if (dist > -0.5f && dist < 1f)
            {
                print("Perfect");
                ScoreManager.instance.score += 100;
                ScoreManager.instance.combo += 1;
                ScoreManager.instance.Hp += 1;
   
            }

            else
            {
                print("Miss");

                ScoreManager.instance.combo = 0;
                ScoreManager.instance.Hp -= 10;

            }

            print("Node1 충돌");
            Destroy(other.gameObject);

           // OVRInput.SetControllerVibration(0.01f, 0.01f, OVRInput.Controller.LTouch);
        }

    }
}
