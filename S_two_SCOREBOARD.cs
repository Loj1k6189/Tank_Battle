using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public struct User_Score_Level2
{
    public string ID;
    public int Level2_Score;
}

public class S_two_SCOREBOARD : MonoBehaviour
{
    [SerializeField] private Text ScoreBoard;
    private const string FILE_NAME = "Single_Level2_Grade.txt";

    void Start()
    {
        if (!File.Exists(FILE_NAME))
        {
            return;
        }
        List<User_Score_Level2> L = new List<User_Score_Level2>();
        StreamReader sr = File.OpenText(FILE_NAME);
        String id;
        String temp;
        while ((id = sr.ReadLine()) != null && (temp = sr.ReadLine()) != null)
        {
            User_Score_Level2 UG = new User_Score_Level2();
            int score;
            if (int.TryParse(temp, out score))
            {
                UG.ID = id;
                UG.Level2_Score = score;
                if (L.Count == 0)
                    L.Add(UG);
                else
                {
                    int i = 0;
                    if (L.Count == 1)
                    {
                        if (L[i].Level2_Score >= score)
                            L.Insert(i + 1, UG);
                        else
                            L.Insert(i, UG);
                    }
                    else
                    {
                        if (L[0].Level2_Score < score)
                            L.Insert(0, UG);
                        else
                        {
                            for (; i < L.Count; i++)
                            {
                                if (i == L.Count - 1 || (L[i].Level2_Score >= score && L[i + 1].Level2_Score < score))
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
                ScoreBoard.text = ScoreBoard.text + "NO." + (j + 1) + "   ID : " + L[j].ID + "     Score : " + L[j].Level2_Score + "\n";
            }
            SW.WriteLine(L[j].ID);
            SW.WriteLine(L[j].Level2_Score);
            SW.Flush();
            j++;
        }
        SW.Close();
    }
}
