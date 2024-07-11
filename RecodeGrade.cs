using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Diagnostics;

public class RecodeGrade : MonoBehaviour
{

    private const string FILE_NAME = "Labyrinth_Grade.txt";
    private string ID = "FOUNDSJJ";
    Stopwatch sw = new Stopwatch();

    [SerializeField] private Text TimeBoard;
    [SerializeField] private Text IDBoard;

    void Start()
    {
        sw.Start();
        IDBoard.text = "ID : " + ID;
    }

    void Update()
    {
        TimeBoard.text = "Time : " + ((int)sw.ElapsedMilliseconds / 1000) + "s";
    }

    void TakeGrade()
    {
        sw.Stop();
        int Time = (int)sw.ElapsedMilliseconds / 1000;
        if (!File.Exists(FILE_NAME))
        {
            FileStream fs = new FileStream(FILE_NAME, FileMode.Create);
            fs.Close();
        }
        StreamWriter SW = File.AppendText(FILE_NAME);
        SW.WriteLine(ID);
        SW.WriteLine(Time);
        SW.Flush();
        SW.Close();
    }
}
