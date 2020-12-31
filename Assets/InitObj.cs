using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Script.Enum;
using Script.NetWork.Entity;
using Script.Prefab;
using UnityEngine;

public class InitObj : MonoBehaviour
{
    private SourceDataEntity SourceDataEntity = new SourceDataEntity();
    private GameObjEntity GameObjEntity = new GameObjEntity();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.I))
        {
            print("初始化物体");
            GameObject go = Instantiate(
                Resources.Load<GameObject>(Prefab.Maps["moodBox"]),
                new Vector3(10,10,100), 
                Quaternion.identity);
            go.name = "Hello";
            go.layer = 10;
            go.tag = "Enemy";
        }*/
        if (Input.GetKeyUp(KeyCode.I))
        {
            while (!NetWork.HasNewSendDatas)
            {
                print("初始化物体");
                // 组织数据
                SourceDataEntity.SourceDataType = SourceDataType.GameObj;
                GameObjEntity.CreateOrDestroy = true;    //Create
                GameObjEntity.PrefabName = "moodBox";
                GameObjEntity.ObjName = "GoodBox";
                GameObjEntity.PositionX = 5;
                GameObjEntity.PositionY = 5;
                GameObjEntity.PositionZ = 5;
                GameObjEntity.LocalScaleX = 1;
                GameObjEntity.LocalScaleY = 1;
                GameObjEntity.LocalScaleZ = 1;
                string s1 = JsonConvert.SerializeObject(GameObjEntity);
                SourceDataEntity.Content = s1;
                string s2 = JsonConvert.SerializeObject(SourceDataEntity);
            
                // 通知发送
                NetWork.SendDatasTemp = s2;
                NetWork.HasNewSendDatas = true;
            }        
        }
        
    }
}
