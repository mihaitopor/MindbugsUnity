using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardBug : MonoBehaviour
{
    public Image bugImage;
    public Sprite[] wallpapers;

    // Start is called before the first frame update
    void Start()
    {
        int bugNumber = PlayerPrefs.GetInt("lastFoundBug", 0);
        bugImage.GetComponent<Image>().sprite = wallpapers[bugNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
