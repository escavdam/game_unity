using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    [SerializeField] int tiempoMaximo = 20; // Tiempo máximo en segundos
    float tiempoRestante = 20f;
    [HideInInspector] public bool gameOver = false;
    [SerializeField] Image tiempoIndicator;

    bool timerStarted = false; // Variable para controlar si el temporizador ya ha comenzado

    void Start()
    {
        tiempoRestante = tiempoMaximo;
        UpdateTiempoIndicator();
    }

    void Update()
    {
        // Verifica si el temporizador se ha iniciado y si ha llegado a cero
        if (timerStarted && tiempoRestante <= 0)
        {
            // Aquí puedes agregar acciones adicionales cuando el tiempo se agota
            gameOver = true;
            Debug.Log("¡Tiempo agotado!");
            timerStarted = false; // Detiene el temporizador
        }
    }

    void UpdateTiempoIndicator()
    {
        // Calcula la escala en base al tiempo restante y el tiempo máximo
        float escala = Mathf.Clamp(tiempoRestante, 0f, 1f);

        // Aplica la escala suavizada a la imagen
        tiempoIndicator.rectTransform.localScale = new Vector3(escala, 1f, 1f);
    }

    IEnumerator ReducirTiempoConTiempo()
    {
        while (tiempoRestante > 0)
        {
            // Actualiza el tiempo restante
            tiempoRestante -= Time.time;

            // Actualiza el indicador de tiempo
            UpdateTiempoIndicator();

            yield return null;
        }
    }

    // Función llamada cuando se presiona el botón para iniciar el temporizador
    public void StartTimer()
    {
        if (!timerStarted)
        {
            StartCoroutine(ReducirTiempoConTiempo());
            timerStarted = true;
        }
    }
}
