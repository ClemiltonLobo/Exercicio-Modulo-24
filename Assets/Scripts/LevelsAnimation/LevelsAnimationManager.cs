using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelsAnimationManager : MonoBehaviour
{
    public Transform leftLevelFolder;   // Pasta com os objetos do lado esquerdo
    public Transform rightLevelFolder;  // Pasta com os objetos do lado direito

    [Header("Animation")]
    public float fadeInDuration = 0.5f; // Duração da animação de fade-in
    public Ease ease = Ease.OutQuad;    // Curva de easing para a animação

    private void Start()
    {
        StartLevelAnimation(leftLevelFolder);
        StartLevelAnimation(rightLevelFolder);
    }

    private void StartLevelAnimation(Transform levelFolder)
    {
        foreach (Transform levelObject in levelFolder)
        {
            levelObject.localScale = Vector3.zero; // Define a escala inicial como zero

            StartCoroutine(AnimateLevelObject(levelObject));
        }
    }

    private IEnumerator AnimateLevelObject(Transform levelObject)
    {
        yield return new WaitForSeconds(fadeInDuration);

        levelObject.GetComponent<Renderer>().material.DOFade(1f, fadeInDuration).SetEase(ease);
    }
}