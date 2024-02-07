using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{
    public class MemeEvent : UnityEvent<Meme> { };
    public class EnemyEvent : UnityEvent<StatsEnemy> { };

    public static MemeEvent MemeChosen = new MemeEvent();
    /* public static EnemyEvent EnemyStats = new EnemyEvent();*/

    public static UnityEvent HurtPlayer = new UnityEvent();
    public static UnityEvent HurtEnemy = new UnityEvent();



}
