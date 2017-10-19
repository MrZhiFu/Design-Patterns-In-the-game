using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
///第二状态（主场景） 
/// </summary>
public class MainMenuState : ISceneState
{
    /// <summary>
    /// 开始界面（状态）构造方法
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <param name="sceneController">场景控制器</param>
    public MainMenuState(string sceneName, SceneStateController sceneController) : base(sceneName, sceneController){}

    private Button startButton;//开始游戏按钮

    public override void StateStart()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(OnStartBtnDown);//添加开始游戏按钮事件监听
    }

    private void OnStartBtnDown() {//开始游戏按钮事件
        sceneController.SetState(new FightState("FightScene", sceneController));//设置为战斗状态（战斗场景）
    }
}
