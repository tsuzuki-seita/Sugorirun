using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab; // Bombのプレハブ
    public RectTransform canvasTransform; // CanvasのTransform
    public float spawnInterval = 2f; // 生成間隔
    public float xMin = -400f; // x座標の最小値
    public float xMax = 400f; // x座標の最大値
    public float yThreshold = -1100f; // 再利用するy座標の閾値
    public int poolSize = 10; // オブジェクトプールのサイズ

    private Queue<GameObject> bombPool = new Queue<GameObject>();
    private List<GameObject> activeBombs = new List<GameObject>();
    private float timer;

    void Start()
    {
        // プールの初期化
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bomb = Instantiate(bombPrefab, canvasTransform);
            bomb.SetActive(false);
            bombPool.Enqueue(bomb);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnBomb();
        }

        // 閾値を下回ったBombを再利用
        for (int i = activeBombs.Count - 1; i >= 0; i--)
        {
            if (activeBombs[i].transform.localPosition.y < yThreshold)
            {
                RecycleBomb(activeBombs[i]);
            }
        }
    }

    void SpawnBomb()
    {
        GameObject bomb = GetBombFromPool();
        if (bomb != null)
        {
            float randomX = Random.Range(xMin, xMax);
            bomb.transform.localPosition = new Vector3(randomX, 1100f, 0f); // 生成位置（適宜調整）
            bomb.SetActive(true);
            activeBombs.Add(bomb);
        }
    }

    GameObject GetBombFromPool()
    {
        if (bombPool.Count > 0)
        {
            return bombPool.Dequeue();
        }
        return null; // プールに空きがない場合
    }

    void RecycleBomb(GameObject bomb)
    {
        bomb.SetActive(false);
        activeBombs.Remove(bomb);
        bombPool.Enqueue(bomb);
    }
}
