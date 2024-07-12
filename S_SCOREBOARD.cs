using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public struct User_Score_Level1
{
    public string ID;
    public int Level1_Score;
}

public class S_SCOREBOARD : MonoBehaviour
{
    [SerializeField] private Text ScoreBoard;
    private const string FILE_NAME = "Single_Level1_Grade.txt";

    void Start()
    {
        if (!File.Exists(FILE_NAME))
        {
            return;
        }
        List<User_Score_Level1> L = new List<User_Score_Level1>();
        StreamReader sr = File.OpenText(FILE_NAME);
        String id;
        String temp;
        while ((id = sr.ReadLine()) != null && (temp = sr.ReadLine()) != null)
        {
            User_Score_Level1 UG = new User_Score_Level1();
            int score;
            if (int.TryParse(temp, out score))
            {
                UG.ID = id;
                UG.Level1_Score = score;
                if (L.Count == 0)
                    L.Add(UG);
                else
                {
                    int i = 0;
                    if (L.Count == 1)
                    {
                        if (L[i].Level1_Score >= score)
                            L.Insert(i + 1, UG);
                        else
                            L.Insert(i, UG);
                    }
                    else
                    {
                        if (L[0].Level1_Score < score)
                            L.Insert(0, UG);
                        else
                        {
                            for (; i < L.Count; i++)
                            {
                                if (i == L.Count - 1 || (L[i].Level1_Score >= score && L[i + 1].Level1_Score < score))
                                {
                                    L.Insert(i + 1, UG);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        sr.Close();
        FileStream FS = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
        FS.Close();
        int j = 0;
        StreamWriter SW = File.AppendText(FILE_NAME);
        while (j < L.Count)
        {
            if (j < 7)
            {
                ScoreBoard.text = ScoreBoard.text + "NO." + (j + 1) + "   ID : " + L[j].ID + "     Score : " + L[j].Level1_Score + "\n";
            }
            SW.WriteLine(L[j].ID);
            SW.WriteLine(L[j].Level1_Score);
            SW.Flush();
            j++;
        }
        SW.Close();
    }
}
