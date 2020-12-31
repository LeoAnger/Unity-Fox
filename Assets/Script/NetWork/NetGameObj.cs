using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Script.NetWork.Entity;
using Script.Prefab;
using UnityEngine;

/*
 * 1.初始化物体
 * 2.销毁物体
 */
public class NetGameObj : MonoBehaviour
{
    
    public static string sourceDatas = "";
    public static string sourceDatasTemp = "";    //缓冲数据
    public static bool isReadedData = true;
    
    private GameObjEntity deserializeObject = new GameObjEntity();
    
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
            sourceDatas = sourceDatasTemp;
            isReadedData = true;
            deserializeObject = JsonConvert.DeserializeObject<GameObjEntity>(sourceDatas);
            
            //逻辑处理
            if (deserializeObject.CreateOrDestroy)
            {
                // Create
                GameObject go = Instantiate(
                    Resources.Load<GameObject>(
                        Prefab.Maps[deserializeObject.PrefabName]),
                    new Vector3(deserializeObject.PositionX,
                        deserializeObject.PositionY,
                        deserializeObject.PositionZ), 
                    Quaternion.identity);
                go.name = deserializeObject.ObjName;
                print("创建物体成功..." + go.name);
            }
            else
            {
                // Destroy
                var find = GameObject.Find(deserializeObject.ObjName);
                if (find)
                {
                    Destroy(find);
                    print("销毁物体");
                }
            }
        }
    }
}
