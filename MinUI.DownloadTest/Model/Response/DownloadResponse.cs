﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinUI.DownloadTest.Model.Response
{
    public class DownloadResponse
    {
        [JsonPropertyName("fileName")]
        public string? FileName { get; set; }
        [JsonPropertyName("fileData")]
        public string? FileData { get; set; }
        [JsonPropertyName("error")]
        public string? Error { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
