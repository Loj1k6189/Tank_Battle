/*
using UnityEngine;

namespace SaveSystemTutorial
{
    public class S_PlayerData : MonoBehaviour
    {
        #region Fields

        [SerializeField] int level = 0;
        [SerializeField] int score = 0;

        [System.Serializable]class SaveData
        {
            public int playerLevel;
            public int playerScore;
        }

        #endregion

        #region Properties

        public int Level => level;
        public int Score => score;

        public Vector3 Position => transform.position;

        #endregion

        #region Save and Load

        public void Save()
        {
            SavedByPlayerPrefs();
        }

        public void Load()
        {
            LoadFromPlayerPrefs();
        }

        #endregion

        #region PlayerPrefs
        void SavedByPlayerPrefs()
        {
            var saveData = new SaveData();
            saveData.playerLevel = level;
            saveData.playerScore = score;

            SaveSystem.SaveByPlayerPrefs("PlayerData",saveData);
        }

        void LoadFromPlayerPrefs()
        {
            var json = SaveSystem.LoadFromPlayerPrefs("PlayerData");
            var saveData = JsonUtility.FromJson<SaveData>(json);

            level= saveData.playerLevel;
            score= saveData.playerScore;
        }

        [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
        public static void DeletePlayerDataPrefs()
        {
            PlayerPrefs.DeleteAll();
        }

        #endregion
    }
}
*/