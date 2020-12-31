using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    public Collider2D coll;
    public LayerMask player;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 碰撞检测
        if (coll.IsTouchingLayers(player))
        {
            transform.position = new Vector2(10, 10);
        }
    }
}
