using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_DestroyBar : MonoBehaviour
{
    public GameObject Standard;
    public OVRInput.Controller hand;
    //public float dist1;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator Vibration()
    {
        OVRInput.SetControllerVibration(1f, 1f, hand);

        yield return null;
        OVRInput.SetControllerVibration(0, 0, hand);
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
                //KH_ScoreManager.instance.CurrScore = 0;
                KH_ScoreManager.instance.currHP -= 10;
                KH_ScoreManager.instance.Combo = 0;
                KH_ScoreManager.instance.MissCnt += 1;
            }
            Destroy(other.gameObject);

            StartCoroutine(Vibration());
        }
    }
}
