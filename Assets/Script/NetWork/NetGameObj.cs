﻿using Newtonsoft.Json;
using Script.NetWork.Entity;
using UnityEngine;

/*
 * 1.初始化物体
 * 2.销毁物体
 */
namespace Script.NetWork
{
    public class NetGameObj : MonoBehaviour
    {
    
        private static string _sourceDatas = "";
        public static string sourceDatasTemp = "";    //缓冲数据
        public static bool isReadedData = true;
    
        private GameObjEntity _deserializeObject = new GameObjEntity();
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            while (!isReadedData)
            {
                //读取数据
                _sourceDatas = sourceDatasTemp;
                isReadedData = true;
                _deserializeObject = JsonConvert.DeserializeObject<GameObjEntity>(_sourceDatas);
            
                //逻辑处理
                // Create
                if (_deserializeObject.CreateOrDestroy)
                {
                    //物体已经存在
                    if (GameObject.Find(_deserializeObject.ObjName) != null)
                    {
                        //移除脚本
                        return;
                    }
                    // 位置
                    GameObject go = Instantiate(
                        Resources.Load<GameObject>(
                            Prefab.Prefab.Maps[_deserializeObject.PrefabName]),
                        new Vector3(_deserializeObject.PositionX,
                            _deserializeObject.PositionY,
                            _deserializeObject.PositionZ), 
                        Quaternion.identity);
                    // 名字
                    go.name = _deserializeObject.ObjName;
                    // 加载脚本
                    if (_deserializeObject.ScriptName != null)
                    {
                        UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(
                            go, "脚本", _deserializeObject.ScriptName);
                    }
                    
                    print("创建物体成功..." + go.name);
                }
                else
                {
                    // Destroy
                    var find = GameObject.Find(_deserializeObject.ObjName);
                    if (find)
                    {
                        Destroy(find);
                        print("销毁物体完成");
                    }
                }
            }
        }
    }
}
