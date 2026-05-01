using Coin;
using ScoreSystem;
using UnityEngine;

public class CoinScoreGlue : MonoBehaviour
{
    //Esse script funciona como a cola que junta as duas seções Coin e Score System

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();

        //Se inscreve no evento C# da moeda, chamando a função de adicionar pontuação sempre que o evento é invocado
        CoinBehaviour.CoinCollectedEvent += scoreManager.AddScore;
    }

    //SEMPRE, SEMPRE remover a inscrição no evento
    private void OnDisable()
    {
        if (scoreManager != null)
            CoinBehaviour.CoinCollectedEvent -= scoreManager.AddScore;
    }
}