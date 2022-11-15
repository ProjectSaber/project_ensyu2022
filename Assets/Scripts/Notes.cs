using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    int NoteSpeede = 16;
    bool start;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        if(start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeede;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            transform.RotateAround(
                _center,
                _axis,
                90
            );
        }
        
        if(transform.position.z < -12 && transform.position.z > -22 && transform.position.x < 5 && transform.position.x > -5){
            Sm.Score -= 10;
            Destroy(this.gameObject);
        }
    }
}
