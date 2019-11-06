using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    List<Achievement> achievements;
    
    public void RegisterEvent(AchievementType type) {
        foreach (var achievement in achievements.Where(a => a.Type == type && !a.Unlocked)) {
            achievement.AddProgress();
        }
    }

    private void LoadAchievementsFromDatabase() {

    }

    private void SaveAchievementsToDatabase() {

    }

    void Start()
    {
        LoadAchievementsFromDatabase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        SaveAchievementsToDatabase();
    }
}
