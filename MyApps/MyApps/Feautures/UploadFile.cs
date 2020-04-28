using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApps.Feautures
{
    public class UploadFile
    {
        [Obsolete]
        private readonly IHostingEnvironment _hosting;

        [Obsolete]
        public UploadFile(IHostingEnvironment _hosting)
        {
            this._hosting = _hosting;
        }

        [Obsolete]
        public string UploadedFile(IFormFile file, string path)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploads = Path.Combine(_hosting.WebRootPath, path);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fullPath = Path.Combine(uploads, uniqueFileName);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
