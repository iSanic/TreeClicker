using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class SaveLoad : MonoBehaviour
{
    public Click_manager cm;
    public GameObject player;
    public Move_Player mp;

    private void Awake()
    {
        Load();
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) Save();
        else Save();
    }


    void Save()
    {
        QuickSaveWriter.Create("Player", new QuickSaveSettings() 
        { 
                        SecurityMode = SecurityMode.Base64,
                        Password = "vXQwS4V8HbdCe62g",
                        CompressionMode = CompressionMode.None
        })
                       .Write<int>("score", cm.score)
                       .Write<int>("wood0", mp.woodIndex[0])
                       .Write<int>("wood1", mp.woodIndex[1])
                       .Commit();

    }
    
    void Load()
    {
        var reader = QuickSaveReader.Create("Player", new QuickSaveSettings()
        {
                                     SecurityMode = SecurityMode.Base64,
                                     Password = "vXQwS4V8HbdCe62g",
                                     CompressionMode = CompressionMode.None
        })
                                    .Read<int>("score", (r) => {cm.score = r;})
                                    .Read<int>("wood0", (r) => { mp.woodIndex[0] = r; })
                                    .Read<int>("wood1", (r) => { mp.woodIndex[1] = r; });

    }
}
