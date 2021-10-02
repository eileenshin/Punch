using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512 : MonoBehaviour
{
    public GameObject smapleCubePrefab;
    GameObject[] sampleCube = new GameObject[30];

    void Start()
    {
        for(int i =0; i< 30; i++) 
        {
            GameObject instanceSampleCube = Instantiate(smapleCubePrefab);
            instanceSampleCube.transform.parent = transform;
            instanceSampleCube.name = "SampleCube" + i;
            instanceSampleCube.transform.localPosition = new Vector3(0, 0, 0.05f * i);
            // ��ü ������������ ���� (x��,y��,z��) z�� �������� ���ݿ� �����ϴ� ���� 
           
            sampleCube[i] = instanceSampleCube;
        }
    }



    public float maxScale;
    void Update()
    {
        for (int i = 0; i < 30; i++)
        {
            if(sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector3(0.03f, (AudioPeer.samples[i] * maxScale), 0.01f);
                //������������ ( ����, ����, �ʺ�)
            }
        }
    }
}
