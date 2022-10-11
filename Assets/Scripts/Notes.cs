using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int NoteSpeede = 20;
    bool start;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        if(start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeede;
        }
    }
}
