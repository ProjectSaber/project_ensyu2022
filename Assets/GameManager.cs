using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreTest.score >= 100) {
            //ゲームクリア
            Debug.Log("ゲームクリア");
        } else {
            Invoke(nameof(GameOver), 35);
        }
        
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
