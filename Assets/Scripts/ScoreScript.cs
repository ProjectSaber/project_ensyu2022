using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI機能を扱うときに追記する

public class ScoreScript : MonoBehaviour
{
    public static int score = 100;
    public Text ScoreText;

    public ScoreManager Sm;

    // Start is called before the first frame update
    void Start()
    {
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
      ScoreText.text = "Score:" + Sm.Score.ToString(); //ScoreTextの文字をScore:Scoreの値にする  
    }
}
