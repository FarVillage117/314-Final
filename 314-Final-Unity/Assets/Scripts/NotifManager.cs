using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class NotifManager : MonoBehaviour
{
    //"; is newline, unity editor was dumb and did not want to listen to \n"
    [SerializeField] string[] notificationString;
    [SerializeField] string[] buttonString;

    //Only change in editor, not during runtime
    [SerializeField] int taskNum = 0;

    TextMeshProUGUI[] tmpsUGUI;
    List<TextMeshProUGUI> notificationText = new List<TextMeshProUGUI> ();
    List<TextMeshProUGUI> buttonText = new List<TextMeshProUGUI>();

    bool usedWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        tmpsUGUI = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI textbox in tmpsUGUI)
        {
            if (textbox.CompareTag("UiTextNotification"))
            {
                notificationText.Add(textbox);
            }
            if (textbox.CompareTag("UiTextButton"))
            {
                buttonText.Add(textbox);
            }
        }

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
            ReloadScene();
        }

        foreach (TextMeshProUGUI textbox in notificationText)
        {
            textbox.text = notificationString[taskNum];
        }
        foreach (TextMeshProUGUI textbox in buttonText)
        {
            textbox.text = buttonString[taskNum];
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called whenever pannel button is pressed
    public void OnButtonPressed()
    {
        if (taskNum == 0)
        {
            MoveToNextTask();
        }
        else if (taskNum == 1 && usedWeapon)
        {
            MoveToNextTask();
        }
        else
        {
            MoveToNextTask();
        }
    }

    private void MoveToNextTask()
    {
        ++taskNum;
        notify();
    }

    public void InteractedWithWeapon(int type)
    {
        usedWeapon = true;
        Debug.Log($"Sword Interacted with type {type} interaction");
    }
}