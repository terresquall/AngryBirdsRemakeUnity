using Terresquall;

public class LevelSave : PersistentObject
{
    public static LevelSave Instance { get; private set; }
    public int levelComplete = 0;

    private void Awake()
    {
        Bench.LoadGame();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public new class SaveData : PersistentObject.SaveData
    {
        public int levelCompleted;
    }

    public override PersistentObject.SaveData Save()
    {
        if (CanSave())
        {
            return new SaveData
            {
                saveID = saveID,

                levelCompleted = levelComplete
            };
        }
        return null;
    }

    public override bool Load(PersistentObject.SaveData data)
    {
        if (data == null) return false;

        if (data is SaveData localData)
        {
            levelComplete = localData.levelCompleted;
            return true;
        }

        return false;
    }
}