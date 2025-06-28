using UnityEngine;

public class RandomChance : MonoBehaviour
{
    public bool Random(float chance)
    {
        float rand = UnityEngine.Random.Range(0, 100);
        Debug.Log(chance + "шанс");
        Debug.Log(rand + "рандом");

        return rand <= chance;
    }
}