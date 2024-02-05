using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTimer : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] int tiempoMaximo = 1;
    [SerializeField] int tiempoMinimo = 0;

    [SerializeField] GameObject panelDeTiempo;



    // Start is called before the first frame update
    void Start()
    {
        Mathf.Clamp(currentTime, tiempoMinimo, tiempoMaximo);

    }

    public void Tiempo()
    {
        currentTime -= Time.deltaTime;
        Mathf.Clamp(currentTime, tiempoMinimo, tiempoMaximo);



    }

    void UpdateTimeDisplay()
    {
        panelDeTiempo.GetComponentInChildren<Image>().fillAmount = currentTime += Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateTimeDisplay();
    }
}
