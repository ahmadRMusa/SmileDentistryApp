using SmileDentistry.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileDentistry.Helpers
{
    public static class SmileDentistryHelper
    {
        private static Random random;

        public static Smile GetRandomMonkey()
        {
            //var output = Newtonsoft.Json.JsonConvert.SerializeObject(Monkeys);
            return Smiles[random.Next(0, Smiles.Count)];
        }

        public static ObservableCollection<Grouping<string, Smile>> SmilesGrouped { get; set; }

        public static ObservableCollection<Smile> Smiles { get; set; }

        static SmileDentistryHelper()
        {
            random = new Random();
            Smiles = new ObservableCollection<Smile>();            
            var sorted = from smile in Smiles
                         orderby smile.Name
                         group smile by smile.NameSort into monkeyGroup
                         select new Grouping<string, Smile>(monkeyGroup.Key, monkeyGroup);

            SmilesGrouped = new ObservableCollection<Grouping<string, Smile>>(sorted);

        }

    }
}
