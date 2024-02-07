using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyVision : MonoBehaviour
{
    public StatsEnemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        //GameEvents.StartCombat.AddListener(EnemyInfo);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.StartCombat.Invoke(enemy);
            //collision.gameObject.GetComponent<MovimientoJugador>().AplicarGolpeEnemigo();
            SceneManager.LoadScene("UI-battle-Completo");
        }
    }
}
