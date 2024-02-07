using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEnemyStats : MonoBehaviour
{
    public TMP_Text statsText;  // Asigna el objeto Text desde el Inspector
    public StatsEnemy enemyStats;  // Asigna la ScriptableObject desde el Inspector

    // Start is called before the first frame update
    void Start()
    {
        if (enemyStats != null)
        {
            // Accede a las estadísticas y muestra el texto en el objeto Text
            statsText.text = "Nombre: " + enemyStats.Nombre + "\n" +
                             "Edad: " + enemyStats.Edad.ToString() + "\n" +
                             "Generacion: " + enemyStats.Generacion + "\n" +
                             "Weaknesses: ";

            for (int i = 0; i < enemyStats.weaknesses.Count; i++)
            {
                statsText.text += enemyStats.weaknesses[i];
                if (i != enemyStats.weaknesses.Count - 1)
                    statsText.text += ", ";
            }
        }
        else
        {
            Debug.LogError("No se encontró el ScriptableObject statsenemy asignado.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
