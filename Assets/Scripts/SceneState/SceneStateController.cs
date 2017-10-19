using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景管理器
/// </summary>
public class SceneStateController {
    private ISceneState sceneState;//申明一个ISceneState对象
    private AsyncOperation ao;//用于接收异步加载场景的返回值， 判断异步加载场景是否加载完毕
    private bool isRunStart = false;//是否运行过StateStart( )方法

    /// <summary>
    /// //设置状态方法
    /// </summary>
    /// <param name="sceneState">场景状态接口对象</param>
    /// <param name="isLoadScene">是否需要加载场景（第一个场景不用加载）</param>
    public void SetState(ISceneState sceneState,bool isLoadScene = true) {
        if (sceneState != null)
        {
            sceneState.StateEnd();//该场景结束后做一下清理工作啥的
        }
        this.sceneState = sceneState;//将该状态（该场景）更新为新状态（新场景）
        if (isLoadScene == true)
        {
            ao = SceneManager.LoadSceneAsync(sceneState.SceneName);
            isRunStart = false;
        }
        else
        {
            this.sceneState.StateStart();
            isRunStart = true;
        }
    }

    /// <summary>
    ///更新状态（场景）方法
    /// </summary>
    public void StateUpdate() {
        if (ao != null && ao.isDone == false) return;//如果处于正在加载的过程中，就不用更新状态了
  
        if (ao != null && ao.isDone == true && isRunStart == false)//如果异步加载完成，并且没有运行过SetState()方法就执行加载资源啥的方法
        {
            sceneState.StateStart();
            isRunStart = true;
        }
        if (sceneState != null)
        {
            sceneState.StateUpDate();
        }
    }
}
