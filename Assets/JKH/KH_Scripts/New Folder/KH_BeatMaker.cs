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
    //배경음
    public AudioSource bgm;
    //녹음시작중지상태
    bool isRecording;
    //흐르는시간
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
        //beatmakerMode 유니티에서 On/Off한다.
        if (beatMakerMode == true)
        {
            //만약 좌클릭한다면 녹음시작한다
            if (Input.GetMouseButtonDown(0))
            {
                if (isRecording == false)
                {
                    isRecording = true;
                    bgm.Play();
                    print("녹음시작");
                }

                else
                {
                    isRecording = false;
                    bgm.Stop();
                    SaveNode();
                    print("녹음끝");
                }
            }

            if (isRecording)
            {
                currTime += Time.deltaTime;

                //1번 키 누르면 1번키와 현재시간 저장
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    AddNode(1, currTime);
                }

                //2번 키 누르면 2번키와 현재시간 저장
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    AddNode(2, currTime);
                }
            }
        }
    }


    void AddNode(int nodeNum, float time)
    {
        //info를 계속 담을거
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

        //FileStream file = new FileStream(Application.dataPath + "/"+bgm 이름+"".txt", FileMode.Create);
        FileStream file = new FileStream(Application.dataPath + "/text.txt", FileMode.Create);
        byte[] byteData = Encoding.UTF8.GetBytes(str);
        file.Write(byteData, 0, byteData.Length);
        file.Close();
    }
}
