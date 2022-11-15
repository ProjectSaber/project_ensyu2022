using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ノーツ一つ一つの動きを制御
public class Notes : MonoBehaviour
{

        // 中心点
    [SerializeField] private Vector3 _center = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.up;

    // 円運動周期
    [SerializeField] private float _period = 2;
    
    public ScoreManager Sm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //投げる水平スピード
    public float speed = 10;

    //射出角度
    [Range(0.0f, 60.0f)] public float throwingAngle = 60.0f;

    //地上にいるときのY座標
    public float baseHeight = 1.0f;

    //投げるフラグ
    bool Throwing;

    Vector3 FromPoint;
    Vector3 ToPoint;
    float Travel;
    int NoteSpeede = 16;
    bool start;

    // Update is called once per frame
    void Update()
    {
        int i = Random.Range(0, 10);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }

        if(start && i>=6)
        {
            _Throw();
        } 
        if(start && i<6) {
            //奥に行くほど「＋」、今回はプレイヤー側に送りたいので「ー」
            //Time.deltaTime:パソコンごとのフレームの違いを修正
            // transform.eulerAngles = new Vector3(90, 0, 0);
            transform.position -= transform.forward * Time.deltaTime * NoteSpeede;
        }
    }
}
