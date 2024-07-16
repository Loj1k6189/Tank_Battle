using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogsystem : MonoBehaviour
{
    public GameObject DialogUI; //对话Panel
    public Text DialogText; //Panel的子级Text
    [TextArea(1, 3)] public string[] DialogTextList; //存放对话内容 前面的特性是为了在Inspector窗口中文字区域显示成三行
    public int currentIndex;//对话数组索引
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseDialog() //点击Close执行；关闭对话Panel
    {
        DialogUI.SetActive(false);
    }

    public void ContinueDialog()    //点击Continue按钮执行；继续下句话
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

    private void OnEnable() //在激活对话面板按钮时触发，目的是为了使索引归0
    {
        currentIndex = 0;
        DialogText.text = DialogTextList[currentIndex];
    }
}
