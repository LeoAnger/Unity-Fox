using UnityEngine;

namespace Script.RoleSel
{
    public class SelPlayerMove1 : MonoBehaviour
    {
        public GameObject Cavans;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            //if (UserInfo.PlayerRoleType == PlayerRoleType.Player1)
            if (false)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    print("a");
                    LeftMove();    //左移动
                } else if (Input.GetKeyUp(KeyCode.D))
                {
                    RightMove();    //右移动
                }
            }
        }

        private void LeftMove()
        {
            //1.下一步的位置
            int playerSelPosition1 = RolePosition.PlayerSelPosition1 - 1;
            if (playerSelPosition1 >= 1)
            {
            
                switch (playerSelPosition1)
                {
                    case 1:
                        //2.移动位置
                        transform.position = RolePosition.RoleSelPos1  + Cavans.transform.position;
                        //4.更换角色头像
                        //5.更换角色昵称
                        break;
                    case 2:
                        transform.position = RolePosition.RoleSelPos2 + Cavans.transform.position;
                    
                        break;
                }
                //9.更新位置
                RolePosition.PlayerSelPosition1 = playerSelPosition1;
                print("玩家位置：" + transform.position + "\n当前编号：" + playerSelPosition1);
            } 
        }
    
        private void RightMove()
        {
            //1.下一步的位置
            int playerSelPosition1 = RolePosition.PlayerSelPosition1 + 1;
            if (playerSelPosition1 <= RolePosition.RoleTotalNums)
            {
                switch (playerSelPosition1)
                {
                    case 2:
                        transform.position = RolePosition.RoleSelPos2 + Cavans.transform.position;
                        break;
                }
                //9.更新位置
                RolePosition.PlayerSelPosition1 = playerSelPosition1;
            } 
        }
    }
}
