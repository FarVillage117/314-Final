using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotifManager : MonoBehaviour
{
    //"; is newline, unity editor was dumb and did not want to listen to \n"
    [SerializeField] string[] notificationString;
    [SerializeField] string[] buttonString;

    //Only change in editor, not during runtime
    [SerializeField] int taskNum = 0;

    [SerializeField] TextMeshProUGUI notificationText;
    [SerializeField] TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < notificationString.Length; i++)
        {
            notificationString[i] = notificationString[i].Replace(";", "\n");
        }
        for (int i = 0; i < buttonString.Length; i++)
        {
            notificationString[i] = notificationString[i].Replace(";", "\n");
        }
        notify();
    }

    //Updates text on pannel
    private void notify()
    {
        if (taskNum >= notificationString.Length || taskNum >= buttonString.Length)
        {
            taskNum = 0;
        }
        notificationText.text = notificationString[taskNum];
        buttonText.text = buttonString[taskNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called whenever pannel button is pressed
    public void OnButtonPressed()
    {
        ++taskNum;
        notify();
    }

    public void SwordGrabbed()
    {
        Debug.Log("Sword Grabbed");
    }

    public void SwordReleased()
    {
        Debug.Log("Sword Released");
    }
}
