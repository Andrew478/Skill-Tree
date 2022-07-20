using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Events;


public class Skill_UI : MonoBehaviour
{
    [SerializeField]
    GameObject[] UI_SkillButtons;

    [SerializeField]
    Text UI_Skill_Description_Header;
    [SerializeField]
    Text UI_Skill_Description;

    [SerializeField]
    Button Btn_UnlockSkill;
    [SerializeField]
    Button Btn_LockSkill;



    [Space] [Space]
    public UnityEvent OnScoreChange; // Для подключения обновления Score UI

    Skill_UI_Unit currentSelectedSkillButtonScript;
    public Skill_UI_Unit CurrentSelectedButtonScript { get { return currentSelectedSkillButtonScript; } set { currentSelectedSkillButtonScript = value; } }

    // Части текста UI, отображаемые при описании умения, вынесены в отдельные переменные для доступности локализации.
    string header_nothingSelected = "Умение не выбрано";
    string header = "Умение: ";

    string description_skillName = "Умение: ";
    string description_skillCost = "Стоимость изучения: ";
    string description_skillCost_ScoreName = "очков";
    string description_skillIsLearned = "Изучено: ";
    string description_skillIsLearned_Yes = "Да";
    string description_skillIsLearned_No = "Нет";
    string description_dependencies = "Перед изучением нужно освоить: ";
    string description_dependencies_Null = "Ничего";



    void Start()
    {
        Update_UI_Skill_Description(false);
        Update_UI_Skill_Buttons();
        Update_UI_Skill_Buttons_SkillCtrl();
    }


    public void Update_UI_Skill_Description(bool showEmpty) 
    {
        if (showEmpty)
        {
            UI_Skill_Description_Header.text = header_nothingSelected;
            UI_Skill_Description.text = string.Empty;
        }
        else
        {
            UI_Skill_Description_Header.text = header + SkillManager.currentSelectedSkill.name;

            StringBuilder sb = new StringBuilder(
                description_skillName + SkillManager.currentSelectedSkill.name + ".\n" +
                description_skillCost + SkillManager.currentSelectedSkill.cost + ".\n" +
                description_skillIsLearned + (SkillManager.currentSelectedSkill.isLearned ? description_skillIsLearned_Yes : description_skillIsLearned_No) + ".\n" +
                description_dependencies + BuildDependenciesList()
                );
            UI_Skill_Description.text = sb.ToString();
        }

        if(currentSelectedSkillButtonScript != null) currentSelectedSkillButtonScript.DisplayInfo();
    }
    // Обновление отображения кнопок, выбирающих скилл
    void Update_UI_Skill_Buttons()
    {
        for (int i = 0; i < UI_SkillButtons.Length; i++)
        {
            UI_SkillButtons[i].GetComponent<Skill_UI_Unit>().DisplayInfo();
        }
    }
    // Обновление отображения кнопок, управляющих скиллом
    public void Update_UI_Skill_Buttons_SkillCtrl()
    {
        Btn_UnlockSkill.interactable = (!(SkillManager.currentSelectedSkill.isLearned) && SkillDependenciesPolicy.HasAllDepUnlocked(SkillManager.currentSelectedSkill) && Scores.HasEnoughScores(SkillManager.currentSelectedSkill.cost));
        Btn_LockSkill.interactable = (SkillManager.currentSelectedSkill.isLearned && SkillDependenciesPolicy.HasAllAncestorsLocked(SkillManager.currentSelectedSkill));
    }
    string BuildDependenciesList()
    {
        StringBuilder depList = new StringBuilder();

        if (SkillManager.currentSelectedSkill.unitsToLearn[0] != -1) // id "-1" означает нет зависимостей
        {
            for (int i = 0; i < SkillManager.allSkillsList.Length; i++)
            {
                int j = SkillManager.allSkillsList[i].id;
                for (int k = 0; k < SkillManager.currentSelectedSkill.unitsToLearn.Length; k++)
                {
                    if(j == SkillManager.currentSelectedSkill.unitsToLearn[k]) depList.Append(SkillManager.allSkillsList[i].name + ", ");
                }
            }
            if(depList.Length > 1) depList.Remove(depList.Length - 2, 2); // Удаляем последние ", "
        }
        else
        {
            depList.Append(description_dependencies_Null);
        }

        depList.Append(".");

        return depList.ToString();
    }

    public void UnlockCurrentSkill()
    {
        SkillUnlocker.UnlockSkill();
        Update_UI_Skill_Description(false);
        Update_UI_Skill_Buttons_SkillCtrl();
        OnScoreChange.Invoke();
    }
    public void LockCurrentSkill()
    {
        SkillUnlocker.LockSkill();
        Update_UI_Skill_Description(false);
        Update_UI_Skill_Buttons_SkillCtrl();
        OnScoreChange.Invoke();
    }
    public void LockAllSkills()
    {
        SkillUnlocker.LockAllSkills();
        Update_UI_Skill_Description(false);
        Update_UI_Skill_Buttons();
        Update_UI_Skill_Buttons_SkillCtrl();
        OnScoreChange.Invoke();
    }









}
