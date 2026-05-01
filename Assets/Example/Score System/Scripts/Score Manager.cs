using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScoreSystem
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private ScoreSystemData scoreSystemData;
        [SerializeField] private ScoreUI scoreUI;

        private int currentScore;

        public void AddScore(int addedScore)
        {
            currentScore += addedScore;

            scoreUI.UpdateText(currentScore);

            if (currentScore >= scoreSystemData.scoreToWin)
                SceneManager.LoadScene("Victory Screen");
        }
    }
}