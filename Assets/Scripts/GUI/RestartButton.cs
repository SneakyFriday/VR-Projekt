using UnityEngine;
public class RestartButton : MonoBehaviour
{

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.RestartGame();
    }
}
