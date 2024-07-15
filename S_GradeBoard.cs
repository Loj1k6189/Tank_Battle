using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class S_GradeBoard : MonoBehaviour
{
    private const string FILE_NAME = "Single_Level1_Grade.txt";
    private string ID;

    [SerializeField] private Text ScoreBoard;
    [SerializeField] private Text IDBoard;


    void Start()
    {
        ID = PlayerPrefs.GetString("username", "111");
        IDBoard.text = "ID : " + ID;
    }

    void Update()
    {

    }

    void RecordScore(int Score)
    {
        if (!File.Exists(FILE_NAME))
        {
            FileStream fs = new FileStream(FILE_NAME, FileMode.Create);
            fs.Close();
        }
        StreamWriter SW = File.AppendText(FILE_NAME);
        SW.WriteLine(ID);
        SW.WriteLine(Score);
        SW.Flush();
        SW.Close();
    }
}