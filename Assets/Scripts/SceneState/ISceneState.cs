using UnityEngine;
using System.Collections;

/// <summary>
/// 场景状态接口（严格意义上来说不是一个接口，此时是一个父类，因为在其中会有子类需要继承的方法）
/// </summary>
public class ISceneState {
    private string sceneName;//需要加载的场景名
    protected SceneStateController sceneController;//表示该状态的拥有者，也就是场景管理器

    /// <summary>
    /// 获取场景名
    /// </summary>
    public string SceneName
    {
        get
        {
            return sceneName;
        }
    }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <param name="sceneController">场景管理器</param>
    public ISceneState(string sceneName,SceneStateController sceneController) {
        this.sceneName = sceneName;
        this.sceneController = sceneController;
    }

    /// <summary>
    /// 场景加载时的方法（在游戏中可能需要加载资源啥的），每次进入到这个状态时调用
    /// </summary>
    public virtual void StateStart() { }

    /// <summary>
    /// 场景结束时的方法（在游戏中可能需要释放资源啥的），每次退出到这个状态时调用
    /// </summary>
    public virtual void StateEnd() { }

    /// <summary>
    /// 更新场景
    /// </summary>
    public virtual void StateUpDate() { }
}
