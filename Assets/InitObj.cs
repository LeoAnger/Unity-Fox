using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Script;
using Script.Enum;
using Script.NetWork;
using Script.NetWork.Entity;
using Script.Player;
using Script.Prefab;
using UnityEngine;

public class InitObj : MonoBehaviour
{
    private SourceDataEntity SourceDataEntity = new SourceDataEntity();
    private GameObjEntity GameObjEntity = new GameObjEntity();

    public Animator Animator;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         // 实例化物体
         if (Input.GetKeyUp(KeyCode.I))
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
        if (Input.GetKeyUp(KeyCode.U))
        {
            
        }
        // 测试更改动画
        /*if (Input.GetKeyDown(KeyCode.Y))
        {
            print("移除脚本");
            Destroy(Player.GetComponent<Player1>());
            
        }

        // 添加脚本
        if (Input.GetKeyUp(KeyCode.C))
        {
            /*UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(
                Player, "添加力", "PlayerTest");#1#
            UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(
                Player, "添加力", "Player1");
        }*/
        if (Input.GetKeyUp(KeyCode.I))
        {
            while (!NetWork.HasNewSendDatas)
            {
                print("初始化物体");
                // 组织数据
                SourceDataEntity.SourceDataType = SourceDataType.GameObj;
                GameObjEntity.CreateOrDestroy = true;    //Create
                GameObjEntity.PrefabName = "Player";
                GameObjEntity.ObjName = "Player1";
                GameObjEntity.ScriptName = "Player1";
                GameObjEntity.PositionX = 40;
                GameObjEntity.PositionY = 10;
                GameObjEntity.PositionZ = 0;
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
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            while (!NetWork.HasNewSendDatas)
            {
                print("销毁物体");
                // 组织数据
                SourceDataEntity.SourceDataType = SourceDataType.GameObj;
                GameObjEntity.CreateOrDestroy = false;    //Destroy 
                GameObjEntity.ObjName = "GoodBox";
               
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
