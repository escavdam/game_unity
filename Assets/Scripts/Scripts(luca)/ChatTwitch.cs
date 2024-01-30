using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class ChatManager : MonoBehaviour
{
    public TextMeshProUGUI chatTextPrefab; // Prefab del texto del chat
    public Scrollbar scrollbar; // Barra de desplazamiento
    public RectTransform content; // Contenido del chat

    List<RectTransform> messageList = new List<RectTransform>(); // Lista de mensajes
    float messageHeight = 100f; // Altura de cada mensaje
    float verticalSpacing = 10f; // Espaciado vertical entre mensajes

    private bool isChatActive = false;

    private void Start()
    {
        // No inicia la generación de mensajes aleatorios automáticamente
    }

    public void StartChat()
    {
        isChatActive = true;
        StartCoroutine(GenerateRandomMessages());
    }

    IEnumerator GenerateRandomMessages()
    {
        while (isChatActive)
        {
            AddMessage(GetRandomChatMessage()); // Añade un mensaje aleatorio
            yield return new WaitForSeconds(Random.Range(1, 5)); // Espera un tiempo aleatorio
        }
    }

    void AddMessage(string message)
    {
        TextMeshProUGUI newMessage = Instantiate(chatTextPrefab, content); // Instancia un nuevo mensaje
        newMessage.text = message; // Asigna el texto al mensaje

        RectTransform newMessageRect = newMessage.GetComponent<RectTransform>(); // Obtiene el rectángulo del nuevo mensaje
        newMessageRect.anchoredPosition = new Vector2(newMessageRect.anchoredPosition.x, -content.sizeDelta.y / 2); // Ajusta la posición vertical del mensaje

        for (int i = 0; i < messageList.Count; i++)
            messageList[i].anchoredPosition = new Vector2(messageList[i].anchoredPosition.x, -content.sizeDelta.y / 2 + i * (messageHeight + verticalSpacing)); // Ajusta las posiciones verticales de los mensajes existentes

        messageList.Add(newMessageRect); // Añade el nuevo mensaje a la lista

        if (messageList.Count * (messageHeight + verticalSpacing) > content.sizeDelta.y)
        {
            RectTransform oldestMessage = messageList[0]; // Obtiene el mensaje más antiguo
            messageList.RemoveAt(0); // Elimina el mensaje más antiguo de la lista
            Destroy(oldestMessage.gameObject); // Destruye el objeto del mensaje más antiguo
        }

        scrollbar.value = 0; // Ajusta la posición de la barra de desplazamiento
    }

    string GetRandomChatMessage()
    {
        string[] chatMessages = {
            "¡Mensaje aleatorio!",
            "Lorem ipsum dolor sit amet...",
            "¿Alguien ha visto a mi gato?",
            "¡La respuesta es 42!",
            "¡Saludos desde Marte!",
            "Esa táctica fue inesperada.",
            "¡Cuidado con los agujeros de gusanos!",
            "¡Vamos equipo, ganaremos esta batalla!",
            "¡Gracias por el pescado!",
            "Mensaje en una botella virtual...",
            "¿Por qué el pollo cruzó la carretera?",
            "Error 404: Comentario no encontrado.",
            "Estoy siendo controlado por una IA...",
        };

        return chatMessages[Random.Range(0, chatMessages.Length)];
    }
}