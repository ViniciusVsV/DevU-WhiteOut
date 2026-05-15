using DG.Tweening;
using UnityEngine;

namespace MenuSystem
{
    [CreateAssetMenu(fileName = "MenuData", menuName = "Scriptable Objects/MenuData")]
    public class MenuData : ScriptableObject
    {
        public float pausedMuffle;
        public float normalMuffle = 22000f;
    }
}