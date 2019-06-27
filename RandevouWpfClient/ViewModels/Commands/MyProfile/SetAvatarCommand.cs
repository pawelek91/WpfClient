using Microsoft.Win32;
using RandevouWpfClient.Models;
using RandevouWpfClient.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands.MyProfile
{
    public class SetAvatarCommand : BasicCommand
    {
        private readonly MyProfileViewModel _myProfileViewModel;

        public SetAvatarCommand(MyProfileViewModel myProfileViewModel)
        {
            _myProfileViewModel = myProfileViewModel;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";

            Nullable<bool> result = fileDialog.ShowDialog();
            if (result == false)
                return;


            var file = fileDialog.FileName;


            string fileExtension = Path.GetExtension(file);
            if (!IsSupportedContent(fileExtension))
            {
                ResultHandler.Message("Nieprawidłowy format pliku");
                return;
            }

            var contentType = FileHandler.GetMimeType(fileExtension);

            SetAvatar(file, contentType);
        }

        private void SetAvatar(string filePath, string contentType)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                using (var fstream = new FileStream(filePath, FileMode.Open))
                    fstream.CopyTo(ms);
            }
            catch(Exception ex)
            {
                ResultHandler.Exception(ex, "Nie udało się otworzyć pliku");
                return;
            }

            try
            {
                QueryProvider.SetAvatar(ms, contentType);
            }
            catch(Exception ex)
            {
                ResultHandler.Exception(ex, "Nie udało się wysłać avatara");
                return;
            }

            _myProfileViewModel.GetAvatar(ms.ToArray());
            ms.Dispose();
        }

        private bool IsSupportedContent(string extension)
        {
            extension = extension.Replace(".", string.Empty);
            string[] extensions = new[] { "jpeg", "png", "jpg", "gif", "bmp" };
            return extensions.Any(x => x.Equals(extension, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
