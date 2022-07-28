using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("You have exit the APP!");
    }

    public void addBugToCollection(string scene)
    {
        string[] userBugsPrefs = PlayerPrefs.GetString("userBugs", "").Split(',');
        List<int> userBugs = new List<int>();

        foreach (string userBug in userBugsPrefs)
        {
            try
            {
                int valueAsInt = Int32.Parse(userBug);
                userBugs.Add(valueAsInt);
            }
            catch { }
        }

        int bugNumber = PlayerPrefs.GetInt("lastFoundBug", 0);
        userBugs.Add(bugNumber);
        userBugs.Distinct().ToList();

        string newUserBugString = String.Join(',', userBugs);
        PlayerPrefs.SetString("userBugs", newUserBugString);

        SceneManager.LoadScene(scene);
    }
}
