using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserGUI : MonoBehaviour
{
    private IUserAction userAction;
    public string gameMessage;
    public int points;
    static public int myrounds;
    void Start()
    {
        points = 0;
        gameMessage = "";
        userAction = MyDirector.GetInstance().CurrentScenceController as IUserAction;
    }

    void OnGUI()
    {
        //С�����ʼ��
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 30;

        //�������ʼ��
        GUIStyle bigStyle = new GUIStyle();
        bigStyle.normal.textColor = Color.red;
        bigStyle.fontSize = 50;

        GUI.Label(new Rect(400, 30, 50, 200), "Hit UFO", bigStyle);
        GUI.Label(new Rect(20, 0, 100, 50), "Points: " + points, style);
        GUI.Label(new Rect(200, 0, 300, 50), "Rounds: " + myrounds, style);
        GUI.Label(new Rect(400, 100, 50, 200), gameMessage, style);
        if (GUI.Button(new Rect(20, 50, 100, 40), "Restart"))
        {
            userAction.Restart();
        }
        if (GUI.Button(new Rect(20, 100, 100, 40), "Normal Mode"))
        {
            userAction.SetMode(false);
        }
        if (GUI.Button(new Rect(20, 150, 100, 40), "Infinite Mode"))
        {
            userAction.SetMode(true);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            userAction.Hit(Input.mousePosition);
        }
    }
}

