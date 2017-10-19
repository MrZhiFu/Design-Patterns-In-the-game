using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 开始状态（开始界面）
/// </summary>
public class StartState : ISceneState
{
    /// <summary>
    /// 开始界面（状态）构造方法
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <param name="sceneController">场景控制器</param>
    public StartState(string sceneName, SceneStateController sceneController) : base(sceneName, sceneController) { }

    private Image logo;//开始界面Logo
    private float smoothingSpeed = 2f;//透明度过度平滑速率
    private float waitTime = 3f;//加载下一个界面的等待时间

    public override void StateStart()
    {
        logo = GameObject.Find("Logo").GetComponent<Image>();
        logo.color = new Color(1,1,1,0);
    }

    public override void StateUpDate()
    {
        logo.color = Color.Lerp(logo.color,new Color(1,1,1,1),Time.deltaTime * smoothingSpeed);//设置开始界面UI透明度渐变
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            sceneController.SetState(new MainMenuState("MainMenu", sceneController));//到达等待时间进入下一个场景
        }
    }
}
