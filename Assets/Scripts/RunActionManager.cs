using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunActionManager : BaseActionManager, MyActionCallback
{
    //飞行动作
    public RunAction flyAction;
    //控制器
    public FirstController controller;

    protected new void Start()
    {
        controller = (FirstController)MyDirector.GetInstance().CurrentScenceController;
        controller.actionManager = this;
    }

    public void Fly(GameObject ufo, float speed, Vector3 direction)
    {
        flyAction = RunAction.GetSSAction(direction, speed);
        Run(ufo, flyAction, this);
    }

    //回调函数
    public void BaseActionEvent(MyBaseAction source,
    BaseActionEventType events = BaseActionEventType.Competed,
    int intParam = 0,
    string strParam = null,
    Object objectParam = null)
    {
        //飞碟结束飞行后进行回收
        controller.ufoFactory.FreeDisk(source.gameObject);
    }
}
