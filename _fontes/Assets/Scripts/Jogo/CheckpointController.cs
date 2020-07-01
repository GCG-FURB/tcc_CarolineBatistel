using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public FurbotLAB Furbot;
    public string caminho;
    public bool falar;
    public Checkpoint checkpoint;
    private UIManager _uiManager;

    private void Start()
    {
       _uiManager = GameObject.Find("CanvasInterface").GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (falar && collision.tag == "Player" && Furbot.ActiveCheckpoint != this.transform)
        {
            Executar();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            falar = true;
        }
    }

    public void Executar()
    {
        _uiManager.SalvarTexto();
        Furbot.CriarCheckpoint(this.checkpoint);
        StartCoroutine(_uiManager.Diga(Dialog_Char.S223, caminho));
        Furbot.ActiveCheckpoint = this.transform;
        falar = false;
        _uiManager.RecuperarTexto();
    }

}
