using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Diagnostics;

public struct User_Grade
{
    public string ID;
    public int Time;
}

public class GradeBoard : MonoBehaviour
{

    [SerializeField] private Text IDBoard;
    [SerializeField] private Text TimeBoard;
    private const string FILE_NAME = "Labyrinth_Grade.txt";


    void Start()
    {
        if (!File.Exists(FILE_NAME))
        {
            return;
        }
        List<User_Grade> L = new List<User_Grade>();
        StreamReader sr = File.OpenText(FILE_NAME);
        String id;
        String temp;
        while ((id = sr.ReadLine()) != null && (temp = sr.ReadLine()) != null)
        {
            User_Grade UG = new User_Grade();
            int time;
            if (int.TryParse(temp, out time))
            {
                UG.ID = id;
                UG.Time = time;
                if (L.Count == 0)
                    L.Add(UG);
                else
                {
                    int i = 0;
                    if (L.Count == 1)
                    {
                        if (L[i].Time <= time)
                            L.Insert(i + 1, UG);
                        else
                            L.Insert(i, UG);
                    }
                    else
                    {
                        if (L[0].Time > time)
                            L.Insert(0, UG);
                        else
                        {
                            for (; i < L.Count; i++)
                            {
                                if (i == L.Count - 1 || (L[i].Time <= time && L[i + 1].Time > time))
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
                IDBoard.text = IDBoard.text + "No." + (j + 1) + "         ID: " + L[j].ID + "   \n";
                TimeBoard.text = TimeBoard.text + "Time: " + L[j].Time + " S \n";
            }
            SW.WriteLine(L[j].ID);
            SW.WriteLine(L[j].Time);
            SW.Flush();
            j++;
        }
        SW.Close();
    }

    void Update()
    {

    }
}
