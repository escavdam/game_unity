using UnityEngine;
using UnityEngine.UI;

public class YourScript : MonoBehaviour
{
    [SerializeField] GameObject RisometroEnemigo;

    void Start()
    {

        GameEvents.HurtPlayer.AddListener(OnPlayerHurt);


        GameEvents.HurtEnemy.AddListener(OnEnemyHurt);
    }

    void OnPlayerHurt( ) //meme equivocao
    {
        GetComponent<Image>().fillAmount += 0.2f;
    }

    void OnEnemyHurt()// meme acertao
    {
        GetComponent<Image>().fillAmount -= 0.2f;
    }
}
