using SmileDentistry.Helpers;
using SmileDentistry.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileDentistry.ViewModels
{
    public class Tutorial
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }

    public class SmilesViewModel
    {

        public ObservableCollection<Smile> Smiles { get; set; }
        public ObservableCollection<Grouping<string, Smile>> SmileGrouped { get; set; }

        public ObservableCollection<Tutorial> Tutorials { get; set; }

        public SmilesViewModel()
        {

            Smiles = SmileDentistryHelper.Smiles;
            SmileGrouped = SmileDentistryHelper.SmilesGrouped;
            Tutorials = new ObservableCollection<Tutorial>
            {
                new Tutorial
                {
                    ImageUrl = "http://glocify.com/dev/projects/img/step-01.png",
                    Name = "1/3"
                },
                 new Tutorial
                {
                    ImageUrl =    "http://glocify.com/dev/projects/img/step-02.png",
                    Name = "2/3"
                 },
                new Tutorial
                {
                    ImageUrl = "http://glocify.com/dev/projects/img/step-03.png",
                    Name = "3/3"
                }
            };
        }

        public int TutorialCount => Smiles.Count;
    }
}
