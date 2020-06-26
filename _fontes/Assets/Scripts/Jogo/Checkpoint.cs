using UnityEngine;
[CreateAssetMenu(fileName ="Checkpoint", menuName ="Scriptable")]

public class Checkpoint : ScriptableObject
{
    public Vector3 posicao;
    public int vidas, energia;
    public string codigo;
}
