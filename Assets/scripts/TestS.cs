using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TestS : MonoBehaviour
{
    private string liveHost = "https://eufacts.techwave.ro/";
    private string localHost = "http://localhost/eufacts4/";
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image img5;
    public Image img6;
    public Sprite noBug;
    public Sprite bug1;
    public Sprite bug2;
    public Sprite bug3;
    public Sprite bug4;
    public Sprite bug5;
    public Sprite bug6;



    // Start is called before the first frame update
    void Start()
    {
        updateCollectionView();
        /*StartCoroutine(GetUserBugs());*/
        //asta imi trebuie cand vreau sa iau din db
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool existBug(int bugNumber)
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
        return userBugs.IndexOf(bugNumber) != -1;
    }

    void updateCollectionView()
    {
        if (bug1 && existBug(1))
        {
            img1.GetComponent<Image>().sprite = bug1;
        }
        if (bug2 && existBug(2))
        {
            img2.GetComponent<Image>().sprite = bug2;
        }
        if (bug3 && existBug(3))
        {
            img3.GetComponent<Image>().sprite = bug3;
        }
        if (bug4 && existBug(4))
        {
            img4.GetComponent<Image>().sprite = bug4;
        }
        if (bug5 && existBug(5))
        {
            img5.GetComponent<Image>().sprite = bug5;
        }
        if (bug6 && existBug(6))
        {
            img6.GetComponent<Image>().sprite = bug6;
        }
    }

    IEnumerator GetUserBugs()
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", PlayerPrefs.GetString("userID"));
        using (WWW request = new WWW(localHost + "mindbugs/getUserBugs", form))
        {
            yield return request;
            string response = request.text;
            try
            {
                Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                
                
                if (result["success"] == "1")
                {
                    PlayerPrefs.SetString("userBugs", result["userBugs"]);
                }
                else
                {
                    Debug.Log(result["errorMessage"]);
                }
                updateCollectionView();
            }
            catch (Exception e)
            {
                updateCollectionView();
                Debug.Log(e.ToString());
            }
        }
    }
}



