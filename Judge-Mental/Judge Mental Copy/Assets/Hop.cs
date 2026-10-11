using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Hop : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;

    public void HopAndrew()
    {
        if(characterTransform == null) return;
        characterTransform.DOKill();
        characterTransform.DOJump(characterTransform.position, 0.4f, 1, 0.4f);
    }

    public void NudgeAndrew()
    {
        if(characterTransform == null) return;
        characterTransform.DOKill();
        float startX = characterTransform.position.x;
        Sequence nudgeSeq =DOTween.Sequence();
        nudgeSeq.Append(characterTransform.DOMoveX(startX - 0.5f, 0.08f));
        nudgeSeq.Append(characterTransform.DOMoveX(startX + 0.5f, 0.12f));
        nudgeSeq.Append(characterTransform.DOMoveX(startX, 0.08f));
    }
        
}
