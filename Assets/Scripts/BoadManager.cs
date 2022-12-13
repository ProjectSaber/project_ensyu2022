using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoadManager : MonoBehaviour
{

    public ScoreManager Sm;

    // Start is called before the first frame update
    void Start()
    {
         Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    //回転中かどうか
    bool coroutineBool = false;

    int Bflag = 0;

    bool switchflag = true;
 
    void Update()
    {
        if((Input.GetKeyDown("right") || Sm.Sf == 1) && switchflag)
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("RightMove");
            }
            switchflag = false;
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

        // if(Input.GetKeyDown("up"))
        // {
        //     //回転中ではない場合は実行 
        //     if (!coroutineBool)
        //     {
        //         coroutineBool = true;
        //         StartCoroutine("UpMove");
        //     }
        // }
         
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

    // //下に回転して180°でストップ
    // IEnumerator DownMove()
    // {
    //     for (int turn=0; turn<180; turn++)
    //     {
    //         transform.Rotate(1,0,0);
    //         yield return new WaitForSeconds(0.001f);
    //     }
    //     coroutineBool = false;
    // }

    //下に回転して180°でストップ
    IEnumerator DownMove()
    {
        if(Bflag == 0){
            for (int turn=0; turn<180; turn++)
            {
                transform.Rotate(1,0,0);
                yield return new WaitForSeconds(0.001f);
            }
            Bflag = 1;
        }
        else if(Bflag == 1){
            for(int turn=0; turn < 180; turn++){
                transform.Rotate(-1,0,0);
                yield return new WaitForSeconds(0.0001f);
            }
            Bflag = 0;
        }
        coroutineBool = false;
    }
}
