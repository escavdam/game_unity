using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{
    public class MemeEvent : UnityEvent<Meme> { };
<<<<<<< HEAD
    public class EnemyEvent: UnityEvent<StatsEnemy> { };

    public static MemeEvent MemeChosen = new MemeEvent();
   /* public static EnemyEvent EnemyStats = new EnemyEvent();*/

    public static EnemyEvent HurtPlayer = new EnemyEvent();
    public static EnemyEvent HurtEnemy = new EnemyEvent();



}
=======
    public class EnemyEvent : UnityEvent<StatsEnemy> { };

    public static MemeEvent MemeChosen = new MemeEvent();
    /* public static EnemyEvent EnemyStats = new EnemyEvent();*/

    public static UnityEvent HurtPlayer = new UnityEvent();
    public static UnityEvent HurtEnemy = new UnityEvent();



}
>>>>>>> alvaro
