using SmileDentistry.Models;

namespace SmileDentistry.ViewModels
{
    public class DetailsViewModel
    {
        public Smile smile { get; set; }
        public DetailsViewModel(Smile smile)
        {
            this.smile = smile;
        }
    }
}