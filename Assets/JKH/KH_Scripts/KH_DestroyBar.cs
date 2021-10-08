using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_DestroyBar : MonoBehaviour
{
   
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
            

            StartCoroutine(Vibration());
        }
    }
}
