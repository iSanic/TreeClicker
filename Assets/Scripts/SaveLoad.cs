using UnityEngine;
using CI.QuickSave;

public class SaveLoad : MonoBehaviour
{
    public Click_manager cm;
    public GameObject player;
    public Move_Player mp;
    public InfoPercs ip;

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
                       .Write<float>("reload", mp.reload)
                       .Write<int>("wood0", mp.woodIndex[0])
                       .Write<int>("wood1", mp.woodIndex[1])
                       .Write<int>("countIndex0", ip.coutIndex[0])
                       .Write<Vector3>("playerPosition", mp.posPlayer)
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
                                    .Read<int>("score", (r) => { cm.score = r; })
                                    .Read<float>("reload", (r) => { mp.reload = r; })
                                    .Read<int>("wood0", (r) => { mp.woodIndex[0] = r; })
                                    .Read<int>("wood1", (r) => { mp.woodIndex[1] = r; })
                                    .Read<int>("countIndex0", (r) => { ip.coutIndex[0] = r; })
                                    .Read<Vector3>("playerPosition", (r) => { mp.posPlayer = r; })
                                    ;

    }
}
