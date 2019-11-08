using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Oracle.ManagedDataAccess.Client;
using System;

public class AchievementManager : MonoBehaviour
{
    event EventHandler<AchievementEventArgs> OnAchievementUnlocked;
    public List<Achievement> achievements { get; private set; }
    OracleConnection conn;
    string dsource = "Data Source=(DESCRIPTION="
                     + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)"
                     + "(HOST=mercure.clg.qc.ca)(PORT=1521)))"
                     + "(CONNECT_DATA=(SERVICE_NAME=orcl.clg.qc.ca)));"
                     + "User Id=tremblay;Password=oracle1";

    public void RegisterEvent(AchievementType type) {
        foreach (var achievement in achievements.Where(a => a.Type == type && !a.Unlocked)) {
            achievement.AddProgress();
            if (achievement.Unlocked)
                OnAchievementUnlocked?.Invoke(this, new AchievementEventArgs(achievement));
        }
    }

    private void LoadAchievementsFromDatabase() {
        if (conn.State == System.Data.ConnectionState.Closed)
            return;

        string sql = "SELECT Id, Nom, Description, UnlockDate, Progress, ProgressNeeded, Type FROM Succes";
        OracleCommand command = new OracleCommand(sql, conn);
        OracleDataReader reader = command.ExecuteReader();

        while (reader.Read()) {
            AchievementType Type;
            // On vérifie si le type est valide
            if (Enum.TryParse<AchievementType>(reader.GetString(6), out Type)) {
                int ProgressDone = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                DateTime? date = null;
                if (!reader.IsDBNull(3))
                    date = reader.GetDateTime(3);

                Achievement avc = new Achievement(
                    reader.GetInt32(0), // Id
                    reader.GetString(1), // Nom
                    reader.GetString(2), // Desc
                    reader.GetInt32(5), // ProgressNeeded
                    Type, // type
                    ProgressDone, // ProgressDone
                    date // Unlocked date
                );

                achievements.Add(avc);
            }
        }

        reader.Close();
    }

    public List<Achievement> GetUnlockedAchievements() {
        return achievements.Where(a => a.Unlocked).ToList();
    }

    private void SaveAchievementsToDatabase() {
        if (conn.State == System.Data.ConnectionState.Closed)
            return;

        Achievement[] acvToSave = achievements.Where(a => a.hasSomethingChanged).ToArray();
        string sql = "UPDATE Succes SET UnlockDate = :dat, Progress = :progress WHERE Id = :id";
        foreach (Achievement acv in acvToSave) {
            try
            {
                OracleParameter id = new OracleParameter(":id", OracleDbType.Int32);
                OracleParameter date = new OracleParameter(":dat", OracleDbType.Date);
                OracleParameter progress = new OracleParameter(":progress", OracleDbType.Int32);

                id.Value = acv.Id;
                date.Value = acv.WonDate;
                progress.Value = acv.Progress;

                OracleCommand command = new OracleCommand(sql, conn);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(date);
                command.Parameters.Add(progress);
                command.Parameters.Add(id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Debug.LogError(ex.Message);
            }
        }
    }

    void Start()
    {
        conn = new OracleConnection(dsource);
        try
        {
            conn.Open();
        } catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        Debug.Assert(conn.State != System.Data.ConnectionState.Closed);

        achievements = new List<Achievement>();

        LoadAchievementsFromDatabase();
    }

    private void OnApplicationQuit()
    {
        SaveAchievementsToDatabase();
        conn.Close();
    }
}
