using System;
using System.IO;
using System.Web;

namespace ProjectoAlexa.Web.Helpers
{
    public class FilesHelper
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }
            try
            {
                // Caminho Físico
                string folderFisico = HttpContext.Current.Server.MapPath("~/") + folder;
                if (!Directory.Exists(folderFisico))
                {
                    Directory.CreateDirectory(folderFisico);
                }

                //Caminho virtual
                folder = "~/" + folder;

                //Juntar o caminho da imagem com o nome
                string path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                file.SaveAs(path);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    file.InputStream.CopyTo(memoryStream);
                    byte[] array = memoryStream.GetBuffer();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
