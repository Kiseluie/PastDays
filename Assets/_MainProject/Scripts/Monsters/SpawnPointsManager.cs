using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public GameObject monsterPrefab; // ������ �������
    public Transform playerTransform; // ��������� ������
    public List<Transform> spawnPoints; // ������ ����� ���������
    private Transform currentPlayerRoom; // ������� ������� ������
    private List<Transform> availableSpawnPoints; // ��������� ����� ��� ������

    void Start()
    {
        // ������������� ������ ��������� ����� ��� ������
        availableSpawnPoints = new List<Transform>(spawnPoints);
        SpawnMonster();
    }

    void SpawnMonster()
    {
        // ������������� �����, ������� ��������� � ��� �� ������� ��� � �����
        availableSpawnPoints.RemoveAll(t => t == currentPlayerRoom);

        if (availableSpawnPoints.Count == 0)
        {
            // ���� ��� ��������� �����, ������� �� �������
            return;
        }

        // ����� ��������� ��������� ����� � �������� �������
        Transform spawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

        // ����������� ����� �������� ����������� ����� ������� � ������ �������
        availableSpawnPoints = new List<Transform>(spawnPoints);
    }

    // ���������� ����� ����� �������� � ������� �������
    public void SetCurrentPlayerRoom(Transform room)
    {
        currentPlayerRoom = room; // ������������� ������� ������� ������
    }
}

