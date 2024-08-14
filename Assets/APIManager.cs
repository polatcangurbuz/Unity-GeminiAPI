using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    [SerializeField] private string gasURL;
     private string prompt;
     string response;
    [SerializeField] TMP_InputField inputField;
     bool controlButton = false;
    private void Update()
    {
        if (controlButton)
        {
            StartCoroutine(SendDataToGAS());
            controlButton = false;
        }
    }

    private IEnumerator SendDataToGAS()
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", prompt);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);

        yield return www.SendWebRequest();
         response = "";

        if(www.result == UnityWebRequest.Result.Success)
        {
            response = www.downloadHandler.text;
        }
        else
        {
            response = "Hata";
        }
        
        inputField.text = response;
        Debug.Log(response);
    }

    public void promptInput(string value)
    {
        prompt = value;
    }

    public void butonControl()
    {
        controlButton = true;
    }



}
