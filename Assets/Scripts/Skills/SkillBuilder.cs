using UnityEngine;

// ����� ���������������� ������ ���� ������� � ����.
public class SkillBuilder : MonoBehaviour
{
    void Awake()
    {
        BuildSkillsData();
    }

    void BuildSkillsData()
    {
        // ����� �1 "����"
        int[] dependencies = new int[1] { -1 };
        SkillUnit skill_1 = new SkillUnit(1, "����", 0, true, dependencies);

        // ����� �2 "������"
        dependencies = new int[1] { 1 };
        SkillUnit skill_2 = new SkillUnit(2, "������", 3, false, dependencies);

        // ����� �3 "������"
        dependencies = new int[2] { 1, 2 };
        SkillUnit skill_3 = new SkillUnit(3, "������", 5, false, dependencies);

        // ����� �4 "������"
        dependencies = new int[3] { 1, 2, 3 };
        SkillUnit skill_4 = new SkillUnit(4, "������", 10, false, dependencies);

        // ����� �5 "�������� �� ����"
        dependencies = new int[1] { 1 };
        SkillUnit skill_5 = new SkillUnit(5, "�������� �� ����", 5, false, dependencies);

        // ����� �6 "�������� �� ��������"
        dependencies = new int[2] { 1, 5 };
        SkillUnit skill_6 = new SkillUnit(6, "�������� �� ��������", 5, false, dependencies);


        SkillUnit[] allSkillsList = new SkillUnit[6] { skill_1, skill_2, skill_3, skill_4, skill_5, skill_6 };
        SkillManager.allSkillsList = allSkillsList;
        SkillManager.currentSelectedSkill = SkillManager.allSkillsList[0];
    }


}
