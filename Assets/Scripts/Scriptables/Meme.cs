using UnityEngine;

[CreateAssetMenu(fileName = "newMeme", menuName = "Dam/Meme")]
public class Meme : ScriptableObject
{
	[SerializeField] private EnemyTypes affects = EnemyTypes.None;
	[SerializeField] private EnemyTypes ineffective = EnemyTypes.None;
	[Space]
	[SerializeField] private Sprite sprite;
	public Sprite Sprite => sprite;
}