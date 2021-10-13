using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_NewMusic : MonoBehaviour
{
    public bool isNewMusic1 = false;
    public static KH_NewMusic instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isNewMusic1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
