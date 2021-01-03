using System;
using UnityEngine;

/**
 * 
 * 
 */ 
namespace Script
{
    public class CameraControl : MonoBehaviour
    {
        public float distanceAway = 1.7f;
        public float distanceUp = 1.3f;
        public float smooth = 2f;				// how smooth the camera movement is
        public bool isFollow = false;    //  是否可以跟随

        private Vector3 m_TargetPosition;		// the position the camera is trying to be in)

        public Transform follow;
        // Start is called before the first frame update
        void Start()
        {
            //Console.WriteLine("控制台消息...");
            
            //follow = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            // transform.LookAt(follow);
            // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            if(isFollow)
            {
                // setting the target position to be the correct offset from the 
                m_TargetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway + new Vector3(0, 0f, 0);

                // making a smooth transition between it's current position and the position it wants to be in
                transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);
            }
            else
            {
                if (GameObject.FindWithTag("Player") != null)
                {
                    follow = GameObject.FindWithTag("Player").transform;
                    isFollow = true;
                    print("找到了摄像机要的Player");
                }
            }
        
        }

        public void ButtonFunc()
        {
            if(isFollow)
            {
                isFollow = false;
            } else
            {
                isFollow = true;
            }
       
        }
    }
}
