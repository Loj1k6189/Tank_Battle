using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_LogIn : MonoBehaviour
{
    public InputField UserName;
    public void OnButtonClick()
    {
        string username = UserName.text;

        PlayerPrefs.SetString("username", username);
        PlayerPrefs.Save();
    }
}