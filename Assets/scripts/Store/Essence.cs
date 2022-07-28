using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Essence : MonoBehaviour
{ 
    public Text essenceValueTxt;

    // Start is called before the first frame update
    void Start()
    {
        int currentEssence = PlayerPrefs.GetInt("essenceValue", 0);
        essenceValueTxt.text = currentEssence.ToString() + " Essence";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addEssence(int essenceValue)
    {
        int currentEssence = PlayerPrefs.GetInt("essenceValue", 0);
        essenceValue += currentEssence;
        PlayerPrefs.SetInt("essenceValue", essenceValue);
        essenceValueTxt.text = essenceValue.ToString() + " Essence";
    }
}
