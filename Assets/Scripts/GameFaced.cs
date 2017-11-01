using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏上的外观模式类
/// </summary>
public class GameFaced{

    private GameFaced() { }//构造函数私有化

    //使用单例模式来使该外观类的访问更加简单（因为该类的功能不需要再进一步进行拓展，所以考虑使用单例模式）
    private  static GameFaced _instace = new GameFaced();
    public static GameFaced Instace{   get {return _instace; }}
    
    private bool isGameOver = false;//游戏是否结束
    public bool IsGameOver{  get{ return isGameOver; } }



    /// <summary>
    /// 初始化函数，初始化管理的各个子系统（具体状态内容还待开发。。。）
    /// </summary>
    public void Init() { }

    /// <summary>
    /// 子系统状态更新方法
    /// </summary>
    public void Update() { }

    /// <summary>
    /// 更换子系统状态时释放资源方法
    /// </summary>
    public void Release() { }
}
