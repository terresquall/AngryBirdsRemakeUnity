using Terresquall;
using UnityEngine;

public class Saves : PersistentObject
{
    [SerializeField] private int levelIndex;
    [SerializeField] private GameObject zeroStar;
    [SerializeField] private GameObject oneStar;
    [SerializeField] private GameObject twoStars;
    [SerializeField] private GameObject threeStars;

    public SaveData data;

    private void Awake()
    {
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
