using System.Collections.Generic;
using System.Linq;
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
    public void On_Start_All_Categories_Should_Be_Available()
    {
        var yatzy = new YatzyGame();
        var result = yatzy.RemainingCategories();
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void After_Roll_Registering_fñlaksdjflñkjasd()
    {
        var yatzy = new YatzyGame();
        var roll = new Roll(1, 3, 4, 5, 6);
        yatzy.RegisterRoll(roll);
        Assert.Equal(1,yatzy.Rolls);
        Assert.Equal(roll, yatzy.LastRoll);
    }

    [Fact]
    public void Assign_Category_To_Roll()
    {
        var yatzy = new YatzyGame();
        var roll = new Roll(1, 2, 4, 2, 6);
        var expected = yatzy.RemainingCategories().Count - 1;
        yatzy.RegisterRoll(roll);

        yatzy.CategorizeLastRoll(yatzy.RemainingCategories().First());
        
        Assert.Equal(expected, yatzy.RemainingCategories().Count);
    }
    
    [Fact]
    public void Chance_Category_Should_Return_Throw_Addition()
    {
        var category = new ChanceCategory();
        var result = category.ComputePoints(new Roll(5,4,3,4,1));
        Assert.Equal(5 + 4 + 3 + 4 + 1,result);
    }

    [Fact]
    public void Yatzy_Category_Should_Return_Throw_Yatzy()
    {
        Assert.Equal(50, new YatzyCategory().ComputePoints(new Roll(1, 1, 1, 1, 1)));
    }
    
    
    [Fact]
    public void gfaadsfsad()
    {
        Assert.Equal(0, new YatzyCategory().ComputePoints(new Roll(1, 3, 1, 1, 1)));
    }
}

public class YatzyGame
{
    public int Rolls => rolls;
    public Roll LastRoll => lastRoll;

    private int rolls;
    private Roll lastRoll;
    private List<Category> remainingCategories;

    public YatzyGame()
    {
        remainingCategories = new List<Category>
        {
            new YatzyCategory(), 
            new ChanceCategory()
        };
    }
    
    public List<Category> RemainingCategories()
    {
        return remainingCategories;
    }

    public void RegisterRoll(Roll roll)
    {
        lastRoll = roll;
        rolls += 1;
    }


    public void CategorizeLastRoll(Category first)
    {
        remainingCategories.Remove(first);
    }
}

public interface Category
{
    int ComputePoints(Roll roll);
}

public class YatzyCategory : Category
{
    public int ComputePoints(Roll roll)
    {
        return roll.Dices.Distinct().Count() == 1 ? 50 : 0;
    }
}

public class ChanceCategory : Category
{
    public int ComputePoints(Roll roll)
    {
        return roll.Dices.Sum();
    }
}

public class Roll
{
    public int[] Dices => dices;
    private int[] dices;

    public Roll(params int[] dices)
    {
        this.dices = dices;
    }
}