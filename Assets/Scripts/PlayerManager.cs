using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家控制器，单例模式获取实例
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
