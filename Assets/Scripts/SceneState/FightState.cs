using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 第三状态(战斗场景)
/// </summary>
public class FightState : ISceneState
{
    /// <summary>
    /// 开始界面（状态）构造方法
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <param name="sceneController">场景控制器</param>
    public FightState(string sceneName, SceneStateController sceneController) : base(sceneName, sceneController){}

    //private Button returnMenuBtn;//返回按钮

    private GameFaced gameFaced;//持有一个外观模式的引用

    public override void StateStart()
    {
        gameFaced.Init();
    }
    public override void StateEnd()
    {
        gameFaced.Release();
    }
    public override void StateUpDate()
    {
        if (gameFaced.IsGameOver == true)//如果游戏结束就换到主菜单界面
        {
            sceneController.SetState(new MainMenuState("MainMenu", sceneController));
        }
        gameFaced.Update();
    }
}