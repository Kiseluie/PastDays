using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public GameObject monsterPrefab; // Префаб монстра
    public Transform playerTransform; // Трансформ игрока
    public List<Transform> spawnPoints; // Список точек появления
    private Transform currentPlayerRoom; // Текущая комната игрока
    private List<Transform> availableSpawnPoints; // Доступные точки для спавна

    void Start()
    {
        // Инициализация списка доступных точек для спавна
        availableSpawnPoints = new List<Transform>(spawnPoints);
        SpawnMonster();
    }

    void SpawnMonster()
    {
        // Отфильтровать точки, которые находятся в той же комнате что и игрок
        availableSpawnPoints.RemoveAll(t => t == currentPlayerRoom);

        if (availableSpawnPoints.Count == 0)
        {
            // Если нет доступных точек, выходим из функции
            return;
        }

        // Выбор случайной доступной точки и создание монстра
        Transform spawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

        // Опционально можно добавить возвращение точек обратно в список спавнов
        availableSpawnPoints = new List<Transform>(spawnPoints);
    }

    // Вызывается когда игрок попадает в триггер комнаты
    public void SetCurrentPlayerRoom(Transform room)
    {
        currentPlayerRoom = room; // Устанавливаем текущую комнату игрока
    }
}

