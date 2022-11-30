using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RunAction :MyBaseAction
{
    float gravity;          //重力加速度
    float speed;            //水平速度
    Vector3 direction;      //飞行方向
    float time;             //时间

    //生产函数(工厂模式)
    public static RunAction GetSSAction(Vector3 direction, float speed)
    {
        RunAction action = ScriptableObject.CreateInstance<RunAction>();
        action.gravity = 9.8f;
        action.time = 0;
        action.speed = speed;
        action.direction = direction;
        return action;
    }

    public override void Start()
    {

    }

    public override void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.down * gravity * time * Time.deltaTime);
        transform.Translate(direction * speed * Time.deltaTime);
        //如果飞碟到达底部，则动作结束，进行回调
        if (this.transform.position.y < -6)
        {
            this.destroy = true;
            this.enable = false;
            this.callback.BaseActionEvent(this);
        }

    }
}
