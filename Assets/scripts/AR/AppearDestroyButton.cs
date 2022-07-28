using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearDestroyButton : MonoBehaviour
{
    public GameObject destroyBtn;

    // Start is called before the first frame update
    void Start()
    {
        destroyBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BugFound(int bugNumber)
    {
        destroyBtn.SetActive(true);
        PlayerPrefs.SetInt("lastFoundBug", bugNumber);
    }
}
