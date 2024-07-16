using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogsystem : MonoBehaviour
{
    public GameObject DialogUI; //�Ի�Panel
    public Text DialogText; //Panel���Ӽ�Text
    [TextArea(1, 3)] public string[] DialogTextList; //��ŶԻ����� ǰ���������Ϊ����Inspector����������������ʾ������
    public int currentIndex;//�Ի���������
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseDialog() //���Closeִ�У��رնԻ�Panel
    {
        DialogUI.SetActive(false);
    }

    public void ContinueDialog()    //���Continue��ťִ�У������¾仰
    {
        currentIndex++;
        if (currentIndex < DialogTextList.Length)
        {
            DialogText.text = DialogTextList[currentIndex];
        }
        else
        {
            CloseDialog();
        }
    }

    private void OnEnable() //�ڼ���Ի���尴ťʱ������Ŀ����Ϊ��ʹ������0
    {
        currentIndex = 0;
        DialogText.text = DialogTextList[currentIndex];
    }
}
