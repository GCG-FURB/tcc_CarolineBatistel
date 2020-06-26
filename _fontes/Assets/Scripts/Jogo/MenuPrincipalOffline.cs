using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipalOffline : MonoBehaviour
{

    //Objetos
    public Button btnIniciar, btnSair, btnLab, gerador, btnConfiguracao, btnFocusedOnStart;

    void Start()
    {
#if !UNITY_WEBGL
        btnSair.onClick.AddListener(delegate { Sair(); });
#else
        btnSair.gameObject.SetActive(false);
#endif
        btnIniciar.onClick.AddListener(delegate { CarregarPrefs(false); });
        btnLab.onClick.AddListener(delegate { CarregarPrefs(true); });
        gerador.onClick.AddListener(delegate { SceneManager.LoadScene("GeradorDeFases"); });
        btnConfiguracao.onClick.AddListener(delegate { VoicePrefsManager.toMenu = true; SceneManager.LoadScene("VoicePrefs"); });
        btnFocusedOnStart.Select();
    }

    private void CarregarPrefs(bool isLab)
    {
        LabManager.IsLab = isLab;
        VoicePrefsManager.toMenu = false;
        if (PlayerPrefs.GetInt("Setado") == 0)
        {
            SceneManager.LoadScene("VoicePrefs");
        }
        else
        {
            SceneManager.LoadScene("TutorialProjecao");
        }
    }

    /// <summary>
    /// Este método finaliza a execução do jogo.
    /// </summary>
    private void Sair()
    {
        Application.Quit();
    }
}
