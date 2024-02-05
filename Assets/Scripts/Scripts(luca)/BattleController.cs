using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
	[SerializeField] private Image meme1;
	[SerializeField] private Image meme2;
	[SerializeField] private Image meme3;

	private Meme[] memes = new Meme[2];

	private readonly List<Meme> availableMemes = new List<Meme>();
	private readonly Queue<Meme> usedMemes = new Queue<Meme>();

	private void Start()
	{
		memes = Resources.LoadAll<Meme>("memes");
		RefillAvailableMemes();
		UpdateMemes();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			UpdateMemes();
		}
	}

	public void UpdateMemes()
	{
		// Check if availableMemes is less than 3, then refill
		if (availableMemes.Count < 3)
		{
			RefillAvailableMemes();
		}

		// Update the Image components with the selected memes
		meme1.sprite = GetRandomMeme().Sprite;
		meme2.sprite = GetRandomMeme().Sprite;
		meme3.sprite = GetRandomMeme().Sprite;
	}

	Meme GetRandomMeme()
	{
		if (availableMemes.Count < 3)
		{
			RefillAvailableMemes();
		}

		int randomIndex = Random.Range(0, availableMemes.Count);

		Meme randomMeme = availableMemes[randomIndex];
		availableMemes.RemoveAt(randomIndex);

		usedMemes.Enqueue(randomMeme);

		if (usedMemes.Count > 3)
		{
			Meme oldestMeme = usedMemes.Dequeue();
			availableMemes.Add(oldestMeme);
		}

		return randomMeme;
	}

	private void RefillAvailableMemes()
	{
		availableMemes.AddRange(memes);
		usedMemes.Clear();
	}
    void HandleEnemyClick(EnemyTypes enemyType)
    {
        Debug.Log("Clicked on enemy type: " + enemyType);
    }
}
