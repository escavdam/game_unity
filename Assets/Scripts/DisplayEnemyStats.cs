using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEnemyStats : MonoBehaviour
{
    public TMP_Text statsText;  // Asigna el objeto Text desde el Inspector
    public statsenemy enemyStats;  // Asigna la ScriptableObject desde el Inspector

    // Start is called before the first frame update
    void Start()
    {
        if (enemyStats != null)
        {
            // Accede a las estadísticas y muestra el texto en el objeto Text
            statsText.text = "Nombre: " + enemyStats.Nombre + "\n" +
                             "Edad: " + enemyStats.Edad.ToString() + "\n" +
                             "Generacion: " + enemyStats.Generacion + "\n" +
                             "Debilidades: " + enemyStats.Debilidades + "\n" +
                             "Dislike: " + enemyStats.Dislike;
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
