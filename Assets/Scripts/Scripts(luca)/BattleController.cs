using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    StatsEnemy enemy;

    void Start()
    {
        GameEvents.StartCombat.AddListener(BattleStart);   
        
       
    }

    void BattleStart(StatsEnemy enemy)
    {
        this.enemy = enemy;
        SceneManager.LoadScene("UI-battle-Completo");
        
    }

    void MemeChosen()
    {

    }

}
//escucha cuando comienza el combate para almacenar el enimigo con el q pelea
//escucha cuando un meme es efectivo con el enemigo
//si es efectivo lanza un evento de si es efectivo y si no po otra cosa 