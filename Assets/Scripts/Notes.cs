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
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
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
    bool coroutineBool = false; //回転中に回転コマンドが発動しないようにする
    bool switchflag = true;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        if(((Input.GetKeyDown("right") || Sm.Sf == 1) && !coroutineBool) && switchflag){
            coroutineBool = true;
            transform.RotateAround(
                _center,
                _axis,
                90
            );
            coroutineBool = false;
            switchflag = false;
        }
        if(Input.GetKeyDown("left") && !coroutineBool){
            coroutineBool = true;
            transform.RotateAround(
                _center,
                _axis,
                -90
            );
            coroutineBool = false;
        }
        if(Input.GetKeyDown("down") && !coroutineBool){
            coroutineBool = true;
            transform.RotateAround(
                _center,
                _axis,
                180
            );
            coroutineBool = false;
        }

        if(transform.position.z >-17 && transform.position.z < -14){
            Sm.Score -= 10;
            Sm.Combo = 0;
            if(this.gameObject.CompareTag("Lastnotes")) Sm.Lflag = 1;
            if(this.gameObject.CompareTag("RightTurn")) Sm.Sf = 1;
             Destroy(this.gameObject);
        }

        if(start){
            _Throw();
        }

    }


    void _Throw()
    {
        int hantei = Random.Range(0, 10);

        if(hantei >= 1) {
            //奥に行くほど「＋」、今回はプレイヤー側に送りたいので「ー」
            //Time.deltaTime:パソコンごとのフレームの違いを修正
            transform.position -= transform.forward * Time.deltaTime * NoteSpeede;
        }else if(hantei == 0){
            if (transform.position.z >= 10.00 && transform.position.z <= 10.10)
            {
                //マウスポインタの位置を指すレイを作成
                Vector3 mousePosition = Input.mousePosition;

                mousePosition.x = 0.0f + Random.Range(2, 7);
                mousePosition.y= 0.0f + Random.Range(2, 7);
                mousePosition.z = 1.0f;

                var mouseRay = Camera.main.ScreenPointToRay(mousePosition);
                // print(Input.mousePosition);
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
        
        }

        if (Throwing)
        {
            //出発地からの水平移動量を求める
            Travel += speed * Time.deltaTime;

            //出発地と目的地の距離を求め...
            var distance = Vector3.Distance(FromPoint, ToPoint);

            //進行割合を求め...
            var t = Travel / distance;

            if (t < 1.0f)
            {
                //tが0.5（つまり中間地点）からどれだけ離れているかを求める
                //中間地点で0.0、出発地や目的地で1.0となるような値にする
                var d = Mathf.Abs(t - 0.5f) * 2.0f;

                //現在の水平位置を決め...
                var p = Vector3.Lerp(FromPoint, ToPoint, t);

                //高さを二次関数の曲線に沿って調整し...
                p.y += Mathf.Tan(Mathf.Deg2Rad * this.throwingAngle) * 0.25f * distance * (1.0f - (d * d));

                //位置を設定する
                transform.position = p;
            }
            else
            {
                //tが1.0に到達したら移動終了とする
                transform.position = ToPoint;
                Throwing = false;
            }
        }
    }
}

