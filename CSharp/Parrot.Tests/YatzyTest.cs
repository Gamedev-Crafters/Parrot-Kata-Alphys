using System.ComponentModel;
using Xunit;

namespace Parrot.Tests;

/*
 * El juego se conforma de un número de rondas en el que se asocia
 * una tirada con una categoría.
 * 
 * 1. El jugador tira 5 dados de 6 caras
 * 2. Se pueden volver a realizar las tiradas hasta 2 veces
 *  2.1 Se pueden volver a tirar cualquier número de dados
 * 3. La tirada puede clasificarse en una categoría
 *  3.1 La categoría no puede repetirse en diferentes rondas
 * 4. Se suman los puntos obtenidos en cada ronda, que dependen
 *    de la asociación de la tirada con la categoría.
 */

public class YatzyTest
{
    [Fact]
    public void Chance_Category_Should_Return_Throw_Addition()
    {
        var category = new ChanceCategory();
        var result = category.ComputePoints(5,4,3,4,1);
        Assert.Equal(5 + 4 + 3 + 4 + 1,result);
    }

    [Fact]
    public void Yatzy_Category_Should_Return_Throw_Yatzy()
    {
        Assert.Equal(50, new YatzyCategory().ComputePoints(1, 1, 1, 1, 1));
    }
    
    
    [Fact]
    public void gfaadsfsad()
    {
        Assert.Equal(0, new YatzyCategory().ComputePoints(1, 3, 1, 1, 1));
    }
}

public class YatzyCategory
{
    public int ComputePoints(int i, int i1, int i2, int i3, int i4)
    {
        return i == i1 && i1 == i2 && i2 == i3 && i3 == i4 ? 50 : 0;
    }
}

public class ChanceCategory
{
    public int ComputePoints(int i, int i1, int i2, int i3, int i4)
    {
        return i + i1 + i2 + i3 + i4;
    }
}