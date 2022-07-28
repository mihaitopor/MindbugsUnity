using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    private string liveHost = "https://eufacts.techwave.ro/";
    private string localHost = "http://localhost/eufacts4/";

    public InputField usernameField;
    public InputField passwordField;

    public Button loginBtn;

    public Text UsernameTxt;

    public void Start()
    {
        if (!String.IsNullOrEmpty(PlayerPrefs.GetString("userName")))
        {
            UsernameTxt.text = "You are connected as: " + PlayerPrefs.GetString("userName") + "\n With email: " + PlayerPrefs.GetString("userEmail");
        }
    }
    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);
        using (WWW request = new WWW(liveHost + "mindbugs/userExists", form))
        {
            yield return request;
            string response = request.text;
            try
            {
                Dictionary<string, string> user = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                if(user["success"] == "1")
                {
                    PlayerPrefs.SetString("userID", user["user_id"]);
                    PlayerPrefs.SetString("userName", user["name"]);
                    PlayerPrefs.SetString("userEmail", user["email"]);
                    UsernameTxt.text = "You are connected as: " + user["name"] + "\n With email: " + user["email"];
                }
                else
                {
                    Debug.Log(user["errorMessage"]);
                }
            
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
        }
        
        /*if(www.text[0] == '0')
        {
            Debug.Log("Success!");
        }
        else
        {
            Debug.Log("User login failed!. Error #" + www.text);
        }*/
    }
}
