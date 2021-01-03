﻿using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class ReadText : MonoBehaviour
    {
        private string text1;
        public Text text;    // Unity初始化指定

        public void btnTexRead_Click()
        {
            string showLocalPath = ShowLocalPath();
            //文件路径
            string filePath = showLocalPath + "/Assets/Maps/map1.txt";
            try
            {
                if (File.Exists(filePath))
                {
                    text1 = File.ReadAllText(filePath);
                    byte[] mybyte = Encoding.UTF8.GetBytes(text1);
                    text1 = Encoding.UTF8.GetString(mybyte);
                }
                else
                {
                    Debug.Log("文件不存在...或未找到...\n" + showLocalPath);
                    text.text = "文件不存在...或未找到..." + showLocalPath;
                }
                Debug.Log("读取的文本：" + text1);
                text.text = "读取的文本：" + text1;
            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex.Message);
                text.text = ex.Message;
            }
        }

        public string ShowLocalPath()
        {
        
            //获取模块的完整路径。
            string path1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //获取和设置当前目录(该进程从中启动的目录)的完全限定目录
            string path2 = System.Environment.CurrentDirectory;
            //获取应用程序的当前工作目录
            string path3 = System.IO.Directory.GetCurrentDirectory();
            //获取程序的基目录
            string path4 = System.AppDomain.CurrentDomain.BaseDirectory;
            //获取和设置包括该应用程序的目录的名称
            //string path5 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //获取启动了应用程序的可执行文件的路径
            //string path6 = System.Windows.Forms.Application.StartupPath;
            //获取启动了应用程序的可执行文件的路径及文件名
            //string path7 = System.Windows.Forms.Application.ExecutablePath;

            StringBuilder str=new StringBuilder();
            str.AppendLine("System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName:" + path1);
            str.AppendLine("System.Environment.CurrentDirectory:" + path2);
            str.AppendLine("System.IO.Directory.GetCurrentDirectory():" + path3);
            str.AppendLine("System.AppDomain.CurrentDomain.BaseDirectory:" + path4);
            // str.AppendLine("System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase:" + path5);
            // str.AppendLine("System.Windows.Forms.Application.StartupPath:" + path6);
            // str.AppendLine("System.Windows.Forms.Application.ExecutablePath:" + path7);
            string allPath = str.ToString();
            text.text = allPath;
            return path2;
        }
    }
}
