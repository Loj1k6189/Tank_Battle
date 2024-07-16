/*
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class S_SaveSystem
{
    #region PlayerPrefs
    public static void SaveByPlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(data, true);
        Debug.Log(json);

        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key, null);
    }
    #endregion

    #region Json
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        File.WriteAllText(path, json);

#if UNITY_EDITOR
        Debug.Log($"Successfully saved data to {path}.");
#endif
        try
        {

        }
        catch (System.Exception exception)
        {
#if UNITY_EDITOR
            Debug.LogError($"Fail To Save Data To {path}.\n{exception}");
#endif
        }
    }

        public static
    #endregion

}
*/




