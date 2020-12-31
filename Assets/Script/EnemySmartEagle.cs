 using UnityEngine;
 using UnityEngine.Tilemaps;

 public class EnemySmartEagle : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    
    public Collider2D coll;
    public TilemapCollider2D groundColl;
    public LayerMask player;
    
    void Start()
    {
        init();
    }
    void Update()
    {
        // 敌人移动
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        // 移动判断
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {    // 到达位置
            if (waitTime <= 0) init();
            else waitTime -= Time.deltaTime;
        }
        // 碰撞检测
        if (coll.IsTouchingLayers(player))
        {
            // transform.position = new Vector2(10, 10);
            Debug.Log("老鹰撞击了玩家:" + this.name + "," + this.tag );
        }
        
        // 失败...    日期：2020年7月13日
        if (coll.IsTouching(groundColl))
        {
            Debug.Log("老鹰撞击了地面...");
        }
    }
    private void init()
    {
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }
    Vector2 GetRandomPos()
    {
        Vector2 randPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return randPos;
    }
}
