using UnityEngine;

namespace Script.Player
{
    public class Player1 : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Collider2D _coll;
        private Animator _anim;

        public float Speed = 5, JumpForce = 18;

        public Transform GroundCheck;
        public LayerMask Ground;

        public bool IsGround, IsJump;

        private bool _jumpPressed = false;
        private int _jumpCount = 2;
    
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _coll = GetComponent<Collider2D>();
            _anim = GetComponent<Animator>(); 
        
            // 网络创建 --> 到指定的类Class获取参数
            Transform[] father = GetComponentsInChildren<Transform>();
            foreach (var child in father)
            {
                //Debug.Log(child.name);
                if (child.name.Equals("GroundCheck"))
                {
                    GroundCheck = child.transform;
                }
            }
            
            Ground = LayerMask.GetMask("Ground");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.J) && _jumpCount > 0)
            {
                _jumpPressed = true;
            
            }
        }

        void FixedUpdate()
        {
            IsGround = Physics2D.OverlapCircle(GroundCheck.position, 0.1f, Ground);
        
            GroundMovement();
            Jump();
            SwitchAnim();

        }

        void Jump()
        {
            if (IsGround)
            {
                IsJump = false;
                _jumpCount = 2;
            }

            if (_jumpPressed && IsGround)
            {
                IsJump = true;
                _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
                _jumpCount--;
                _jumpPressed = false;
            }
            else if (_jumpPressed && _jumpCount > 0 && IsJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
                _jumpCount--;
                _jumpPressed = false;
            }
        }
    
        void GroundMovement()
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(horizontalMove * Speed, _rb.velocity.y);

            if (horizontalMove != 0)
            {
                transform.localScale = new Vector3(horizontalMove, 1, 1);
            }
        }

        void SwitchAnim()
        {
            // 左右移动
            _anim.SetFloat("running", Mathf.Abs(_rb.velocity.x));

            if (IsGround)
            {
                _anim.SetBool("falling", false);
            } else if (!IsGround && _rb.velocity.y > 0)
            {
                // 跳跃
                _anim.SetBool("jumping", true);
            } else if (_rb.velocity.y < 0)
            {
                // 下落
                _anim.SetBool("jumping", false);
                _anim.SetBool("falling", true);
            }
        }
    }
}
