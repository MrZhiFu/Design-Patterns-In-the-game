using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏上的外观模式类
/// </summary>
public class GameFaced{

    private bool isGameOver = false;//游戏是否结束

    public bool IsGameOver
    {
        get{ return isGameOver; }
    }

    /// <summary>
    /// 初始化函数
    /// </summary>
    public void Init() { }

    /// <summary>
    /// 状态更新方法
    /// </summary>
    public void Update() { }

    /// <summary>
    /// 更换状态时释放资源方法
    /// </summary>
    public void Release() { }
}
