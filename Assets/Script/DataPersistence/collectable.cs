using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollisionRelocateAndActivate : MonoBehaviour, IDataPersistence
{
    public GameObject objectToRelocate;
    public GameObject[] relocationSpawnPoints;
    public GameObject effectToActivate;
    public Text countText; // Reference to the UI Text element
    public GameObject objectToActive;
    public GameObject showcam;
    public GameObject Descon;
    public GameObject ActInfo;
    public GameObject DesInfo;
    public GameObject DesInfo2;
    public GameObject Desbk;
    public GameObject Desbk2;

    private int relocationCount = 0;
    private bool relocationActivated = false;

    public void LoadData(GameData data)
    {
        this.relocationCount = data.relocationCount;
        if (countText != null)
        {
            countText.text = relocationCount.ToString() + "/15 Obsidian";
        }
    }

    public void SaveData(ref GameData data)
    {
        data.relocationCount = this.relocationCount;
    }

    private void Start()
    {
        StartCoroutine(Desbg());
    }

    private IEnumerator Desbg()
    {
        yield return new WaitForSeconds(3);

        Desbk.SetActive(false);

        yield return new WaitForSeconds(2);

        Desbk2.SetActive(false);
    }

    private void Acti()
    {
        StartCoroutine(ActivationRoutine());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Des"))
        {
            UpdateCountText();
            if (relocationCount < 14)
            {
                effectToActivate.SetActive(true);
                RelocateObject();
                Acti();
            }
            else
            {
                if (!relocationActivated)
                {
                    ActivateRelocation();
                }
                else
                {
                    objectToActive.SetActive(true);
                    showcam.SetActive(true);
                    ActInfo.SetActive(true);
                    Descon.SetActive(false);
                    DesInfo.SetActive(false);
                    DesInfo2.SetActive(false);
                }
            }
        }
    }

    private IEnumerator ActivationRoutine()
    {
        yield return new WaitForSeconds(1);

        effectToActivate.SetActive(false);
    }

    private void RelocateObject()
    {
        int spawnIndex = Random.Range(0, relocationSpawnPoints.Length);
        Vector3 newPosition = relocationSpawnPoints[spawnIndex].transform.position;
        newPosition.y = 7f; // Set y-coordinate to 7
        objectToRelocate.transform.position = newPosition;
    }

    private void ActivateRelocation()
    {
        relocationActivated = true;
        effectToActivate.SetActive(false);

        // Add 10 GameObjects where the relocations will spawn
        for (int i = 0; i < relocationSpawnPoints.Length; i++)
        {
            // Instantiate new GameObjects at each spawn point
            Instantiate(relocationSpawnPoints[i], relocationSpawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    private void UpdateCountText()
    {
        relocationCount++; // Increment count
        if (countText != null)
        {
            countText.text = relocationCount.ToString() + "/15 Obsidian"; // Update UI Text
        }
    }
}
