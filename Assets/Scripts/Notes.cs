using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ノーツ一つ一つの動きを制御
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
            //奥に行くほど「＋」、今回はプレイヤー側に送りたいので「ー」
            //Time.deltaTime:パソコンごとのフレームの違いを修正
            transform.position -= transform.forward * Time.deltaTime * NoteSpeede;
        }
    }
}
