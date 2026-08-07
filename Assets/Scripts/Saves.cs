using Terresquall;
using UnityEngine;

public class Saves : PersistentObject
{
    [SerializeField] private int levelIndex;
    [SerializeField] private GameObject zeroStar;
    [SerializeField] private GameObject oneStar;
    [SerializeField] private GameObject twoStars;
    [SerializeField] private GameObject threeStars;

    public int stars = 0;

    private void Awake()
    {
        PersistentObject.SaveData starInfo = Bench.Find(saveID);
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

    public override SaveData Save()
    {
        throw new System.NotImplementedException();
    }

    public override bool Load(SaveData data)
    {
        throw new System.NotImplementedException();
    }
}
