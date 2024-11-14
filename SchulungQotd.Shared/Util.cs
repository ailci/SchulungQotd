using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchulungQotd.Shared
{
    public static class Util
    {
        public static async Task<(byte[] fileContent, string fileContentType)> GetFile(IFormFile? file)
        {
            ArgumentNullException.ThrowIfNull(file);

            var fileContent = await GetFileAsByteArrayAsync();
            var fileContentType = file.ContentType;

            async Task<byte[]> GetFileAsByteArrayAsync()
            {
                await using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }

            return (fileContent, fileContentType);
        }
    }
}
