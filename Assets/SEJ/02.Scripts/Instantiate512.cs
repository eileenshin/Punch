using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512 : MonoBehaviour
{
    public GameObject smapleCubePrefab;
    GameObject[] sampleCube = new GameObject[50];

    void Start()
    {
        for(int i =0; i< 50; i++) 
        {
            GameObject instanceSampleCube = Instantiate(smapleCubePrefab);
            instanceSampleCube.transform.parent = transform;
            instanceSampleCube.name = "SampleCube" + i;
            instanceSampleCube.transform.localPosition = new Vector3(0, 0, 0.15f * i);
           
            sampleCube[i] = instanceSampleCube;
        }
    }



    public float maxScale;
    void Update()
    {
        for (int i = 0; i < 50; i++)
        {
            if(sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector3(0.05f, (AudioPeer.samples[i] * maxScale)+ 0.01f, 0.05f);
            }
        }
    }
}
