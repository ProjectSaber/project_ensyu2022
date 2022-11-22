using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreScript.score >= 100) {
            //ゲームクリア画面を表示
            //Invoke関数は35秒後にGameClear関数を実行する
            Invoke(nameof(GameClear), 2);
        } else {
            //ゲームオーバー画面を表示
            Invoke(nameof(GameOver), 2);
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
