using UnityEngine;

public class RandomChance : MonoBehaviour
{
    public float chance;

    public bool Random()
    {
        float rand = UnityEngine.Random.Range(0, 100);
        Debug.Log(chance + "шанс");
        Debug.Log(rand + "рандом");

        if (rand <= chance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}