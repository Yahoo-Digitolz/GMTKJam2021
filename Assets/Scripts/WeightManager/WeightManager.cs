using UnityEngine;

#region Each objects weight
public enum Weights
{
    LIGHT,
    MEDIUM,
    HEAVY,
}
#endregion


public class WeightManager : MonoBehaviour
{

    #region Methods
    public void ObjectWeightCompare(Weights weight)
    {
        switch (weight)     
        {
            case Weights.LIGHT:
                {
                    // player can catch and keep the object
                    break;
                }
            case Weights.MEDIUM:
                {
                    // player can catch the object but is stuck to it
                    break;
                }
            case Weights.HEAVY:
                {
                    // nor the player and the boss can catch the object
                    break;
                }
            default:
                    break;
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("LightWeight"))
        {
            ObjectWeightCompare(Weights.LIGHT);
        }

        else if(collision.gameObject.CompareTag("MediumWeight"))
        {
            ObjectWeightCompare(Weights.MEDIUM);
        }

        else if(collision.CompareTag("HeavyWeight")
        {
            ObjectWeightCompare(Weights.HEAVY);
        }
    }

    #endregion

    #region Private

    #endregion
}
