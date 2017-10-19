using UnityEngine;
using System.Collections;

/// <summary>
/// 此类用来启动状态模式下的场景管理器
/// </summary>
public class GameLoop : MonoBehaviour {
    private SceneStateController stateController = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        stateController = new SceneStateController();
        stateController.SetState(new StartState("Start", stateController), false); ;
	}
	
	// Update is called once per frame
	void Update () {
        stateController.StateUpdate();//启动场景管理器
	}
}
