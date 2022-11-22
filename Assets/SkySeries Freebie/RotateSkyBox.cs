// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class RotateSkyBox : MonoBehaviour
// // {
// //     // Start is called before the first frame update
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// // }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
 
// public class RotateSkyBox : MonoBehaviour {
 
//     //　回転スピード
//     [SerializeField]
//     private float rotateSpeed = 0.000005f;
//     //　スカイボックスのマテリアル
//     private Material skyboxMaterial;
 
// // Use this for initialization
//     void Start () {
//         //　Lighting Settingsで指定したスカイボックスのマテリアルを取得
//         skyboxMaterial = RenderSettings.skybox;
//     }
// // Update is called once per frame
//     void Update () {
//         //　スカイボックスマテリアルのRotationを操作して角度を変化させる
//         skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") + rotateSpeed * Time.deltaTime*100, 360f));
//     }
// }
 


using UnityEngine;
using System.Collections;

public class RotateSkyBox : MonoBehaviour {
    public float _anglePerFrame = 0.1f;    // 1フレームに何度回すか[unit : deg]
    float _rot = 0.0f;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        _rot += _anglePerFrame;
        if (_rot >= 360.0f) {    // 0～360°の範囲におさめたい
            _rot -= 360.0f;
        }
        RenderSettings.skybox.SetFloat("_Rotation", _rot);    // 回す
        
        

    }
}
