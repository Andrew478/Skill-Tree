using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��������� ���������� ������������ ����� ��������.
public static class SkillDependenciesPolicy
{
    // ����� ���������, ����� �� �������������� ������� ����� (�������������� �� ��� ��������� ������).
    public static bool HasAllDepUnlocked(SkillUnit skill)
    {
        bool result = true;
        for (int i = 0; i < skill.unitsToLearn.Length; i++)
        {
            if (!(SkillManager.GetSkillUnitById(skill.unitsToLearn[i]).isLearned))
            {
                result = false;
                break;
            }
        }
        return result;
    }

    // ����� ���������, ����� �� ������ ������� ����� (���� �� �������� ������, ��������� �� ����). ���� ����� ������ ���� - ���� ������ ������� ��.
    // ���������� true, ���� ������� ����� ����� ������
    /*
    public static bool HasAllAncestorsLocked(SkillUnit skill)
    {
        bool result = true;

        for (int i = 0; i < skill.unitsToLearn.Length; i++)
        {
            Debug.Log("��� ����� i.");
            Debug.Log("����� id �����: " + skill.id);
            int[] checkList = SkillManager.GetSkillUnitById(skill.unitsToLearn[i]).unitsToLearn;
            for (int j = 0; j < checkList.Length; j++)
            {
                Debug.Log("��� ����� j.");
                Debug.Log("Id � ������� �����: " + checkList[j]);
                if (checkList[j] == skill.id)
                {
                    Debug.Log("����� ����������.");
                    result = false;
                    break;
                }
            }
        }
        Debug.Log("����� HasAllAncestorsLocked. Result �����: " + result);
        return result;
    }
    */
    public static bool HasAllAncestorsLocked(SkillUnit skill)
    {
        bool result = true;

        for (int i = 0; i < SkillManager.allSkillsList.Length; i++)
        {
            int[] checkList = SkillManager.allSkillsList[i].unitsToLearn;
            for (int j = 0; j < checkList.Length; j++)
            {
                if (checkList[j] == skill.id)
                {
                    if(SkillManager.allSkillsList[i].isLearned) result = false;
                    break;
                }
            }
        }
        return result;
    }
}
