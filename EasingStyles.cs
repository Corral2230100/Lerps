using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingStyles : MonoBehaviour
{
    /// SOURCES: 
    /// https://easings.net/

    /// Les fonctions ci-dessous utilisent 3 parametres, la valeur initiale, la valeur finale desire et le progres de la transition avec un chiffre de 0 a 1 (on peut le voir come 0% a 100%).
    /// C'est la meme chose que la fonction Mathf.Lerp() en fait, seulement avec des fonctions mathematiques differentes.
    /// mais chaque fonction est un mouvement different et ils peuvent donc etre regardes separement (A l'exception de certaines variantes In/Out/InOut)

    /// C'EST QUOI IN/OUT/INOUT?? : C'est un peu lle "momentum" du mouvement.
    /// IN veut dire que le mouvement accelere. Comme descendre une pente en velo.
    /// OUT veut dire que le mouvement ralentis. Comme monter une pente en velo.
    /// INOUT veut dire qu'il accelere jusqua mi chemin pour ensuite ralentir comme faire du velo dans une demi lune au skatepark.




    ////LINEAIRE
    public static float Linear(float Start, float End, float Value)
    {
        // Un Lerp standard dans unity est lineaire.
        return Mathf.Lerp(Start, End, Value);
    }

    //// QUAD
    public static float Quad_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        return End * TimeValue * TimeValue + Start;
    }

    public static float Quad_Out(float Start, float End, float TimeValue)
    {
        End -= Start;
        return -End * TimeValue * (TimeValue - 2) + Start;
    }

    public static float Quad_InOut(float Start, float End, float TimeValue)
    {
        TimeValue /= .5f;
        End -= Start;
        if (TimeValue < 1) return End * 0.5f * TimeValue * TimeValue + Start;
        TimeValue--;
        return -End * 0.5f * (TimeValue * (TimeValue - 2) - 1) + Start;
    }




    /// SPRING
    public static float Spring(float Start, float End, float TimeValue)
    {
        TimeValue = Mathf.Clamp01(TimeValue);
        TimeValue = (Mathf.Sin(TimeValue * Mathf.PI * (0.2f + 2.5f * TimeValue * TimeValue * TimeValue)) * Mathf.Pow(1f - TimeValue, 2.2f) + TimeValue) * (1f + (1.2f * (1f - TimeValue)));
        return Start + (End - Start) * TimeValue;
    }




    /// CUBIC
    public static float Cubic_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        return End * TimeValue * TimeValue * TimeValue + Start;
    }

    public static float Cubic_Out(float Start, float End, float TimeValue)
    {
        TimeValue--;
        End -= Start;
        return End * (TimeValue * TimeValue * TimeValue + 1) + Start;
    }

    public static float Cubic_InOut(float Start, float End, float TimeValue)
    {
        TimeValue /= .5f;
        End -= Start;
        if (TimeValue < 1) return End * 0.5f * TimeValue * TimeValue * TimeValue + Start;
        TimeValue -= 2;
        return End * 0.5f * (TimeValue * TimeValue * TimeValue + 2) + Start;
    }



    /// QUART
    public static float Quart_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        return End * TimeValue * TimeValue * TimeValue * TimeValue + Start;
    }

    public static float Quart_Out(float Start, float End, float TimeValue)
    {
        TimeValue--;
        End -= Start;
        return -End * (TimeValue * TimeValue * TimeValue * TimeValue - 1) + Start;
    }

    public static float Quart_InOut(float Start, float End, float TimeValue)
    {
        TimeValue /= .5f;
        End -= Start;
        if (TimeValue < 1) return End * 0.5f * TimeValue * TimeValue * TimeValue * TimeValue + Start;
        TimeValue -= 2;
        return -End * 0.5f * (TimeValue * TimeValue * TimeValue * TimeValue - 2) + Start;
    }



    /// QUINT
    public static float Quint_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        return End * TimeValue * TimeValue * TimeValue * TimeValue * TimeValue + Start;
    }

    public static float Quint_Out(float Start, float End, float TimeValue)
    {
        TimeValue--;
        End -= Start;
        return End * (TimeValue * TimeValue * TimeValue * TimeValue * TimeValue + 1) + Start;
    }

    public static float Quint_InOut(float Start, float End, float TimeValue)
    {
        TimeValue /= .5f;
        End -= Start;
        if (TimeValue < 1) return End * 0.5f * TimeValue * TimeValue * TimeValue * TimeValue * TimeValue + Start;
        TimeValue -= 2;
        return End * 0.5f * (TimeValue * TimeValue * TimeValue * TimeValue * TimeValue + 2) + Start;
    }



    /// SINE
    public static float Sine_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        return -End * Mathf.Cos(TimeValue * (Mathf.PI * 0.5f)) + End + Start;
    }

    public static float Sine_Out(float Start, float End, float TimeValue)
    {
        End -= Start;
        return End * Mathf.Sin(TimeValue * (Mathf.PI * 0.5f)) + Start;
    }

    public static float Sine_InOut(float Start, float End, float TimeValue)
    {
        End -= Start;
        return -End * 0.5f * (Mathf.Cos(Mathf.PI * TimeValue) - 1) + Start;
    }



    /// EXPONENTIEL
    public static float Expo_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        return End * Mathf.Pow(2, 10 * (TimeValue - 1)) + Start;
    }

    public static float Expo_Out(float Start, float End, float TimeValue)
    {
        End -= Start;
        return End * (-Mathf.Pow(2, -10 * TimeValue) + 1) + Start;
    }

    public static float Expo_InOut(float Start, float End, float TimeValue)
    {
        TimeValue /= .5f;
        End -= Start;
        if (TimeValue < 1) return End * 0.5f * Mathf.Pow(2, 10 * (TimeValue - 1)) + Start;
        TimeValue--;
        return End * 0.5f * (-Mathf.Pow(2, -10 * TimeValue) + 2) + Start;
    }



    /// CIRCULAIRE
    public static float Circ_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        return -End * (Mathf.Sqrt(1 - TimeValue * TimeValue) - 1) + Start;
    }

    public static float Circ_Out(float Start, float End, float TimeValue)
    {
        TimeValue--;
        End -= Start;
        return End * Mathf.Sqrt(1 - TimeValue * TimeValue) + Start;
    }

    public static float Circ_InOut(float Start, float End, float TimeValue)
    {
        TimeValue /= .5f;
        End -= Start;
        if (TimeValue < 1) return -End * 0.5f * (Mathf.Sqrt(1 - TimeValue * TimeValue) - 1) + Start;
        TimeValue -= 2;
        return End * 0.5f * (Mathf.Sqrt(1 - TimeValue * TimeValue) + 1) + Start;
    }



    /// BACK

    public static float  Back_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        TimeValue /= 1;
        float s = 1.70158f;
        return End * (TimeValue) * TimeValue * ((s + 1) * TimeValue - s) + Start;
    }

    public static float Back_Out(float Start, float End, float TimeValue)
    {
        float s = 1.70158f;
        End -= Start;
        TimeValue = (TimeValue) - 1;
        return End * ((TimeValue) * TimeValue * ((s + 1) * TimeValue + s) + 1) + Start;
    }

    public static float Back_InOut(float Start, float End, float TimeValue)
    {
        float s = 1.70158f;
        End -= Start;
        TimeValue /= .5f;
        if ((TimeValue) < 1)
        {
            s *= (1.525f);
            return End * 0.5f * (TimeValue * TimeValue * (((s) + 1) * TimeValue - s)) + Start;
        }
        TimeValue -= 2;
        s *= (1.525f);
        return End * 0.5f * ((TimeValue) * TimeValue * (((s) + 1) * TimeValue + s) + 2) + Start;
    }



    /// ELASTIC
    public static float Elastic_In(float Start, float End, float TimeValue)
    {
        End -= Start;

        float d = 1f;
        float p = d * .3f;
        float s;
        float a = 0;

        if (TimeValue == 0) return Start;

        if ((TimeValue /= d) == 1) return Start + End;

        if (a == 0f || a < Mathf.Abs(End))
        {
            a = End;
            s = p / 4;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(End / a);
        }

        return -(a * Mathf.Pow(2, 10 * (TimeValue -= 1)) * Mathf.Sin((TimeValue * d - s) * (2 * Mathf.PI) / p)) + Start;
    }

    public static float Elastic_Out(float Start, float End, float TimeValue)
    {
        End -= Start;

        float d = 1f;
        float p = d * .3f;
        float s;
        float a = 0;

        if (TimeValue == 0) return Start;

        if ((TimeValue /= d) == 1) return Start + End;

        if (a == 0f || a < Mathf.Abs(End))
        {
            a = End;
            s = p * 0.25f;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(End / a);
        }

        return (a * Mathf.Pow(2, -10 * TimeValue) * Mathf.Sin((TimeValue * d - s) * (2 * Mathf.PI) / p) + End + Start);
    }

    public static float Elastic_InOut(float Start, float End, float TimeValue)
    {
        End -= Start;

        float d = 1f;
        float p = d * .3f;
        float s;
        float a = 0;

        if (TimeValue == 0) return Start;

        if ((TimeValue /= d * 0.5f) == 2) return Start + End;

        if (a == 0f || a < Mathf.Abs(End))
        {
            a = End;
            s = p / 4;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(End / a);
        }

        if (TimeValue < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (TimeValue -= 1)) * Mathf.Sin((TimeValue * d - s) * (2 * Mathf.PI) / p)) + Start;
        return a * Mathf.Pow(2, -10 * (TimeValue -= 1)) * Mathf.Sin((TimeValue * d - s) * (2 * Mathf.PI) / p) * 0.5f + End + Start;
    }  



    //// BOUNCE
    public static float Bounce_In(float Start, float End, float TimeValue)
    {
        End -= Start;
        float d = 1f;
        return End - Bounce_Out(0, End, d - TimeValue) + Start;
    }

    public static float Bounce_Out(float Start, float End, float TimeValue)
    {
        TimeValue /= 1f;
        End -= Start;
        if (TimeValue < (1 / 2.75f))
        {
            return End * (7.5625f * TimeValue * TimeValue) + Start;
        }
        else if (TimeValue < (2 / 2.75f))
        {
            TimeValue -= (1.5f / 2.75f);
            return End * (7.5625f * (TimeValue) * TimeValue + .75f) + Start;
        }
        else if (TimeValue < (2.5 / 2.75))
        {
            TimeValue -= (2.25f / 2.75f);
            return End * (7.5625f * (TimeValue) * TimeValue + .9375f) + Start;
        }
        else
        {
            TimeValue -= (2.625f / 2.75f);
            return End * (7.5625f * (TimeValue) * TimeValue + .984375f) + Start;
        }
    }

    public static float Bounce_InOut(float Start, float End, float TimeValue)
    {
        End -= Start;
        float d = 1f;
        if (TimeValue < d * 0.5f) return Bounce_In(0, End, TimeValue * 2) * 0.5f + Start;
        else return Bounce_Out(0, End, TimeValue * 2 - d) * 0.5f + End * 0.5f + Start;
    }
}
