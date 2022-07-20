using UnityEngine;
using UnityEngine.UI;



public class Scores_UI : MonoBehaviour
{
    [SerializeField]
    Text UIscoresText;
    public string scoreText = "Очки: "; 

    void Start()
    {
        UpdateUI_Scores();
    }

    public void AddScore(int val)
    {
        Scores.AddScore(val);
        UpdateUI_Scores();
    }
    public void RemoveScore(int val)
    {
        Scores.RemoveScore(val);
        UpdateUI_Scores();
    }

    public void UpdateUI_Scores()
    {
        UIscoresText.text = scoreText + Scores.Score.ToString();
    }
}
