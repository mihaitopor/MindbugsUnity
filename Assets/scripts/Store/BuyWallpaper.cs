using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyWallpaper : MonoBehaviour
{
    public Text wallpaperPriceTxt;

    private int[] wallpaperCost = {0, 10, 20, 30, 40, 50, 60 }; //aici se tine costul walpaper-urilor in functie de id-ul wallpaper-ului;


    // Start is called before the first frame update
    void Start()
    {
        int wallpaperID = PlayerPrefs.GetInt("lastFoundBug", 0);
        int cost = wallpaperCost[wallpaperID];
        wallpaperPriceTxt.text = "Buy wallpaper " + cost.ToString() + " essence";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyUpsellWallpaper()
    {
        int wallpaperID = PlayerPrefs.GetInt("lastFoundBug", 0);
        int cost = wallpaperCost[wallpaperID];
        int currentEssence = PlayerPrefs.GetInt("essenceValue", 0);
        if (cost < currentEssence)
        {
            int userHasWallpaper = PlayerPrefs.GetInt("Walpaper" + wallpaperID.ToString(), 0);
            Debug.Log(userHasWallpaper);
            if(userHasWallpaper == 0)
            {
                PlayerPrefs.SetInt("Walpaper" + wallpaperID.ToString(), 1);
                PlayerPrefs.SetInt("essenceValue", currentEssence - cost);
            }
            SceneManager.LoadScene("StoreScene");
        }
    }
}
