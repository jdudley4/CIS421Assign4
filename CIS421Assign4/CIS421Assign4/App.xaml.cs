using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace CIS421Assign4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        //public static void Main()
        //{
        //    var data = GetData();
        //    var result = ExecuteHashJoin(data);
        //    WriteResultToConsole(result);
        //}

        //private static void WriteResultToConsole(List<AgeNameNemesis> result)
        //{
        //    result.ForEach(ageNameNemesis => Console.WriteLine("Age: {0}, Name: {1}, Nemesis: {2}",
        //        ageNameNemesis.Age, ageNameNemesis.Name, ageNameNemesis.Nemesis));
        //}

        //    private static List<AgeNameNemesis> ExecuteHashJoin(DataContext data)
        //    {
        //        return (data.AgeName.Join(data.NameNemesis,
        //            ageName => ageName.Name, nameNemesis => nameNemesis.Name,
        //            (ageName, nameNemesis) => new AgeNameNemesis(ageName.Age, ageName.Name, nameNemesis.Nemesis)))
        //            .ToList();
        //    }

        //    private static DataContext GetData()
        //    {
        //        var context = new DataContext();

        //        context.AgeName.AddRange(new[] {
        //                new AgeName(27, "Jonah"),
        //                new AgeName(18, "Alan"),
        //                new AgeName(28, "Glory"),
        //                new AgeName(18, "Popeye"),
        //                new AgeName(28, "Alan")
        //            });

        //        context.NameNemesis.AddRange(new[]
        //        {
        //            new NameNemesis("Jonah", "Whales"),
        //            new NameNemesis("Jonah", "Spiders"),
        //            new NameNemesis("Alan", "Ghosts"),
        //            new NameNemesis("Alan", "Zombies"),
        //            new NameNemesis("Glory", "Buffy")
        //        });

        //        return context;
        //    }
        //}
    }
}

