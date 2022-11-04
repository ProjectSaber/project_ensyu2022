using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;

}
[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class NotesManager : MonoBehaviour
{
    public int noteNum;
    private string songName;
    private int angle = 0;

    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();

    [SerializeField] private float NotesSpeed;
    [SerializeField] GameObject noteObj;
    [SerializeField] GameObject noteObj_aaa;

    void OnEnable()
    {
        noteNum = 0;
        songName = "WYC";
        Load(songName);
    }

    private void Load(string SongName)
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        noteNum = inputJson.notes.Length;

        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            float interval = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = interval * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);

            float x = inputJson.notes[i].block - 1.5f;
            float y = 0.0f + Random.Range(2, 7);
            float z = NotesTime[i] * NotesSpeed;

            
            float rotate_x =  0;
            float rotate_y =  0;
            float rotate_z =  0;
            
            rotate_x =  inputJson.notes[i].block + Random.Range(-10, 10);
            rotate_y =  0.0f + Random.Range(1, 3);
            rotate_z =  0.0f + Random.Range(0, 1);
            

            //jsonから情報を読み込んでノーツを生成する処理
            // NotesObj.Add(Instantiate(noteObj, new Vector3(x, y, z), Quaternion.Euler(rotate_x, rotate_y, rotate_z)));
            NotesObj.Add(Instantiate(noteObj_aaa, new Vector3(x, y, z), Quaternion.identity));
        }
    }
}