using UnityEngine;
using DG.Tweening;

public class Slide : MonoBehaviour
{

    public Vector3 onScreenPos;
    public Vector3 offScreenPos;
    public float duration = 0.5f;
    public Ease slideEase = Ease.OutQuad;

    void Awake()
    {
        DOTween.Init();
        transform.position = offScreenPos;
    }

    private void OnEnable()
    {
        entrance();
    }
    
    public void entrance()
    {
        Debug.LogError("Slide" + gameObject.name);
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        transform.DOKill();
        transform.position = offScreenPos;
        transform.DOMove(onScreenPos, duration).SetEase(slideEase).SetUpdate(UpdateType.Normal, true);
        
    }

    public void exit()
    {
        transform.DOKill();
        transform.DOMove(offScreenPos, duration).SetEase(slideEase).SetUpdate(UpdateType.Normal, true).OnComplete(()=>{gameObject.SetActive(false);});
    }
}
