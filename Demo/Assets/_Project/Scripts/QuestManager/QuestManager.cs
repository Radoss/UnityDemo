using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    #region Singleton
    public static QuestManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }
    #endregion

    [SerializeField] string[] conditions;
    public Dictionary<string, bool> goalReachedMap;

    private void Start()
    {
        goalReachedMap = new Dictionary<string, bool>();
        foreach (string condition in conditions)
        {
            goalReachedMap.Add(condition, false);
        }
    }

}
