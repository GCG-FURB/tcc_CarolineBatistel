using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipalOffline : MonoBehaviour
{

    //Objetos
    public Button btnIniciar, btnSair, gerador;

    void Start()
    {
#if !UNITY_WEBGL
        btnSair.onClick.AddListener(delegate { Sair(); });
#else
        btnSair.gameObject.SetActive(false);
#endif
        btnIniciar.onClick.AddListener(delegate { Iniciar(); });
       
        gerador.onClick.AddListener(delegate { SceneManager.LoadScene("GeradorDeFases"); });
    }

    /// <summary>
    /// Este método carrega a cena de seleção de fases.
    /// </summary>
    private void Iniciar()
    {
        //#if UNITY_STANDALONE
        //SceneManager.LoadScene("Historia");
        //#else 
        SceneManager.LoadScene("TutorialProjecao");
        //#endif
    }

    /// <summary>
    /// Este método finaliza a execução do jogo.
    /// </summary>
    private void Sair()
    {
        Application.Quit();
    }
}
