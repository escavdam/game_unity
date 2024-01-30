using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject instruccionesPanel;


    void Start()
    {
        instruccionesPanel.SetActive(true);
    }
    public void HideInstructions()
    {
        instruccionesPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScene("SampleScene");
        }
    }

    void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}