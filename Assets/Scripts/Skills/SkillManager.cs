using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillUnit[] allSkillsList;
    public static SkillUnit currentSelectedSkill;

    /*
    public static void LockAllSkills()
    {
        for (int i = 1; i < allSkillsList.Length; i++)
        {
            allSkillsList[i].Lock();
        }
    }
    */
    public static SkillUnit GetSkillUnitById(int id)
    {
        for (int i = 0; i < allSkillsList.Length; i++)
        {
            if (allSkillsList[i].id == id) return allSkillsList[i];
        }
        return allSkillsList[0];
    }
    public static void SetSkillUnitAsActive(int id)
    {
        for (int i = 0; i < allSkillsList.Length; i++)
        {
            if (allSkillsList[i].id == id) currentSelectedSkill = allSkillsList[i];
        }
    }
}
