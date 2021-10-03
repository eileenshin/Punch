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
            // ��ü ������������ ���� (x��,y��,z��) z�� �������� ���ݿ� �����ϴ� ���� 
            instanceSampleCube.transform.localPosition = new Vector3(0, 0, 0.05f * i);
            instanceSampleCube.transform.rotation = Quaternion.Euler(90, 90, 90); //�ٴڿ� ������
           


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
