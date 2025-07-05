using UnityEngine;

public class RandomChance : MonoBehaviour
{
    private int _percentMinValue = 0;
    private int _percentMaxValue = 100;

    public bool Random(float chance)
    {
        float randomChance = UnityEngine.Random.Range(_percentMinValue, _percentMaxValue);

        return randomChance <= chance;
    }
}