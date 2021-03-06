﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum TABLE_INFO
{
    INDEX,
    GENDER,
    SCHOOL_GRADE,
    PAPS_GRADE,
    MIN,
    MAX,
    MAX_TABLE_INFO
}

public enum TABLE_TYPE
{
    REPEAT_LONG_RUNNING,        // 왕복오래달리기
    LONG_RUNNING,               // 오래달리기
    FIFTY_M_RUNNING,            // 50m달리기
    STANDING_BROAD_JUMP,        // 제자리멀리뛰기
    SIT_UP,                     // 윗몸일으키기
    GRIP,                       // 악력
    SIT_UPPERBODY_FRONTBEND,    // 앉아서윗몸앞으로굽히기
    BMI,                        // BMI
    MAX_SCRIPT_TYPE
}

public class PAPSTableManager
{
    private Dictionary<TABLE_TYPE, PAPSTable> _dicPAPSScript;
    private string[] _tableName;

    public PAPSTableManager()
    {
        _dicPAPSScript = new Dictionary<TABLE_TYPE, PAPSTable>();
        _tableName = new string[(int)TABLE_TYPE.MAX_SCRIPT_TYPE];
        _tableName[(int)TABLE_TYPE.REPEAT_LONG_RUNNING] = "RepeatLongRunning";
        _tableName[(int)TABLE_TYPE.LONG_RUNNING] = "LongRunning";
        _tableName[(int)TABLE_TYPE.FIFTY_M_RUNNING] = "FiftyMRunning";
        _tableName[(int)TABLE_TYPE.STANDING_BROAD_JUMP] = "StandingBroadJump";
        _tableName[(int)TABLE_TYPE.SIT_UP] = "Situp";
        _tableName[(int)TABLE_TYPE.GRIP] = "Grip";
        _tableName[(int)TABLE_TYPE.SIT_UPPERBODY_FRONTBEND] = "SitUpperBodyFrontBend";
        _tableName[(int)TABLE_TYPE.BMI] = "BMI";
    }

    public void ReadTableFile()
    {
        for (int i = 0; i < _tableName.Length; ++i)
        {
            TextAsset data = Resources.Load(_tableName[i]) as TextAsset;
            StringReader sr = new StringReader(data.text);

            string line = sr.ReadLine();
            string[] words;
            PAPSTable papsTable = new PAPSTable();
            while (line != null)
            {
                words = line.Split(',');
                if (words.Length == 0)
                {
                    sr.Close();
                    return;
                }

                if (words.Length != (int)TABLE_INFO.MAX_TABLE_INFO)
                {
                    Debug.Log("table length != 6");
                    return;
                }

                int index = System.Convert.ToInt32(words[(int)TABLE_INFO.INDEX].Trim());
                int gender = System.Convert.ToInt32(words[(int)TABLE_INFO.GENDER].Trim());
                int schoolGrade = System.Convert.ToInt32(words[(int)TABLE_INFO.SCHOOL_GRADE].Trim());
                int papsGrade = System.Convert.ToInt32(words[(int)TABLE_INFO.PAPS_GRADE].Trim());
                float min = System.Convert.ToSingle(words[(int)TABLE_INFO.MIN].Trim());
                float max = System.Convert.ToSingle(words[(int)TABLE_INFO.MAX].Trim());

                papsTable.AddPAPSSriptInfo(index, gender, (SCHOOL_GRADE)schoolGrade, (PAPS_GRADE)papsGrade, min, max);
                line = sr.ReadLine();
            }

            _dicPAPSScript.Add((TABLE_TYPE)i, papsTable);
        }
    }

    public PAPS_GRADE FindPAPSGrade(TABLE_TYPE tableType, int gender, SCHOOL_GRADE schoolGrade, float value)
    {
        return _dicPAPSScript[tableType].FindPAPSGrade(gender, schoolGrade, value);
    }
}