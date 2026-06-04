using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreenController : MonoBehaviour
{
    [Header("Renderer")]
    private SpriteRenderer screenRenderer;

    [Header("Footage")]
    public Sprite footageBlue;
    public Sprite footage;

    [Header("Final Endings")]
    public Sprite communityService;
    public Sprite deathEnding;
    public Sprite romanceEnding;
    public Sprite therapyEnding;

    public bool fitToCamera = true;

    void FitToCamera()
    {
        if (!fitToCamera) return;
        if (screenRenderer.sprite == null) return;

        Camera cam = Camera.main;
        if (cam == null || ! cam.orthographic) return;

        float worldHeight = cam.orthographicSize * 2f;
        float worldWidth = worldHeight * cam.aspect;

        Vector2 spriteSize = screenRenderer.sprite.bounds.size;

        float scale = Mathf.Max(worldWidth / spriteSize.x, worldHeight / spriteSize.y);

        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0f);

        transform.localScale = new Vector3(scale, scale, 1f);
    }

    void Awake()
    {
        screenRenderer = GetComponent<SpriteRenderer>();
        screenRenderer.enabled = false;
    }

    void Show(Sprite sprite)
    {
        if (sprite == null)
        {
            Debug.LogWarning("Ending sprite is NULL");
            return;
        }

        screenRenderer.sprite = sprite;
        screenRenderer.sortingOrder = 100;
        screenRenderer.enabled = true;

        FitToCamera();
    }

    // ===== Dialogue node calls =====

    public void HideScreen()
    {
        screenRenderer.enabled = false;
    }

    public void ShowFootageBlue()
    {
        Show(footageBlue);
    }

    public void ShowFootage()
    {
        Show(footage);
    }

    public void ShowCommunityService()
    {
        Show(communityService);
    }

    public void ShowDeathEnding()
    {
        Show(deathEnding);
    }

    public void ShowRomanceEnding()
    {
        Show(romanceEnding);
    }

    public void ShowTherapyEnding()
    {
        Show(therapyEnding);
    }
}