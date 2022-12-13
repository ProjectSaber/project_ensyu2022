using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public GameObject particleObject;

    public ScoreManager Sm;
    private int Status; 

    int Combocal = 0;


    // Start is called before the first frame update
    void Start()
    {
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        Status = 0; 
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     // 当たった相手の色をランダムに変える
	// 	other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    // }

    /// <summary>
	/// パーティクルが他のGameObject(Collider)に当たると呼び出される
	/// </summary>
	/// <param name="other"></param>
	private void OnParticleCollision(GameObject other)
	{
		// 当たった相手の色をランダムに変える
		//other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        //other.GetComponent<Collider>().isTrigger = false;
        if(other.gameObject.CompareTag("BreakOutCube")) {
            if(Status == 0){
                Instantiate(particleObject, other.transform.position, Quaternion.identity); //パーティクルエフェクト用オブジェクト
                Sm.Combo++;
                Combocal = Sm.Combo / 10;
                Sm.Score = Sm.Score + (Combocal * 10) + 100;
                Destroy(other.gameObject);
            }
        }else if(other.gameObject.CompareTag("Lastnotes")){
            Sm.Lflag = 1;
            if(Status == 0){
                Instantiate(particleObject, other.transform.position, Quaternion.identity); //パーティクルエフェクト用オブジェクト
                Sm.Combo++;
                Combocal = Sm.Combo / 10;
                Sm.Score = Sm.Score + (Combocal * 10) + 100;
                Destroy(other.gameObject);
            }
        }else if(other.gameObject.CompareTag("RightTurn")){
            Sm.Sf = 1;
            if(Status == 0){
                Instantiate(particleObject, other.transform.position, Quaternion.identity); //パーティクルエフェクト用オブジェクト
                Sm.Combo++;
                Combocal = Sm.Combo / 10;
                Sm.Score = Sm.Score + (Combocal * 10) + 100;
                Destroy(other.gameObject);
            }
        }
	}
}