using UnityEngine;

public class Scores_Init : MonoBehaviour
{
    void Awake()
    {
        Scores.LoadScore(); // Initialize score on game start
    }
}
