using UnityEngine;

// Здесь инициализируется список всех скиллов в игре.
public class SkillBuilder : MonoBehaviour
{
    void Awake()
    {
        BuildSkillsData();
    }

    void BuildSkillsData()
    {
        // Скилл №1 "База"
        int[] dependencies = new int[1] { -1 };
        SkillUnit skill_1 = new SkillUnit(1, "База", 0, true, dependencies);

        // Скилл №2 "Ходить"
        dependencies = new int[1] { 1 };
        SkillUnit skill_2 = new SkillUnit(2, "Ходить", 3, false, dependencies);

        // Скилл №3 "Бегать"
        dependencies = new int[2] { 1, 2 };
        SkillUnit skill_3 = new SkillUnit(3, "Бегать", 5, false, dependencies);

        // Скилл №4 "Летать"
        dependencies = new int[3] { 1, 2, 3 };
        SkillUnit skill_4 = new SkillUnit(4, "Летать", 10, false, dependencies);

        // Скилл №5 "Стрелять из лука"
        dependencies = new int[1] { 1 };
        SkillUnit skill_5 = new SkillUnit(5, "Стрелять из лука", 5, false, dependencies);

        // Скилл №6 "Стрелять из арбалета"
        dependencies = new int[2] { 1, 5 };
        SkillUnit skill_6 = new SkillUnit(6, "Стрелять из арбалета", 5, false, dependencies);


        SkillUnit[] allSkillsList = new SkillUnit[6] { skill_1, skill_2, skill_3, skill_4, skill_5, skill_6 };
        SkillManager.allSkillsList = allSkillsList;
        SkillManager.currentSelectedSkill = SkillManager.allSkillsList[0];
    }


}
