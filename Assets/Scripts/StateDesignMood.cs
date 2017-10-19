using UnityEngine;
using System.Collections;

public class StateDesignMood : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Context context = new Context();
        context.SetState(new ConcreteStateA(context));

        context.Handle(5);
        context.Handle(20);
        context.Handle(30);
        context.Handle(4);
        context.Handle(50);
	}
}
///1. 概述：当一个对象的内在状态改变时允许改变其行为，这个对象看起来像是改变了其类。
/// 2. 解决的问题：主要解决的是当控制一个对象状态转换的条件表达式过于复杂时的情况。把状态的判断逻辑转移到表示不同的一系列类当中，可以把复杂的逻辑判断简单化。
/// <summary>
///  上下文环境类：它定义了客户程序需要的接口并维护一个具体状态角色的实例，将与状态相关的操作委托给当前的Concrete State对象来处理。
///  就好比该类是游戏中的一个主角，他需要进行各种不同的状态
/// </summary>
public class Context {
    private IState state;
    public void SetState(IState state) {
        this.state = state;
    }
    public void Handle(int arg) {
        state.Handle(arg);
    }
}

/// <summary>
/// 抽象状态接口（State）：定义一个接口以封装使用上下文环境的的一个特定状态相关的行为。
/// </summary>
public interface IState {
    void Handle(int arg);
}

/// <summary>
/// 具体状态类A（Concrete StateA）：实现抽象状态定义的接口
/// </summary>
public class ConcreteStateA : IState
{
    private Context context;
    public ConcreteStateA(Context context)
    {
        this.context = context;
     }
    public void Handle(int arg)
    {
        Debug.Log("我是具体状态类A，" + arg);
        if (arg > 10)//如果传入的参数大于10就转向另一个具体状态B处理
        {
            this.context.SetState(new ConcreteStateB(this.context));
        }
    }
}

/// <summary>
/// 具体状态类B（Concrete StateB）：实现抽象状态定义的接口
/// </summary>
public class ConcreteStateB : IState
{
    private Context context;
    public ConcreteStateB(Context context)
    {
        this.context = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("我是具体状态类B，" + arg);
        if (arg <= 10)//如果传入的参数大于10就转向另一个具体状态A处理
        {
            this.context.SetState(new ConcreteStateA(this.context));
        }
    }
}