using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int Score;  //Score変数を定義
    public int Combo; //Conbo変数を定義
    public int Lflag;
    public int Sf; // switch flag

    //スクリプトをアタッチした時にスコア加算したいTextと紐づける
    //public Text ScoreText; 
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI ComboText;


    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Combo = 0;
        Lflag = 1;
        Sf = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("{0}", Score); //Textのフォーマット
        ComboText.text = string.Format("{0}", Combo); //Textのフォーマット
        
    }
}
