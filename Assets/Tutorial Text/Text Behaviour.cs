using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TutorialText
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TextBehaviour : MonoBehaviour
    {
        [SerializeField] private TutorialTextData tutorialTextData;

        [SerializeField] private SpriteRenderer[] icons;
        [SerializeField] private TextMeshProUGUI text;
        public bool isPermanent;

        private RectTransform textTransform;
        private BoxCollider2D boxCollider2D;
        private Vector2 textStartPos, textEndPos;
        private float iconStartPos, iconEndPos;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();

            textTransform = text.rectTransform;

            textStartPos = textTransform.anchoredPosition - new Vector2(0, tutorialTextData.upwardTextDistance);
            textEndPos = textTransform.anchoredPosition;

            textTransform.anchoredPosition = textStartPos;

            text.color = new Color(1f, 1f, 1f, 0f);

            if (icons.Length == 0)
                return;

            iconStartPos = icons[0].transform.position.y - tutorialTextData.upwardIconDistance;
            iconEndPos = icons[0].transform.position.y;

            foreach (SpriteRenderer icon in icons)
            {
                icon.transform.position -= new Vector3(0, tutorialTextData.upwardIconDistance, 0);
                icon.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (isPermanent)
                    boxCollider2D.enabled = false;

                Sequence seq = DOTween.Sequence();

                seq.Append(textTransform.DOAnchorPos(textEndPos, tutorialTextData.upwardDuration).SetEase(tutorialTextData.upwardEase));
                seq.Join(text.DOFade(1f, tutorialTextData.fadeInDuration).SetEase(tutorialTextData.fadeInEase));

                foreach (SpriteRenderer icon in icons)
                {
                    seq.Join(icon.transform.DOMove(new Vector3(icon.transform.position.x, iconEndPos), tutorialTextData.upwardDuration).SetEase(tutorialTextData.upwardEase));
                    seq.Join(icon.DOFade(1f, tutorialTextData.fadeInDuration).SetEase(tutorialTextData.fadeInEase));
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (isPermanent)
                return;

            if (collision.CompareTag("Player"))
            {
                Sequence seq = DOTween.Sequence();

                seq.Append(textTransform.DOAnchorPos(textStartPos, tutorialTextData.upwardDuration).SetEase(tutorialTextData.upwardEase));
                seq.Join(text.DOFade(0f, tutorialTextData.fadeInDuration).SetEase(tutorialTextData.fadeInEase));

                foreach (SpriteRenderer icon in icons)
                {
                    seq.Join(icon.transform.DOMove(new Vector3(icon.transform.position.x, iconStartPos), tutorialTextData.upwardDuration).SetEase(tutorialTextData.upwardEase));
                    seq.Join(icon.DOFade(0f, tutorialTextData.fadeInDuration).SetEase(tutorialTextData.fadeInEase));
                }
            }
        }

        private void OnDisable()
        {
            DOTween.Kill(textTransform);
            DOTween.Kill(text);

            foreach (SpriteRenderer icon in icons)
            {
                DOTween.Kill(icon.transform);
                DOTween.Kill(icon);
            }
        }
    }
}