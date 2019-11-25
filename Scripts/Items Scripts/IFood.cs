using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IFood : IItem
{
    int FoodLevel { get; set; }
    int WaterLevel { get; set; }
}