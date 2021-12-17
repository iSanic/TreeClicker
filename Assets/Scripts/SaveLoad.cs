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
        })             //Деньги, перезарядка и открытые бревна
                       .Write<int>("score", cm.score)
                       .Write<float>("reload", mp.reload)
                       .Write<int>("openWood", ip.openWood)
                       //Количество бревен у игрока
                       .Write<int>("wood0", mp.woodIndex[0])
                       .Write<int>("wood1", mp.woodIndex[1])
                       .Write<int>("wood2", mp.woodIndex[2])

                       //Шансы дропа бревен
                       .Write<int>("scanseDrop0", cm.scanseDrop[0])
                       .Write<int>("scanseDrop1", cm.scanseDrop[1])
                       .Write<int>("scanseDrop2", cm.scanseDrop[2])
                       //Количество выпадаемых бревен
                       .Write<int>("Number0", cm.Number[0])
                       .Write<int>("Number1", cm.Number[1])
                       .Write<int>("Number2", cm.Number[2])
                       //Какие бревна могут выпадать
                       .Write<int>("enabledWood0", cm.enabledWood[0])
                       .Write<int>("enabledWood1", cm.enabledWood[1])
                       .Write<int>("enabledWood2", cm.enabledWood[2])

                       //Цена каждого перка
                       .Write<int>("countIndex0", ip.coutIndex[0])
                       .Write<int>("countIndex1", ip.coutIndex[1])
                       .Write<int>("countIndex2", ip.coutIndex[2])
                       .Write<int>("countIndex3", ip.coutIndex[3])
                       .Write<int>("countIndex4", ip.coutIndex[4])
                       .Write<int>("countIndex5", ip.coutIndex[5])
                       .Write<int>("countIndex6", ip.coutIndex[6])
                       .Write<int>("countIndex7", ip.coutIndex[7])

                       //Позиция игрока
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
        })                          //Деньги, перезарядка и открытые бревна
                                    .Read<int>("score", (r) => { cm.score = r; })
                                    .Read<float>("reload", (r) => { mp.reload = r; })
                                    .Read<int>("openWood", (r) => { ip.openWood = r; })
                                    //Количество бревен у игрока
                                    .Read<int>("wood0", (r) => { mp.woodIndex[0] = r; })
                                    .Read<int>("wood1", (r) => { mp.woodIndex[1] = r; })
                                    .Read<int>("wood2", (r) => { mp.woodIndex[2] = r; })

                                    //Шансы дропа бревен
                                    .Read<int>("scanseDrop0", (r) => { cm.scanseDrop[0] = r; })
                                    .Read<int>("scanseDrop1", (r) => { cm.scanseDrop[1] = r; })
                                    .Read<int>("scanseDrop2", (r) => { cm.scanseDrop[2] = r; })
                                    //Количество выпадаемых бревен
                                    .Read<int>("Number0", (r) => { cm.Number[0] = r; })
                                    .Read<int>("Number1", (r) => { cm.Number[1] = r; })
                                    .Read<int>("Number2", (r) => { cm.Number[2] = r; })
                                    //Какие бревна могут выпадать
                                    .Read<int>("enabledWood0", (r) => { cm.enabledWood[0] = r; })
                                    .Read<int>("enabledWood1", (r) => { cm.enabledWood[1] = r; })
                                    .Read<int>("enabledWood2", (r) => { cm.enabledWood[2] = r; })

                                    //Цена каждого перка
                                    .Read<int>("countIndex0", (r) => { ip.coutIndex[0] = r; })
                                    .Read<int>("countIndex1", (r) => { ip.coutIndex[1] = r; })
                                    .Read<int>("countIndex2", (r) => { ip.coutIndex[2] = r; })
                                    .Read<int>("countIndex3", (r) => { ip.coutIndex[3] = r; })
                                    .Read<int>("countIndex4", (r) => { ip.coutIndex[4] = r; })
                                    .Read<int>("countIndex5", (r) => { ip.coutIndex[5] = r; })
                                    .Read<int>("countIndex6", (r) => { ip.coutIndex[6] = r; })
                                    .Read<int>("countIndex7", (r) => { ip.coutIndex[7] = r; })

                                    //Позиция игрока
                                    .Read<Vector3>("playerPosition", (r) => { mp.posPlayer = r; })
                                    ;

    }
}
