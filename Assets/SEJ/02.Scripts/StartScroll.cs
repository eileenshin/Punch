using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScroll : MonoBehaviour
{
    public GameObject scrollbar;

    float scroll_pos = 0;
    float[] pos;
    public static StartScroll instance;

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
    void Start()
    {

    }

    public bool isShark = false;
    public bool isNextLevel = false;



    void Update()
    {
        pos = new float[transform.childCount];
        float dis = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = dis * i;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        //if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }

        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (dis / 2) && scroll_pos > pos[i] - (dis / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);

                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (dis / 2) && scroll_pos > pos[i] - (dis / 2))
            {
                transform.GetChild(i).localScale = Vector3.Lerp(transform.GetChild(i).localScale, new Vector2(2, 2), 0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
                if (i == 1)
                {
                    print("Shark");
                    //KH_SceneManager.instance.onClickStartBtn();
                    isShark = true;
                    isNextLevel = false;
                }

                if (i == 0)
                {
                    print("NextLevel");
                    //KH_SceneManager.instance.onClickNextLevel();
                    isShark = false;
                    isNextLevel = true;
                }

                if (i == 2)
                {
                    print("i=2");
                    isShark = false;
                    isNextLevel = false;
                }

                if (i == 3)
                {
                    print("i=3");
                    isShark = false;
                    isNextLevel = false;
                }
            }
        }

    }

}
