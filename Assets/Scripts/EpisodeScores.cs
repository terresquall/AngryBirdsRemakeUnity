using UnityEngine;
using TMPro;
using Terresquall;
using UnityEditor.Overlays;

public class EpisodeScores : MonoBehaviour
{
    [SerializeField] GameObject episodeLevels;

    [SerializeField] TextMeshProUGUI maxStarText;

    [SerializeField] TextMeshProUGUI totalStarText;

    [SerializeField] TextMeshProUGUI totalScoreText;

    [SerializeField] string[] levelSaveID;

    [HideInInspector]
    public int levelsCount;
    [HideInInspector]
    public int totalStarCount;
    [HideInInspector]
    public int totalMaxStarCount;
    [HideInInspector]
    public int totalScoreCount;



    private void Start()
    {
        levelsCount = levelSaveID.Length;
        totalMaxStarCount = levelsCount * 3;

        // Retrieves each level's saved data and adds up the total stars earned and high scores
        for (int i = 0; i < levelSaveID.Length; i++)
        {
            Saves.SaveData starInfo = Bench.Find(levelSaveID[i]) as Saves.SaveData;

            if (starInfo != null)
            {
                totalStarCount += starInfo.stars;
                totalScoreCount += starInfo.highScore;
            }
        }

        maxStarText.text = totalMaxStarCount.ToString();
        totalStarText.text = totalStarCount.ToString();
        totalScoreText.text = totalScoreCount.ToString();
    }
}