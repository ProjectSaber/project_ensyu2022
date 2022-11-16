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
    public float speed = 20;

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
            transform.position -= transform.forward * Time.deltaTime * NoteSpeede;
        }
    }
    void _Throw()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var mouseRay = Camera.main.ScreenPointToRay(new Vector3(0, 0, 0));

            //地上を表す平面を作成
            var basePlane = new Plane(Vector3.up, -baseHeight);
            if (basePlane.Raycast(mouseRay, out var enter))
            {
                //レイと平面の交差があれば、その地点を目的地とする
                ToPoint = mouseRay.GetPoint(enter);

                //現在の位置を地上の高さに合わせ、その地点を出発地とする
                FromPoint = transform.position;
                FromPoint.y = baseHeight;

                //移動量を0.0にリセットしておく
                Travel = 0.0f;
                Throwing = true;

            }
        }

        if (Throwing)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeede;
            // if (transform.position.z <= 20){
            //     //出発地からの水平移動量を求め...
            //     Travel += speed * Time.deltaTime;

            //     //出発地と目的地の距離を求め...
            //     var distance = Vector3.Distance(FromPoint, ToPoint);

            //     //進行割合を求め...
            //     var t = Travel / distance;

            //     if (t < 1.0f)
            //     {
            //         //tが0.5（つまり中間地点）からどれだけ離れているかを求める
            //         //中間地点で0.0、出発地や目的地で1.0となるような値にする
            //         var d = Mathf.Abs(t - 0.5f) * 2.0f;

            //         //現在の水平位置を決め...
            //         var p = Vector3.Lerp(FromPoint, ToPoint, t);

            //         //高さを二次関数の曲線に沿って調整し...
            //         p.y += Mathf.Tan(Mathf.Deg2Rad * this.throwingAngle) * 0.25f * distance * (1.0f - (d * d));

            //         //位置を設定する
            //         transform.position = p;
            //     }
            //     else
            //     {
            //         //tが1.0に到達したら移動終了とする
            //         transform.position = ToPoint;
            //         Throwing = false;
            //     }
            // }
        }
    }
}

