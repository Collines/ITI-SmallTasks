using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day02.Models
{
    public class CarList
    {
        public static List<Car> Cars = new List<Car>() {
            new Car() {Num=1,Model="C180",Color="Black",Manfacture="Mercedes"},
            new Car() {Num=2,Model="H4",Color="Black",Manfacture="Hummer"},
            new Car() {Num=3,Model="C200",Color="Red",Manfacture="Mercedes"},
            new Car() {Num=4,Model="C300",Color="White",Manfacture="Mercedes"},
        };
    }
}