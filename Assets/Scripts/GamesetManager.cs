using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesetManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    public ScoreManager Sm;

    // Start is called before the first frame update
    void Start()
    {
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Sm.Lflag == 1){
            if (Sm.Score >= 100) {
                //ゲームクリア画面を表示
                //Invoke関数は1秒後にGameClear関数を実行する
                Invoke(nameof(GameClear), 1);
            } else {
                //ゲームオーバー画面を表示
                Invoke(nameof(GameOver), 1);
            }
        } 
    }

    public void GameClear() {
        //ゲームクリア
        Debug.Log("ゲームクリア");
        gameClearUI.SetActive(true);
    }

    public void GameOver() {
        //ゲームオーバー
        Debug.Log("ゲームオーバー");
        gameOverUI.SetActive(true);
    }

    public void GameReplay() {
        SceneManager.LoadScene("StartMenu");
    }
}
