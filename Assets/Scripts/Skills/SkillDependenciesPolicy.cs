using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Проверяет соблюдение зависимостей между скиллами.
public static class SkillDependenciesPolicy
{
    // Метод проверяет, можно ли разблокировать текущий скилл (разблокированы ли все зависимые скиллы).
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

    // Метод проверяет, можно ли забыть текущий скилл (есть ли открытые скиллы, зависящие от него). Если такие скиллы есть - надо забыть сначала их.
    // Возвращает true, если текущий скилл можно забыть
    /*
    public static bool HasAllAncestorsLocked(SkillUnit skill)
    {
        bool result = true;

        for (int i = 0; i < skill.unitsToLearn.Length; i++)
        {
            Debug.Log("Шаг цикла i.");
            Debug.Log("Скилл id равен: " + skill.id);
            int[] checkList = SkillManager.GetSkillUnitById(skill.unitsToLearn[i]).unitsToLearn;
            for (int j = 0; j < checkList.Length; j++)
            {
                Debug.Log("Шаг цикла j.");
                Debug.Log("Id в массиве равен: " + checkList[j]);
                if (checkList[j] == skill.id)
                {
                    Debug.Log("Нашёл совпадение.");
                    result = false;
                    break;
                }
            }
        }
        Debug.Log("Вызов HasAllAncestorsLocked. Result равен: " + result);
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
