﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchulungQotd.Shared
{
    public static class Util
    {
        public static string LogAsJson<T>(this T obj) where T : class
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        }


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
