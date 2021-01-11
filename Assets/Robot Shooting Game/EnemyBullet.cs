using UnityEngine;

namespace Robot_Shooting_Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyBullet : MonoBehaviour
    {
    
        public int Speed = 10;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            if (transform.position.x < -10)
            {
                //print("自行销毁子弹。。。");
                Destroy(gameObject);
            }
        }
    }
}
