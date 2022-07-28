using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceImageDisplay : MonoBehaviour
{
    public Image essenceImage;
    public Text essenceValueTxt;

    // Start is called before the first frame update
    void Start()
    {
        essenceImage.enabled = false;
        essenceValueTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewEssenceButton()
    {
        StartCoroutine(viewEssence());
    }

    IEnumerator viewEssence()
    {
        essenceImage.enabled = true;
        essenceValueTxt.enabled = true;
        yield return new WaitForSeconds(3);
        essenceImage.enabled = false;
        essenceValueTxt.enabled = false;
    }
}
