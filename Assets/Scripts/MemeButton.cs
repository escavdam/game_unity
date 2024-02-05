using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeButton : MonoBehaviour
{
    [SerializeField] Meme meme;


    public void Chosen()
    {
        GameEvents.MemeChosen.Invoke(meme);
        print(meme);
    }
}
