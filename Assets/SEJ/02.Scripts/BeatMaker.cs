using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class NodeInfo
{
    //��� ���� ����
    public int nodeNum;
    //��尡 ���� �ð�
    public float time;

}
[System.Serializable]
public class NodeJsonData
{
    //�����͸� ���� ����Ʈ
    public List<NodeInfo> data;

}

public class BeatMaker : MonoBehaviour
{
    //�̱��� �������� ���
    public static BeatMaker instance;
    //�������۸��
    public bool beatMakerMode;
    //����������������
    bool isRecording;
    //�����
    public AudioSource bgm;
    //����ð�
    float currTime;

    public List<NodeInfo> listNode = new List<NodeInfo>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        //�������۸���� �� 
        if(beatMakerMode == true)
        {
           if(Input.GetMouseButtonDown(0))
            {
                if(isRecording == false)
                {
                    isRecording = true;
                    bgm.Play();

                }
                else //�������̾��ٸ�
                {
                    isRecording = false;
                    bgm.Stop();
                    SaveNode();
                }
            }
           if(isRecording && bgm.isPlaying) //�������̶�� 
            {
                currTime += Time.deltaTime;

                //���� ����Ű
                if(Input.GetKeyDown(KeyCode.Alpha1))
                {
                    AddNode(1, currTime);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2)) 
                {
                    AddNode(2, currTime);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    AddNode(3, currTime);
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    AddNode(4, currTime);
                }
            } 
        }
    
    }
    private void AddNode(int nodeNum, float time)
    {
        NodeInfo info = new NodeInfo();
        info.nodeNum = nodeNum;
        info.time = bgm.time;
        listNode.Add(info);
        print(time + ", " + bgm.time);
    }

    private void SaveNode()
    {
        NodeJsonData data = new NodeJsonData();
        data.data = listNode;
        string str = JsonUtility.ToJson(data, true);

        FileStream file = new FileStream(Application.dataPath + "/text.txt", FileMode.Create);
        byte[] byteData = Encoding.UTF8.GetBytes(str);
        file.Write(byteData, 0, byteData.Length);
        file.Close();
    }
}
                
                
                
                

