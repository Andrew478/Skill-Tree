using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Skill_UI_Unit : MonoBehaviour
{
    [Header("Id умения, которое отображает этот элемент")]
    public int id;
    Text SkillName;
    Button buttonSelectThisSkillAsAsctive;
    Skill_UI skill_UI;
    Color32 lockedColor = new Color32(190, 190, 190, 255);
    Color32 unlockedColor = new Color32(21, 179, 120, 255);
    Color buttonColor;

    void Start()
    {
        SkillName = gameObject.transform.GetChild(0).GetComponent<Text>();
        buttonSelectThisSkillAsAsctive = gameObject.GetComponent<Button>();
        buttonSelectThisSkillAsAsctive.onClick.AddListener(SelectThisSkillAsActive);
        skill_UI = GameObject.FindObjectOfType<Skill_UI>();
        buttonColor = gameObject.GetComponent<Image>().color;
        DisplayInfo();
    }

    public void DisplayInfo()
    {
        SkillName.text = SkillManager.GetSkillUnitById(id).name;
        SetColorOfButton(SkillManager.GetSkillUnitById(id).isLearned ? unlockedColor : lockedColor);
    }
    public void SelectThisSkillAsActive()
    {
        SkillManager.SetSkillUnitAsActive(id);
        skill_UI.Update_UI_Skill_Description(false);
        skill_UI.CurrentSelectedButtonScript = this;
        skill_UI.Update_UI_Skill_Buttons_SkillCtrl();
        DisplayInfo();
    }
    void SetColorOfButton(Color32 color)
    {
        buttonColor = color;
        gameObject.GetComponent<Image>().color = buttonColor;
    }
}
