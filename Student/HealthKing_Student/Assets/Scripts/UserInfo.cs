﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo {
    private string _schoolName = null;
    private int _schoolGrade = 0;
    private int _classNum = 0;
    private int _number = 0;
    private string _name = null;
    private string _gender = null;

    public bool InitUserInfo(string schoolName, int schoolGrade, int classNum, int number, string name, string gender)
    {
        if (schoolName == null)
        {
            Debug.Log("이름 안적었어");
            return false;
        }

        if (schoolGrade == 0)
        {
            Debug.Log("학년 안적었어");
            return false;
        }

        if (classNum == 0)
        {
            Debug.Log("반 안적었어");
            return false;
        }

        if (number == 0)
        {
            Debug.Log("번호 안적었어");
            return false;
        }

        if (name == null)
        {
            Debug.Log("이름 안적었어");
            return false;
        }

        if (gender == null)
        {
            Debug.Log("성별 안적었어");
            return false;
        }

        _schoolName = schoolName;
        _schoolGrade = schoolGrade;
        _classNum = classNum;
        _number = number;
        _name = name;
        _gender = gender;

        return true;
    }
}
