﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo {
    private string _schoolName = "";
    private int _schoolGrade = 4;
    private int _classNum = 0;
    private int _number = 0;
    private string _name = "";
    private int _gender = 0;

    public bool InitUserInfo(List<string> listString)
    {
        _schoolName = listString[0];
        _schoolGrade = System.Convert.ToInt32(listString[1].Trim());
        _classNum = System.Convert.ToInt32(listString[2].Trim());
        _number = System.Convert.ToInt32(listString[3].Trim());
        _name = listString[4];
        _gender = System.Convert.ToInt32(listString[5].Trim());

        if (IsInitInfo() == false)
            return false;

        return true;
    }

    public bool IsInitInfo()
    {
        if (_schoolName == "")
        {
            Debug.Log("학교이름 안적었어");
            return false;
        }

        if (_schoolGrade == 0)
        {
            Debug.Log("학년 안적었어");
            return false;
        }

        if (_classNum == 0)
        {
            Debug.Log("반 안적었어");
            return false;
        }

        if (_number == 0)
        {
            Debug.Log("번호 안적었어");
            return false;
        }

        if (_name == "")
        {
            Debug.Log("이름 안적었어");
            return false;
        }

        return true;
    }

    public List<string> GetInfo()
    {
        List<string> list = new List<string>();

        list.Add(_schoolName.ToString());
        list.Add(_schoolGrade.ToString());
        list.Add(_classNum.ToString());
        list.Add(_number.ToString());
        list.Add(_name.ToString());
        list.Add(_gender.ToString());

        return list;
    }

    public int GetGender() { return _gender; }
    public int GetSchoolGrade() { return _schoolGrade; } 
}

public class MissionInfo
{
    private List<string> _mission;

    public MissionInfo()
    {
        _mission = new List<string>();
        for(int i = 0; i < 4; ++i)
            _mission.Add("");

        Debug.Log(_mission.Count);
    }

    public void InitMissionInfo(List<string> listString)
    {
        _mission[0] = listString[0];
        _mission[1] = listString[1];
        _mission[2] = listString[2];
        _mission[3] = listString[3];
    }

    public List<string> GetInfo()
    {
        List<string> list = new List<string>();
        list.Add(_mission[0]);
        list.Add(_mission[1]);
        list.Add(_mission[2]);
        list.Add(_mission[3]);

        return list;
    }
}