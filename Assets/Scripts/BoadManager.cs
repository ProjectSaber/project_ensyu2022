using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoadManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //回転中かどうか
    bool coroutineBool = false;
 
    void Update()
    {
        if(Input.GetKeyDown("right"))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("RightMove");
            }
        }
 
        if(Input.GetKeyDown("left"))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("LeftMove");
            }
        }

        if(Input.GetKeyDown("down"))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("DownMove");
            }
        }

        if(Input.GetKeyDown("up"))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("UpMove");
            }
        }
         
    }
 
    //右にゆっくり回転して90°でストップ
    IEnumerator RightMove()
    {
        for (int turn=0; turn<90; turn++)
        {
            transform.Rotate(0,1,0);
            yield return new WaitForSeconds(0.001f);
        }
        coroutineBool = false;
    }
 
    //左にゆっくり回転して90°でストップ
    IEnumerator LeftMove()
    {
        for (int turn=0; turn<90; turn++)
        {
            transform.Rotate(0,-1,0);
            yield return new WaitForSeconds(0.001f);
        }
        coroutineBool = false;
    }

    //下に回転して180°でストップ
    IEnumerator DownMove()
    {
        for (int turn=0; turn<180; turn++)
        {
            transform.Rotate(1,0,0);
            yield return new WaitForSeconds(0.001f);
        }
        coroutineBool = false;
    }

    //上に回転して180°でストップ
    IEnumerator UpMove()
    {
        for (int turn=0; turn<180; turn++)
        {
            transform.Rotate(-1,0,0);
            yield return new WaitForSeconds(0.001f);
        }
        coroutineBool = false;
    }
}
