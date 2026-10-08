using Terresquall;
using UnityEngine;
using UnityEngine.UI;

public class Saves : PersistentObject
{
    [SerializeField] private int levelIndex;
    [SerializeField] private string previousLevelSaveID;
    [SerializeField] private Button levelButton;

    [SerializeField] private GameObject zeroStar;
    [SerializeField] private GameObject oneStar;
    [SerializeField] private GameObject twoStars;
    [SerializeField] private GameObject threeStars;

    public SaveData data = new SaveData();

    private void Awake()
    {
        Bench.LoadGame();

        bool isUnlocked = levelIndex == 1;

        if (!isUnlocked)
        {
            SaveData previousLevel = Bench.Find(previousLevelSaveID) as SaveData;

            if (previousLevel != null && previousLevel.stars > 0)
            {
                isUnlocked = true;
            }
        }

        levelButton.interactable = isUnlocked;

        SaveData starInfo = Bench.Find(saveID) as SaveData;

        if(starInfo != null)
        {
            if(starInfo.stars == 1)
            {
                oneStar.SetActive(true);
            }
            else if(starInfo.stars == 2)
            {
                twoStars.SetActive(true);
            }
            else if (starInfo.stars == 3)
            {
                threeStars.SetActive(true);
            }
            else
            {
                zeroStar.SetActive(true);
            }
        }
        else
        {
            zeroStar.SetActive(true);
        }
    }

    [System.Serializable]
    public new class SaveData : PersistentObject.SaveData
    {
        public int stars = 0;
        public int highScore = 0;
    }

    public override PersistentObject.SaveData Save()
    {
        return data;
    }

    public override bool Load(PersistentObject.SaveData data)
    {
        this.data = data as SaveData;
        return this.data != null;
    }
}
