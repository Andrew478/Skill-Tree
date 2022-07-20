using UnityEngine;

public static class Scores
{
    static int score = 0; // player free scores count
    public static int Score { get { return score; } }

    const string KEY_PLAYERSCORE = "PLAYERSCORE";
    public static void AddScore(int val)
    {
        score += val;
    }
    public static void RemoveScore(int val)
    {
        score -= val;
        if (score < 0) score = 0;
    }
    public static bool HasEnoughScores(int val)
    {
        return (score >= val) ? true : false;
    }
    public static void SaveScore()
    {
        string s = JsonUtility.ToJson(score);
        PlayerPrefs.SetString(KEY_PLAYERSCORE, s);
        PlayerPrefs.Save();
    }
    public static void LoadScore()
    {
        bool hasData = PlayerPrefs.HasKey(KEY_PLAYERSCORE);
        if (hasData)
        {
            string s = PlayerPrefs.GetString(KEY_PLAYERSCORE);
            score = JsonUtility.FromJson<int>(s);
        }
        else
        {
            score = 0;
        }
    }
}
