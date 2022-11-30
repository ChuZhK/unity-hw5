using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunActionManager : BaseActionManager, MyActionCallback
{
    //���ж���
    public RunAction flyAction;
    //������
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

    //�ص�����
    public void BaseActionEvent(MyBaseAction source,
    BaseActionEventType events = BaseActionEventType.Competed,
    int intParam = 0,
    string strParam = null,
    Object objectParam = null)
    {
        //�ɵ��������к���л���
        controller.ufoFactory.FreeDisk(source.gameObject);
    }
}
