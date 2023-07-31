using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager gameManager;
    public TileBoard board;
    public CanvasGroup gameOverCanvas;
    private void Awake()
    {
        gameManager = this;
    }
    void Start()
    {
        NewGameFuntion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGameFuntion()
    {
        gameOverCanvas.alpha = 0f;
        gameOverCanvas.interactable = false;
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true; 
    }

    public void Gameover()
    {
        board.enabled = false;
        gameOverCanvas.interactable = true;
        StartCoroutine(Faded(gameOverCanvas, 1f, 1f));
    }

    private IEnumerator Faded(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);
        float duration = 0.5f;
        float elapsed = 0f;
        float from = canvasGroup.alpha;

        while(elapsed< duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;

            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
