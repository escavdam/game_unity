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



    // Start is called before the first frame update
    void Start()
    {

    }

    public void Tiempo()
    {
        currentTime -= Time.deltaTime * velocity;
        Mathf.Clamp(currentTime, tiempoMinimo, tiempoMaximo);

        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        panelDeTiempo.GetComponentInChildren<Image>().fillAmount = currentTime;
    }


    // Update is called once per frame
    void Update()
    {
        Tiempo();
    }
}
