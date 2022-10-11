using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource audio;
    AudioClip Music;
    string songName;
    bool played;

    // Start is called before the first frame update
    void Start()
    {
        songName = "test";
        audio = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!played)
        {
            played = true;
            //GetComponent<AudioSource>().Play();
            audio.Play();
        }
    }
}
