using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 碰撞开始
    void OnCollisionEnter(Collision collision) {
        // 销毁当前游戏物体
        Destroy(this.gameObject);
        Debug.Log("碰撞：" + collision.gameObject.tag);
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision) {

    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision) {

    }
}
