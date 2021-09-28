using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


//[System.Serializable]
//public class NodeInfo
//{
//    public int nodeNum;
//    public float time;
//}

//[System.Serializable]
//public class NodeJsonData
//{
//    public List<NodeInfo> data;
//}

public class KH_BeatMaker : MonoBehaviour
{
    public static KH_BeatMaker instance;

    public bool beatMakerMode;
    //�����
    public AudioSource bgm;
    //����������������
    bool isRecording;
    //�帣�½ð�
    float currTime;

    public List<NodeInfo> listNode = new List<NodeInfo>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }
    private void Update()
    {
        //beatmakerMode ����Ƽ���� On/Off�Ѵ�.
        if (beatMakerMode == true)
        {
            //���� ��Ŭ���Ѵٸ� ���������Ѵ�
            if (Input.GetMouseButtonDown(0))
            {
                if (isRecording == false)
                {
                    isRecording = true;
                    bgm.Play();
                    print("��������");
                }

                else
                {
                    isRecording = false;
                    bgm.Stop();
                    SaveNode();
                    print("������");
                }
            }

            if (isRecording)
            {
                currTime += Time.deltaTime;

                //1�� Ű ������ 1��Ű�� ����ð� ����
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    AddNode(1, currTime);
                }

                //2�� Ű ������ 2��Ű�� ����ð� ����
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    AddNode(2, currTime);
                }
            }
        }
    }


    void AddNode(int nodeNum, float time)
    {
        //info�� ��� ������
        NodeInfo info = new NodeInfo();
        info.nodeNum = nodeNum;
        info.time = time;
        listNode.Add(info);
    }

    void SaveNode()
    {
        NodeJsonData data = new NodeJsonData();
        data.data = listNode;
        string str = JsonUtility.ToJson(data, true);

        print(str);

        //FileStream file = new FileStream(Application.dataPath + "/"+bgm �̸�+"".txt", FileMode.Create);
        FileStream file = new FileStream(Application.dataPath + "/text.txt", FileMode.Create);
        byte[] byteData = Encoding.UTF8.GetBytes(str);
        file.Write(byteData, 0, byteData.Length);
        file.Close();
    }
}