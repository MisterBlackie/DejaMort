using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum AchievementType {
    Jump,
    Attack,
    Die,
}

[System.Serializable]
public class Achievement
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Progress { get; private set; }
    public int ProgressNeeded { get; private set; }
    public int ProgressLeft => !Unlocked ? ProgressNeeded - Progress : 0;
    public DateTime? WonDate { get; private set; }
    public AchievementType Type { get; private set; }
    public bool Unlocked => Progress >= ProgressNeeded;

    public void AddProgress() {
        if (Unlocked)
            return;

        Progress++;
        if (Unlocked)
            onUnlock?.Invoke(this, new AchievementEventArgs(this));
    }

    event EventHandler<AchievementEventArgs> onUnlock;

    public Achievement(string name, string description, int progressNeeded, AchievementType type, int progressDone = 0, DateTime? dateWon = null) {
        Name = name;
        Description = description;
        ProgressNeeded = progressNeeded;
        Progress = progressDone;
        WonDate = dateWon;
        Type = type;
    }
}

public class AchievementEventArgs {
    public Achievement achievement { get; set; }

    public AchievementEventArgs(Achievement acv)
    {
        achievement = acv;
    }
}