using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject testPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //collision.gameObject.GetComponent<MovimientoJugador>().AplicarGolpeEnemigo(collision.GetContact(0).point);
                //collision.gameObject.GetComponent<MovimientoJugador>().AplicarGolpeEnemigo();

                testPanel.SetActive(true);

            }
        }
}
