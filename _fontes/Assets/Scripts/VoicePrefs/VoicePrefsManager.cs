using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Crosstales.RTVoice;
using UnityEngine.SceneManagement;

public class VoicePrefsManager : MonoBehaviour
{
    public Dropdown voicesConteiner;
    public Slider pitchSlider;
    public Slider rateSlider;

    public static bool toMenu;
    // Start is called before the first frame update
    void Start()
    {
        LoadVoices();
        if(PlayerPrefs.GetInt("Setado") == 1)
        {
            pitchSlider.value = PlayerPrefs.GetFloat("Pitch");
            rateSlider.value = PlayerPrefs.GetFloat("Rate");
            for(int i = 0; i < voicesConteiner.options.Count -1; i++)
            {
                if(voicesConteiner.options[i].text == PlayerPrefs.GetString("VoiceName"))
                {
                    voicesConteiner.value = i;
                }
            }
        }
    }

    void LoadVoices()
    {
        voicesConteiner.ClearOptions();
        if(Speaker.isTTSAvailable && Speaker.areVoicesReady && voicesConteiner != null)
        {
            foreach (Crosstales.RTVoice.Model.Voice v in Speaker.Voices)
            {
                Dropdown.OptionData data = new Dropdown.OptionData();
                data.text = v.Name;
                voicesConteiner.options.Add(data);          
            }
        }
        else if(voicesConteiner == null)
        {
            throw new System.Exception("Conteiner de vozes null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VoiceChange()
    {
        string voice = voicesConteiner.options[voicesConteiner.value].text;
        Speaker.Speak("Testando voz "+voice+" com parâmetros informados", 
                      null, Speaker.VoiceForName(voice),true,rateSlider.value,pitchSlider.value);
    }

    public void SalvarPrefs()
    {
        PlayerPrefs.SetString("VoiceName", voicesConteiner.options[voicesConteiner.value].text);
        PlayerPrefs.SetFloat("Pitch", pitchSlider.value);
        PlayerPrefs.SetFloat("Rate", rateSlider.value);
        PlayerPrefs.SetInt("Setado", 1);
        PlayerPrefs.Save();
        if(toMenu)
        {
            SceneManager.LoadScene("MenuPrincipal");
        } else
        {
            SceneManager.LoadScene("TutorialProjecao");
        }
    }
}
