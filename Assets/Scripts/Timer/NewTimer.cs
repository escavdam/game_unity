using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTimer : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] float velocity;
    [SerializeField] float tiempoMaximo = 1;
    [SerializeField] int tiempoMinimo = 0;

    [SerializeField] GameObject panelDeTiempo;

    bool isTimerRunning = false;
    //bool wasAttacked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void Tiempo()
    {
        currentTime -= Time.deltaTime * velocity;

        if (currentTime <= tiempoMinimo)
        {
            currentTime = 0;
            isTimerRunning = false;
            print("Se acabo el tiempo");
        }

        currentTime = Mathf.Clamp(currentTime, tiempoMinimo, tiempoMaximo);
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        panelDeTiempo.GetComponentInChildren<Image>().fillAmount = currentTime;
    }

    //Funcion para que cuando pulses el meme adecuado sume más risa al risómetro
    /*
    public void StartAttack()
    {
        wasAttacked = true;
    }

    void UpTimeInAttack()
    {
        currentTime += 0.2f;
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            Tiempo();
        }

        /*
        if (wasAttacked)
        {
            UpTimeInAttack();
        }
        */
    }
}
