using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    internal interface IFileHelper
    {
        IResult Upload(IFormFile file);
        IResult Update(IFormFile file, string filePath, string publicId = default);
        IResult Delete(string filePath, string publicId = default);
    }
}
