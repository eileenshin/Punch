using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject noteFactory;
    public Transform notePos1;
  



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject note = Instantiate(noteFactory);
        note.transform.position = notePos1.transform.position;

    }
}
