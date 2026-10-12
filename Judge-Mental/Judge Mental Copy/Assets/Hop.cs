using UnityEngine;
using DG.Tweening;

public class Hop : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Vector3 offScreenPosition;
    private UnityEngine.Vector3 restingPosition;

    void Awake()
    {
        if (characterTransform == null)
        {
            characterTransform = transform;
        }

         offScreenPosition = characterTransform.position;
         restingPosition = new UnityEngine.Vector3(offScreenPosition.x + 9f, offScreenPosition.y, offScreenPosition.z);

    }
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

    public void entrance()
    {
        if(characterTransform == null) return;
        characterTransform.DOKill();
        characterTransform.position = offScreenPosition;
        characterTransform.DOMove(restingPosition, 0.6f).SetEase(Ease.OutQuad);
    }

    public void exit()
    {
        if(characterTransform == null) return;
        characterTransform.DOKill();
        characterTransform.DOMove(offScreenPosition, 1f).SetEase(Ease.OutQuad);
    }
        
}
