using Microsoft.AspNetCore.Http;

namespace SchulungQotd.Service.Utilities
{
    public static class Util
    {
        public static async Task<(byte[] fileContent, string fileContentType)> GetFile(IFormFile? file)
        {
            ArgumentNullException.ThrowIfNull(file);

            if (file.Length < 1) throw new ArgumentException("Fatei-Länge ist kleiner als 1");

            var fileContentType = file.ContentType;
            var fileContent = await GetFileAsByteArrayAsync();

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
