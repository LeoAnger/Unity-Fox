using UnityEngine;

namespace Robot_Shooting_Game
{
    public class EnemyTest : MonoBehaviour
    {
        
        public int speed;    //移动速度

        private GameObject bulletPrefab;
        private Transform firePos;
        
        // Start is called before the first frame update
        void Start()
        {
            bulletPrefab = Resources.Load("Bullet/Lazer2") as GameObject;
            firePos = transform.GetChild(0);
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            InvokeRepeating(nameof(Attack), 0, Random.Range(2,5));
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    
        void OnTriggerEnter2D(Collider2D coll)
        {
            Debug.Log("碰撞发生-----" + coll.name + "\n" +
                      coll.gameObject.layer + "\n" +
                      coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName);
            switch (coll.gameObject.GetComponent<SpriteRenderer>().sortingLayerName)
            {
                case   "BulletP1" :
                    //1.显示爆炸动画
                    GetComponent<Animator>().SetBool("Explosion", true);
                    //2.爆炸声音
                    //2.销毁自己
                    break;
                case   "BulletP2" :
                    break;
                case   "Player1" :
                    break;
                case   "Player2" :
                    break;
            }
        }

        private void Attack()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            bullet.AddComponent<EnemyBullet>();
            bullet.GetComponent<EnemyBullet>().Speed = Random.Range(5, 8);
            bullet.name = "EnemyBullet";
        }
        
        public void DestroyThis()
        {
            //
            //print("DestroyThis");
            Destroy(gameObject);
        }
    }
}
