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

    private Button returnMenuBtn;//返回按钮

    public override void StateStart()
    {
        returnMenuBtn = GameObject.Find("ReturnMenuButton").GetComponent<Button>();
        returnMenuBtn.onClick.AddListener(OnReturnMenuBtnDown); //添加返回主菜单按钮事件监听
    }

    private void OnReturnMenuBtnDown() {//返回按钮点击事件
        sceneController.SetState(new MainMenuState("MainMenu", sceneController));//设置场景为主菜单场景
    }
}
