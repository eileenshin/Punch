using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public OVRInput.Controller hand;
    LineRenderer line;
    public Transform trRIght;
    public Transform trLeft;

    IEnumerator Vibration()
    {
        OVRInput.SetControllerVibration(1f, 1f, hand);

        yield return null;
        OVRInput.SetControllerVibration(0, 0, hand);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            StartCoroutine(Vibration());
        }
    }
}
