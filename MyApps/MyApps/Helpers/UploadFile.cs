using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApps.Feautures
{
    public class UploadFile
    {
      
        private readonly IHostEnvironment _hosting;

      
        public UploadFile(IHostEnvironment _hosting)
        {
            this._hosting = _hosting;
        }

        
        public string UploadedFile(IFormFile file, string OldPath,string folderPath)
        {
            string uniqueFileName = null;
    
            if (file != null)
            {
                string uploads = Path.Combine(_hosting.ContentRootPath, folderPath);
                uniqueFileName =  Guid.NewGuid().ToString() + "_" + file.FileName;
                string newPath = Path.Combine(uploads, uniqueFileName);
                
                    string oldPath = Path.Combine(uploads, OldPath??string.Empty);
                
                
                if (oldPath != newPath)
                {
                    //delete old path
                    if(OldPath != null)
                    {
                        File.Delete(oldPath/*full oldpath*/);
                    }
                    
                    using (var fileStream = new FileStream(newPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    return uniqueFileName;
                }
                
                  return uniqueFileName;
                
            
            }

            return OldPath;
        }

     
        public string UploadedFile(IFormFile file, string folderPath)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploads = Path.Combine(_hosting.ContentRootPath, folderPath);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string newPath = Path.Combine(uploads, uniqueFileName);
          
                 
                    using (var fileStream = new FileStream(newPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                

            }

            return uniqueFileName;
        }

    }
}
