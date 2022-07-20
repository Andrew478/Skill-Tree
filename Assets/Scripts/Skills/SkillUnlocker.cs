using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillUnlocker 
{
    public static void UnlockSkill()
    {
        if (SkillManager.currentSelectedSkill.isLearned) return;
        if (!(SkillDependenciesPolicy.HasAllDepUnlocked(SkillManager.currentSelectedSkill))) return;
        
        if (Scores.HasEnoughScores(SkillManager.currentSelectedSkill.cost))
        {
            Scores.RemoveScore(SkillManager.currentSelectedSkill.cost);
            SkillManager.currentSelectedSkill.Unlock();
        }
    }
    public static void LockSkill()
    {
        if (!(SkillDependenciesPolicy.HasAllAncestorsLocked(SkillManager.currentSelectedSkill))) return;

        Scores.AddScore(SkillManager.currentSelectedSkill.Lock());
    }
    public static void LockAllSkills()
    {
        int scoreSum = 0;
        for (int i = 0; i < SkillManager.allSkillsList.Length; i++)
        {
            scoreSum += SkillManager.allSkillsList[i].Lock();
        }
        Scores.AddScore(scoreSum);
    }
}
