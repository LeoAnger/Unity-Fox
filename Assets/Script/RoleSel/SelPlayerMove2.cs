using System.Collections;
using System.Collections.Generic;
using Script.MainMenu;
using Script.netWork.UserInfo;
using Script.NetWork.RoomInfo;
using Script.NetWork.UserInfo;
using Script.RoleSel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelPlayerMove2 : MonoBehaviour
{
    public GameObject Cavans;

    //选中后的“√”
    public GameObject PlayerSelected1;    
    public GameObject PlayerSelected2;
    //角色头像
    public Image RoleIcon1;
    public Image RoleIcon2;

    //角色昵称
    public GameObject RoleNick2;
    //临时变量
    public static bool RoleSelected1 = false;
    public static bool RoleSelected2 = false;
    // Start is called before the first frame update
    void Start()
    {
        if (true)
        {
            //1.房间号
            //2.隐藏对号
            PlayerSelected1.active = false;
            PlayerSelected2.active = false;
        }
    }

    
    
    // Update is called once per frame
    void Update()
    {
        //if (UserInfo.PlayerRoleType == PlayerRoleType.Player2)
        if (true)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                print("a");
                LeftMove();    //左移动
            } else if (Input.GetKeyUp(KeyCode.D))
            {
                RightMove();    //右移动
            } else if (Input.GetKeyUp(KeyCode.Return))
            {
                print("我选好了");
                //发送http请求 --> http://www.ip.com/selRole/ready?
                //json:{房间号、房间权限、PlayerRoleType、玩家昵称、RoleId、地图...}
                //模拟
                print("房间号：" + RoomInfo.RoomId + 
                      "\n房间权限：" + RoomInfo.RoomPermissions +
                      "\nPlayerRoleType: " + UserInfo.RoomRoleType +
                      "\n玩家昵称: " + UserInfo.UserName +
                      "\nRoleId: " + RoleInfo.RoleId1);

                while (true)
                {
                    // 等待游戏开始，跳转到GamePlay场景
                    
                    // 跳转GamePlay场景
                    SceneManager.LoadScene(SceneName.GamePlay);
                    
                    // 卸载场景
                    SceneManager.UnloadScene(SceneName.RoleSel);
                    break;

                }
            } else if (Input.GetKeyUp(KeyCode.Space))
            {
                print("动态修改图片");
                //动态修改图片
                RoleIcon2.sprite = Resources.Load("Role/tsunade/icon", typeof(Sprite)) as Sprite;
            }
        }
    }
    
    private void LeftMove()
    {
        //1.下一步的位置
        int playerSelPosition2 = RolePosition.PlayerSelPosition2 - 1;
        if (playerSelPosition2 >= 11)
        {
            
            switch (playerSelPosition2)
            {
                case 11:
                    //2.移动位置
                    transform.position = RolePosition.RoleSelPos11  + Cavans.transform.position;
                    //4.更换角色头像
                    //5.更换角色昵称
                    break;
                case 12:
                    transform.position = RolePosition.RoleSelPos12 + Cavans.transform.position;
                    
                    break;
            }
            //9.更新位置
            RolePosition.PlayerSelPosition2 = playerSelPosition2;
        } 
    }
    
    private void RightMove()
    {
        //1.下一步的位置
        int playerSelPosition2 = RolePosition.PlayerSelPosition2 + 1;
        if (playerSelPosition2 <= RolePosition.RoleTotalNums + 10)
        {
            switch (playerSelPosition2)
            {
                case 12:
                    transform.position = RolePosition.RoleSelPos12 + Cavans.transform.position;
                    break;
            }
            //9.更新位置
            RolePosition.PlayerSelPosition2 = playerSelPosition2;
        } 
    }
}
