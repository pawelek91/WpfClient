using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RandevouWpfClient.ViewModels
{
    public class UsersSearchResultViewModel
    {
        public string DisplayName { get; set; }
        public int Age { get; set; }
        public BitmapImage Avatar { get; set; }

        public string Gender { get; set; }
    }
}
