using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KH_SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar; //scrollBar_horizontal
    private float scroll_pos = 0;
    float[] pos;

    public int ii;

    public bool isShark = false;
    public bool isNextLevel = false;

    public static KH_SwipeMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //자식의 수
        pos = new float[transform.childCount]; 
        //거리= 1/ (자식수-1)
        float distance = 1f / (pos.Length - 1f); 
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0)) //대신 오큘려스 버튼으로 대체?
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], .1f);
                }
            }
        }

        
        for (ii = 0; ii < pos.Length; ii++)
        {

            //기준점에서 일정범위 안에 들어오면 그 버튼을 크게한다
            if (scroll_pos < pos[ii] + (distance / 2) && scroll_pos > pos[ii] - (distance / 2))
            {
                //i번째 버튼을 크게한다
                Debug.LogWarning("Current Selected Level" + ii);
                transform.GetChild(ii).localScale = Vector2.Lerp(transform.GetChild(ii).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                //i제외, 나머지 버튼 작게한다
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != ii)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }

                if (ii == 0)
                {
                    print("Shark");
                    //KH_SceneManager.instance.onClickStartBtn();
                    isShark = true;
                    isNextLevel = false;
                }

                if (ii == 1)
                {
                    print("NextLevel");
                    //KH_SceneManager.instance.onClickNextLevel();
                    isShark = false;
                    isNextLevel = true;
                }

                if (ii == 2)
                {
                    print("i=2");
                    isShark = false;
                    isNextLevel = false;
                }

                if (ii == 3)
                {
                    print("i=3");
                    isShark = false;
                    isNextLevel = false;
                }
            }
            
        }

        

    }
}
