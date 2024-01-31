using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StatsEnemy : ScriptableObject
{
    public string Nombre;
    public int Edad;
    public string Generacion;
    public List<MemeType> weaknesses;
}
