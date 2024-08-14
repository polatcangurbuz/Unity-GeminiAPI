using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using TMPro;
using UnityEngine.UI;

public class DontSprayIt : MonoBehaviour
{
    SpVoice voice = new SpVoice();
 
    [SerializeField] TMP_InputField InputField;
    bool control = false;
   
    void Update()
    {
       if(control)
        {
            voice.Speak(InputField.text, SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
            control = false;
        }
           
            
    }
    public void inputfieldchange(string value)
    {
        control = true;
        
    }
   
}
