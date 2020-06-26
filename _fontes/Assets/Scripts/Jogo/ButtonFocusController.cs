using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Crosstales.RTVoice;
using UnityEngine.UI;
public class ButtonFocusController : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string TextoBotao;
    private bool textSpeaked;

    private void Speak()
    {
        if (!textSpeaked)
        {
            Crosstales.RTVoice.Model.Voice voice = Speaker.Voices[0];
            if (Speaker.areVoicesReady && Speaker.isTTSAvailable)
            {
                voice = Speaker.VoiceForCulture("pt-br");
            }
            Speaker.Speak(TextoBotao, null, voice);
            textSpeaked = true;
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        textSpeaked = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(EventSystem.current.currentSelectedGameObject != gameObject)
        {
            textSpeaked = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Speak();
    }

    public void OnSelect(BaseEventData eventData)
    {
        Speak();
    }

    // Start is called before the first frame update
    void Start()
    {
        textSpeaked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
