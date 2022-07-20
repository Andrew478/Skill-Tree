using UnityEngine;

public class Scores_Save : MonoBehaviour
{
    private void OnApplicationPause(bool pause)
    {
        if (pause) Scores.SaveScore();
    }
    private void OnApplicationQuit()
    {
        Scores.SaveScore();
    }
    private void OnDestroy()
    {
        Scores.SaveScore();
    }
}
