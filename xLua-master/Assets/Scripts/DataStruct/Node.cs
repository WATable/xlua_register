using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PointType
{
    Home,
    Hole,
    Farm,
}
/// <summary>
public class PosNode
{
    public int id;
    public PointType pointType;
    public Vector2 postion;

    List<PosNode> childNode = new List<PosNode>();

    public void addChild(PosNode node)
    {
        childNode.Add(node);
    }

    private Action<PosNode> clickUI;

    public Action<PosNode> ClickUI
    {
        set
        {
            clickUI = value;
        }
    }
}
/// 点的信息
/// </summary>
public struct PointInfo
{
    public int id;
    public PointType pointType;
    public Vector2 position;

};


public class Player
{
    int maxHp = 100;
    int maxExp = 100;

    int hp = 100;
    int exp = 0;
    public Action<PosNode> MoveEnd;
    public void Move(PosNode node)
    {
        //移动
        if (MoveEnd!=null)
        {
            MoveEnd(node);
        }
    }

    public void AddHP(int _hp)
    {
        hp = Mathf.Clamp(hp + _hp, 0, maxHp);

        if (hp <= 0)
        {
            //失败
        }
    }

    public void AddExp(int _exp)
    {
        exp += _exp;
        if (exp > maxExp)
        {
            //升级
        }
    }
}

public class GameRoot
{
    //c++中std::vector<>就是C#中的List<>
    List<PointInfo> pointList;
    Player player;

    public GameRoot()
    {
        player = new global::Player();
        pointList = new List<global::PointInfo>();
    }

    public void Start()
    {
        foreach (var item in pointList)
        {
            PosNode node = new PosNode();
            node.postion = item.position;
            node.pointType = item.pointType;
            node.id = item.id;

            node.addChild(node);

            node.ClickUI = OnClickFunc;
        }
    }

    public void OnClickFunc(PosNode posNode)
    {
        player.Move(posNode);
        player.MoveEnd = MoveEndFunc;
    }

    void MoveEndFunc(PosNode posNode)
    {
        switch (posNode.pointType)
        {
            case PointType.Home:
                player.AddHP(100);
                break;
            case PointType.Hole:
                player.AddHP(-20);
                player.AddExp(10);
                destroy(posNode);
                break;
            case PointType.Farm:
                player.AddHP(-10);
                player.AddExp(5);
                destroy(posNode);
                break;
        }
    }

    public void destroy(PosNode node)
    {
        for (int i = 0; i < pointList.Count; i++)
        {
            if (node.id == pointList[i].id)
            {
                pointList.Remove(pointList[i]);
                break;
            }
        }
    }
}

