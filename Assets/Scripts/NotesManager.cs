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
    [SerializeField] GameObject noteObj_right;

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

            float r = inputJson.notes[i].block - 0.0f + Random.Range(-4,4);
            float z = NotesTime[i] * NotesSpeed - 8.7f;
            //float xr = Mathf.Cos(90)*r - Mathf.Sin(90)*z;
            //float xz = Mathf.Sin(90)*r + Mathf.Cos(90)*z;
            if(r > 0){
                NotesObj.Add(Instantiate(noteObj_right, new Vector3(r, 0.0f + Random.Range(2, 7), z), Quaternion.Euler(0, 0, 0)));
            }else{
                NotesObj.Add(Instantiate(noteObj, new Vector3(r, 0.0f + Random.Range(2, 7), z), Quaternion.Euler(0, 0, 0)));
            }

        }
    }
}