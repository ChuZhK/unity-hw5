using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum BaseActionEventType : int { Started, Competed }
public interface MyActionCallback
{
    //�ص�����
    void BaseActionEvent(MyBaseAction source,
        BaseActionEventType events = BaseActionEventType.Competed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null);
}
