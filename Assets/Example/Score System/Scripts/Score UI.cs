using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private ScoreSystemData scoreSystemData;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextPulse textPulse;

        private void Awake()
        {
            scoreText.text = 0.ToString();
        }

        public void UpdateText(int newScore)
        {
            scoreText.text = newScore.ToString();

            textPulse.ApplyEffect(scoreText);
        }
    }
}