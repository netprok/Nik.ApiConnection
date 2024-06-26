﻿namespace Nik.ApiConnection.Models;

public sealed class ApiCache
{
    public DateTime CreateTime { get; set; } = DateTime.Now;
    public string ConfigKey { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Request { get; set; } = string.Empty;
    public HttpResponseMessage Response { get; set; } = new();
}